Public Class Board
    Dim BoardSquares(31) As FaHButton
    Dim ThisGame As GameState
    Dim PriorBoards As New Collection ' store old boards to support undo function

    Private Sub Board_Load(sender As Object, e As EventArgs) Handles Me.Load ' created using dropdowns
        Dim i As Integer
        Dim sq As FaHButton
        Const sqSize As Integer = 50 ' const so can't be changed

        Call InitMoves()
        For i = 0 To 31
            sq = New FaHButton(i)
            sq.Height = sqSize ' Height and Width are properties of the Button superclass
            sq.Width = sqSize

            sq.Parent = Me ' set the board to be the button's parent object
            sq.Top = 5 + sqSize * (i \ 4) ' integer divisor
            sq.Left = 5 + (sqSize * 2) * (i Mod 4) + sqSize * (((i \ 4) + 1) Mod 2)
            BoardSquares(i) = sq
        Next i
        Call ResetButton_Click(Nothing, Nothing)
    End Sub

    Public Property CurrentGameState() As GameState
        Get
            Return ThisGame
        End Get
        Set(value As GameState)
            If ThisGame IsNot Nothing Then
                PriorBoards.Add(ThisGame) ' when a new game board is created, move the previous to our PriorBoards collection
                UndoButton.Enabled = True ' and allow the Undo to be used now
            End If
            ThisGame = value ' set the new board to the current
            Call ThisGame.MarkButtons(BoardSquares) ' redraw the board with new configuration
        End Set
    End Property

#Region "Button Clicks"
    Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
        ThisGame = New GameState
        PriorBoards.Clear()
        UndoButton.Enabled = False ' undo code hasnt been setup yet
        Call ThisGame.MarkButtons(BoardSquares)
    End Sub

    Private Sub UndoButton_Click(sender As Object, e As EventArgs) Handles UndoButton.Click
        If PriorBoards.Count > 0 Then
            ThisGame = CType(PriorBoards(PriorBoards.Count), GameState) ' set the last element in PriorBoards to current gamestate
            PriorBoards.Remove(PriorBoards.Count) ' then remove it
            UndoButton.Enabled = (PriorBoards.Count > 0) ' clever!
            Call ThisGame.MarkButtons(BoardSquares) ' redraw the squares
        End If
    End Sub

    Private Sub FoxButton_Click(sender As Object, e As EventArgs) Handles FoxButton.Click
        Me.Cursor = Cursors.WaitCursor
        Dim startTime As Date = Now ' for performance measurements
        Me.CurrentGameState = AI.MoveFox(ThisGame)
        Debug.WriteLine("Fox move took " & HowLong(startTime) & "ms") ' HowLong user defined
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub HoundButton_Click(sender As Object, e As EventArgs) Handles HoundButton.Click
        Me.Cursor = Cursors.WaitCursor
        Dim startTime As Date = Now
        Me.CurrentGameState = AI.MoveHounds(ThisGame)
        Debug.WriteLine("Hounds move took " & HowLong(startTime) & "ms")
    End Sub


#End Region

    ' helper function to get performance metrics
    Private Function HowLong(startTime As Date) As String
        Dim stopTime As Date = Now
        Dim secs As Integer = stopTime.Subtract(startTime).Seconds ' only returns the seconds
        Dim ms As Integer = stopTime.Subtract(startTime).Milliseconds ' only returns the milliseconds
        Return (secs * 1000 + ms).ToString ' addes seconds and milliseconds and returns
    End Function


End Class
