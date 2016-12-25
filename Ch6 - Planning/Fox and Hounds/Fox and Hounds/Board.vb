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

    Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
        ThisGame = New GameState
        PriorBoards.Clear()
        UndoButton.Enabled = False ' undo code hasnt been setup yet
        Call ThisGame.MarkButtons(BoardSquares)
    End Sub
End Class
