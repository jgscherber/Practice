Public MustInherit Class BasicRule
    Public Enum PossibleActions
        BlanksToFlags
        ClickBlanks
    End Enum

    Protected SimonSays As PossibleActions 'protected: can only be accessed within class, or in derived classes
    ' Private: can only be accessed within class, not by descendents

    Protected SquaresList As New Collection ' targets if the possible actions

    Public MustOverride Function Matches(RevealedSquare As Square) As Integer

    Public Sub Execute()
        Dim Sq As Square
        For Each Sq In SquaresList
            ' if the square hasn't been flagged and hasn't been revealed
            If (Not Sq.IsRevealed) And (Sq.Text = "") Then
                Select Case SimonSays
                    Case PossibleActions.ClickBlanks
                        ' reveak the square
                        Call Sq.LeftClick()
                    Case PossibleActions.BlanksToFlags
                        ' add a flag
                        Call Sq.RightClick()
                End Select
            End If
        Next
    End Sub


End Class
