Imports Mines

Public Class RuleTwoNear
    Inherits BasicRule

    Public Overrides Function Matches(RevealedSquare As Square) As Integer
        Dim theField As PlayingField = RevealedSquare.Parent ' get reference to playing field

        Dim CloseNeighbors As Collection = theField.NearNeighbors(
            RevealedSquare.R, RevealedSquare.C) ' get the neighbors of the square

        Call AI.TwoSquareMatcher(RevealedSquare, CloseNeighbors,
                                 SimonSays, SquaresList) ' SquaresList and SimonSays attributes of superclass

        If SquaresList.Count > 0 Then ' only doing the output portion, clicking done in TwoSquareMatcher?
            If SimonSays = PossibleActions.BlanksToFlags Then ' if the AI says to change blanks to flags
                theField.MoreThoughts(Me.GetType.Name & " sees " & SquaresList.Count.ToString _
                                      & " mines to flag.")
            Else
                theField.MoreThoughts(Me.GetType.Name & " sees " & SquaresList.Count.ToString _
                                      & " safe squares to click.")

            End If
        End If
        Return SquaresList.Count
    End Function
End Class
