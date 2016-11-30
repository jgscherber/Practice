Public Class PlayingField


    ' global variables
    ' dim a multidimensional array with no dimensions (m,n)
    Public Field(,) As Square
    Dim NumRows, NumCols, NumMines As Integer

    Private Sub NewGame(nRows As Integer, nCols As Integer, nMines As Integer)

        Dim Sq As Square

        Me.Cursor = Cursors.WaitCursor

        If Field IsNot Nothing Then  ' if the field isn't already empty
            For Each Sq In Field
                If Sq IsNot Nothing Then ' then clear it out
                    Sq.Parent = Nothing
                End If
            Next
        End If

        'copy the passed in params to the globls
        NumRows = nRows
        NumCols = nCols

        Dim SqCnt As Integer
        If nMines > SqCnt Then ' Error check before assigning nMines to global NumMines
            nMines = SqCnt - 1 ' make sure there's at least 1 empty square in the game board
        End If
        NumMines = nMines

        ReDim Field(NumRows - 1, NumCols - 1) ' -1 for zero-based arrays
        Dim row, col As Integer
        ' Create all the squares
        For col = 0 To NumCols - 1
            For row = 0 To NumRows - 1
                Sq = New Square(row, col) ' give each square object info about where it is
                ' set it's location in the form
                Sq.Top = row * Sq.Height
                Sq.Left = col * Sq.Width
                Sq.Parent = Me ' the parent object of the square is the PlayingField object
                Field(row, col) = Sq ' store it in array for easy referencing
            Next
        Next
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ExpertButton_Click(sender As Object, e As EventArgs) Handles ExpertButton.Click
        NewGame(16, 30, 99)
    End Sub

    Public Sub InitializeSquares(ClickedRow As Integer, ClickedCol As Integer)
        ' Called by the first button click, generates the mines and accumulates the neighbors for
        ' each mined square


    End Sub

End Class
