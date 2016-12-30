Public Class FaHButton
    Inherits Button

    Private MySubscript As Integer ' only this class has access to this variable
    Protected HoundNumber As Integer ' available to this class and subclasses

    Public ReadOnly Property Subscript() As Integer
        Get
            Return MySubscript
        End Get
    End Property

    Public Sub New(ss As Integer)
        MySubscript = ss

        AllowDrop = True ' attribute of the Button class that it's inheriting from
        Me.Font = New System.Drawing.Font("Arial", 9, FontStyle.Bold)
    End Sub
#Region "Drag-and-Drop"
    Private Sub FaHButton_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Dim MainForm As Board = CType(Me.Parent, Board) ' parent of the button is the board
        Dim GS As GameState = MainForm.CurrentGameState

        Debug.WriteLine("Mouse Down " & MySubscript.ToString)

        ' only be able to drag-and-drop buttons that have hounds or foxes in them
        If MySubscript = GS.FoxAt Then
            HoundNumber = -1
            Call DoDragDrop(Me, DragDropEffects.Move) ' build in subroutine
            Debug.WriteLine("DragDrop Fox")
        End If

        Dim i As Integer
        Dim Hounds() As Integer = GS.HoundsAt()
        For i = 0 To 3
            If MySubscript = Hounds(i) Then
                HoundNumber = i
                Call DoDragDrop(Me, DragDropEffects.Move)
                Debug.WriteLine("DragDrop a hound")
            End If
        Next
    End Sub

    Private Sub FaHButton_DragOver(sender As Object, e As DragEventArgs) Handles Me.DragOver
        'Debug.WriteLine("Fah DragOver")
        e.Effect = DragDropEffects.None ' defaults to no action done
        If Not (e.Data.GetDataPresent(GetType(FaHButton))) Then ' only allow fox and hound buttons, not all buttons
            Return
        End If

        Dim MainForm As Board = CType(Me.Parent, Board)
        Dim GS As GameState = MainForm.CurrentGameState
        If GS.HasChecker(MySubscript) Then ' if already has a checker, can't drop on them
            Return
        End If

        Dim Source As FaHButton = CType(e.Data.GetData(GetType(FaHButton)), FaHButton)
        If Source.Subscript = GS.FoxAt Then
            Dim FoxsNeighbors As Collection = Moves.Neighbors(Source.Subscript) ' am I one of their neightbors?
            If FoxsNeighbors.Contains(MySubscript.ToString) Then ' valid move
                e.Effect = DragDropEffects.Move
            End If
        Else
            Dim HoundMoves As Collection = Moves.MovesDown(Source.Subscript)
            If HoundMoves.Contains(MySubscript.ToString) Then
                e.Effect = DragDropEffects.Move
            End If
        End If
    End Sub

    Private Sub FaHButton_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        Debug.WriteLine("DragDrop event")

        Dim MainForm As Board = CType(Me.Parent, Board) 'Me.Parent is of type "Control"
        Dim GS As GameState = MainForm.CurrentGameState

        Dim Source As FaHButton = CType(e.Data.GetData(GetType(FaHButton)), FaHButton)
        If Source.HoundNumber < 0 Then
            MainForm.CurrentGameState = GS.ProposeFoxTo(MySubscript)
        Else
            MainForm.CurrentGameState = GS.ProposeHoundTo(Source.HoundNumber, MySubscript)
        End If
    End Sub

#End Region
End Class
