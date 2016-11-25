Public Class PlayingField


    ' global variables
    ' dim a multidimensional array with no dimensions (m,n)
    Public Field(,) As Square
    Dim NumRows, NumCols, NumMines As Integer

    Private Sub NewGame(nRows As Integer, nCols As Integer, nMines As Integer)

        Dim Sq As Square

        Me.Cursor = Cursors.WaitCursor
        ' if the field isn't already empty, then clear it out
        If Field IsNot Nothing Then
            For Each Sq In Field
                If Sq IsNot Nothing Then
                    Sq.Parent = Nothing
                End If
            Next
        End If

        'copy the passed in params to the globls
        NumRows = nRows
        NumCols = nCols

        ' Error check before assigning nMines to global NumMines
        Dim SqCnt As Integer
        If nMines Then
    End Sub

    Private Sub ExpertButton_Click(sender As Object, e As EventArgs) Handles ExpertButton.Click
        NewGame(16, 30, 99)
    End Sub

End Class
