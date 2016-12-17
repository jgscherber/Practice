Imports Mines

Public Class RuleOne
    Inherits BasicRule

    Public Overrides Function Matches(RevealedSquare As Square) As Integer
        Me.SquaresList.Clear() ' declared in superclass
        If RevealedSquare.IsRevealed Then ' passed in as an parameter
            ' mainly an error check to make sure we're within playing field / valid square

            Dim theField As PlayingField = RevealedSquare.Parent ' get a reference to the playing field from the square

            Dim Neighbors As Collection = theField.NearNeighbors(RevealedSquare.R, RevealedSquare.C)

            Dim sees As Integer = 0
            Dim flags As Integer = 0
            Dim blanks As Integer = 0
            Dim BlankSquares As Collection

            BlankSquares = BasicStatsAndBlanks(RevealedSquare, Neighbors, sees,
                                             flags, blanks) ' using other method to get all the info (Encapsulation!)
            If blanks > 0 Then ' no blanks, no work to be done

                If sees = flags Then
                    theField.MoreThoughts(Me.GetType.Name & " sees " _
                                          & blanks.ToString & " safe squares to click.")
                    SimonSays = PossibleActions.ClickBlanks
                    SquaresList = BlankSquares
                End If
                If blanks + flags = sees Then
                    theField.MoreThoughts(Me.GetType.Name & " sees " _
                                         & blanks.ToString & " safe squares to flag.")
                    SimonSays = PossibleActions.BlanksToFlags
                    SquaresList = BlankSquares
                End If
            End If
        End If
        Return Me.SquaresList.Count ' number of moves we can make???
    End Function
End Class
