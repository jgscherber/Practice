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

    Dim Brains As New FSM
    Dim Feelings As New FSM
    Private Sub Monster_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' adds the states to the machine
        ' Adds a state-stateName value pair to States collection in FSM
        Brains.LoadState(New HidingState)
        Brains.LoadState(New AttackState)
        Brains.LoadState(New FleeState)


        Feelings.LoadState(New FeelHappy)
        Feelings.LoadState(New FeelAfraid)
        Feelings.LoadState(New FeelAngry)
    End Sub

    Private Sub ThinkButton_Click(sender As Object, e As EventArgs) Handles ThinkButton.Click
        Brains.RunAI(Me)
        Feelings.RunAI(Me)
    End Sub
#End Region

#Region "Emotions FSM"



#End Region
End Class
