Public Class Monster
#Region "Public Interface for the AI"

    ' Get's the information for player detection
    ' Will be called by FSM so needs to be Public
    Public Function DetectsPlayers() As Boolean
        ' Returns boolean of checked state
        ' If more than one way to detect player, could OR them together
        Return (SeePlayerCheck.Checked)
    End Function

    ' Get the information on monster's health
    Public Function GoodHealth() As Boolean
        'If CurrentHealth.Value >= 0.3 * CurrentHealth.Maximum Then
        '    Return (True)
        'Else
        '    Return (False)
        'End If
        Return (CurrentHealth.Value >= 0.3 * CurrentHealth.Maximum)

    End Function

    ' Write text to the text box
    Public Sub Say(someThought As String)
        ThoughtsText.AppendText(someThought & vbCrLf)
    End Sub
#End Region
End Class
