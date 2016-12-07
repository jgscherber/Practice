Public Class FrameWork
    Private Rules As New Collection ' hold all possible rules

    Public Sub AddRule(goodIdea As BasicRule)
        If Not Rules.Contains(goodIdea.GetType.Name) Then
            Rules.Add(goodIdea, goodIdea.GetType.Name)
        End If
    End Sub

    Public Sub RunAI(RevealedSquare As Square) ' match and execute routine
        Dim bestRule As BasicRule = Nothing
        Dim bestScore As Integer = 0 ' instantiate variables at their minimums

        Dim theField As PlayingField = RevealedSquare.Parent ' get playingfield refence from passed square

        Dim someRule As BasicRule
        Dim currentScore As Integer
        For Each someRule In Rules ' check each rule for the highest score (most non-revealed, non-flagged squares)
            currentScore = someRule.Matches(RevealedSquare)
            If currentScore > bestScore Then
                bestRule = someRule
                bestScore = currentScore
            End If
        Next
        If bestRule IsNot Nothing Then ' if a bestRule was chosed (currentScore is at least)
            theField.MoreThoughts("    Executing" & bestRule.GetType.Name)
            bestRule.Execute()
        Else
            theField.MoreThoughts("    No good ideas found.")
        End If
    End Sub


End Class
