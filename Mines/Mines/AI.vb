Module AI
    Public Function BasicStatsAndBlanks(ByVal RevealedSquare As Square _
            , ByVal Neighbors As Collection _
            , ByRef sees As Integer, ByRef flags As Integer _
            , ByRef blanks As Integer) As Collection
        Dim BlankSquares As New Collection
        If RevealedSquare.Text <> "" Then
            sees = CInt(RevealedSquare.Text) ' assigns the number of nearby mines to a square
        End If

        Dim Sq As Square
        For Each Sq In Neighbors ' neighbors passed in as an argument
            If Not Sq.IsRevealed Then ' only hidden squares
                Select Case Sq.Text
                    Case ""
                        blanks += 1
                        BlankSquares.Add(Sq, PlayingField.KeyFromRC(Sq.R, Sq.C))
                    Case Square.ShowFlag
                        flags += 1
                End Select

            End If
        Next
        Return BlankSquares
    End Function
End Module
