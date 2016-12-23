Public Class House
    Private Sub AmbientUpDown_ValueChanged(sender As Object, e As EventArgs) Handles AmbientUpDown.ValueChanged
        'don't need to import module? part of the same solution?'
        AI.RunAI(Me)
    End Sub

    Private Sub DayDateTime_ValueChanged(sender As Object, e As EventArgs) Handles DayDateTime.ValueChanged
        AI.RunAI(Me)
    End Sub

    Private Sub House_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AI.RunAI(Me)
    End Sub

    Private Sub NightTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles NightTimePicker.ValueChanged
        AI.RunAI(Me)
    End Sub

    Private Sub SetPointUpDown_ValueChanged(sender As Object, e As EventArgs) Handles DayUpDown.ValueChanged
        AI.RunAI(Me)
    End Sub

End Class
