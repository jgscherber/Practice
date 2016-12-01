Public Class Square
    Inherits System.Windows.Forms.Button

    Public Enum HiddenValue
        Uninitialized
        Safe
        Mine
    End Enum

    ' Create immutable variables (Const)
    Public Const ShowMine As String = "@"
    Public Const ShowFlag As String = "F"
    Public Const ShowBrokenFlag As String = "X"

    Public contents As HiddenValue ' what does the square hold? (Enum above)
    Private actualNearMines As Integer ' how many nearby mines
    Private Revealed As Boolean ' initialize as boolean

    Dim Row, Col As Integer 'global variables in the class

    Public ReadOnly Property IsRevealed() As Boolean ' control access to the private variable
        Get ' used to return the private variable
            Return Revealed
        End Get
        ' also can change private variable using Set...End Set (but this property is ReadOnly)
    End Property

    ' initialization subroutine
#Region "Initialization Code"
    Public Sub New(R As Integer, C As Integer)
        ' MyBase is the super class, create a new super class object
        MyBase.New()
        ' Set properties from the superclass
        Me.Font = New System.Drawing.Font("Arial", 9, FontStyle.Bold) ' haha had font size set 0.9!
        Me.BackColor = Color.White

        ' Row and Col declared above, remaining must be declared in superclass?
        Row = R
        Col = C
        Height = 30
        Width = 30
        Text = ""
        FlatStyle = System.Windows.Forms.FlatStyle.Standard
        contents = HiddenValue.Uninitialized ' Enums like self-contain class attributes (dot operator)

    End Sub

    Public Sub Init(HV As HiddenValue, Neighbors As Collection)
        contents = HV

        If contents = HiddenValue.Mine Then
            Dim Sq As Square ' declare variable for loop
            For Each Sq In Neighbors
                Sq.IncrementMineCount()
            Next
        End If

        ' debugging code
        'If contents = HiddenValue.Mine Then
        '    Me.Text = ShowMine ' change button text to @
        'End If


    End Sub

    Public Sub IncrementMineCount()
        actualNearMines += 1

        ' debuggin code
        'If contents <> HiddenValue.Mine Then
        '    ' Don't need the full path to the Text property (Me.Text)
        '    Text = actualNearMines.ToString ' Text property only takes a string, need ToString on Integer
        'End If
    End Sub
#End Region

#Region "Game Code"
    ' created using drop-downs at the top of the window; Square Events -> Click
    Private Sub Square_Click(sender As Object, e As EventArgs) Handles Me.Click
        ' set up a reference to the PlayingField superclass
        Dim theField As PlayingField = Me.Parent ' can assign when declaring

        ' all if one one line!
        If theField Is Nothing Then Exit Sub ' no field, nothing to do

        ' if this square hasn't been initialized, then none of them have
        If contents = HiddenValue.Uninitialized Then
            ' make them be so!

            Call theField.InitializeSquares(Row, Col) ' click initializes all squares with a value
            ' no subsequent clicks will have a HiddenValue of Uninitialized
        End If

        ' If the button hasn't been clicked yet, check what should happen
        If Not Revealed Then

            If contents = HiddenValue.Safe Then
                Revealed = True
                ' Make the button look clicked afterwards
                FlatStyle = System.Windows.Forms.FlatStyle.Flat
                BackColor = Color.LightGray

                If actualNearMines > 0 Then
                    Me.Text = actualNearMines.ToString
                Else
                    ' Implement free moves??
                End If
                theField.DecrementMovesLeft()
            Else
                Me.Text = ShowMine
                theField.EndGame()
            End If
        End If
    End Sub

    Public Sub EndGame()
        ' Called by the field
        Me.Enabled = False ' sets/gets whether the element can respond to input
        If Not Revealed Then
            If contents = HiddenValue.Mine Then
                If Me.Text <> ShowFlag Then
                    Me.Text = ShowMine
                End If
            Else
                If Me.Text <> "" Then
                    Me.Text = ShowBrokenFlag
                End If
            End If
        End If
    End Sub

#End Region
End Class
