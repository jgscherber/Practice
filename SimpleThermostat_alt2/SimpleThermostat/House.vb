Public Class House

    'parenthesis indicate the variables are arrays'
    Public ReadOnly SetTemps() As Integer = {70, 64, 68, 60}
    Public ReadOnly SetTimes() As Integer = {6, 9, 12, 21}

    Private Sub AmbientUpDown_ValueChanged(sender As Object, e As EventArgs) Handles AmbientUpDown.ValueChanged
        'don't need to import module? part of the same solution?'
        AI.RunAI(Me)
    End Sub

    Private Sub House_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AI.RunAI(Me)
    End Sub


    Private Sub TimeUpDown_ValueChanged(sender As Object, e As EventArgs) Handles TimeUpDown.ValueChanged
        AI.RunAI(Me)
    End Sub

    Private Sub AirButton_CheckedChanged(sender As Object, e As EventArgs) Handles AirButton.CheckedChanged
        AI.RunAI(Me)
    End Sub

    Private Sub HeatButton_CheckedChanged(sender As Object, e As EventArgs) Handles HeatButton.CheckedChanged
        AI.RunAI(Me)
    End Sub
End Class
