Public Class GameForm
    'global variable for the class'
    Dim dieSize As Integer
    'event handler for loading the form (Handles MBase.Load)'
    Private Sub GameForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'this change on Load also triggered the radio event handler, which called ComputeHitPoints'
        MageRadio.Checked = True

    End Sub
    Sub ComputeHitPoints()
        'Gets the value attribute from the Level object'
        'dieSize is a global variable, assigned by radio-changing event handlers'
        HitPointsLabel.Text = CStr(dieSize * Level.Value)
    End Sub
    ' event handler for changing values in the Level NumericUpDown object (Level.ValueChanged)'
    Private Sub Level_ValueChanged(sender As Object, e As EventArgs) Handles Level.ValueChanged
        'Call keyword not required - for clarity only'
        Call ComputeHitPoints()

    End Sub
    'event handler for radio, notice it's CheckedChanged - also executes on radio button being unselected'
    Private Sub MageRadio_CheckedChanged(sender As Object, e As EventArgs) Handles MageRadio.CheckedChanged
        'need to check if radio is checked when event handler is run'
        If MageRadio.Checked Then
            dieSize = 4
            'called w/o Call keyword'
            ComputeHitPoints()
        End If

    End Sub

    Private Sub ThiefRadio_CheckedChanged(sender As Object, e As EventArgs) Handles ThiefRadio.CheckedChanged
        If ThiefRadio.Checked Then
            dieSize = 6
            'dont need to pass any arguments, uses global dieSize and an object attribute
            ComputeHitPoints()
        End If
    End Sub

    Private Sub ClericRadio_CheckedChanged(sender As Object, e As EventArgs) Handles ClericRadio.CheckedChanged
        If ClericRadio.Checked Then
            dieSize = 8
            ComputeHitPoints()
        End If
    End Sub

    Private Sub FighterRadio_CheckedChanged(sender As Object, e As EventArgs) Handles FighterRadio.CheckedChanged
        If FighterRadio.Checked Then
            dieSize = 10
            ComputeHitPoints()
        End If
    End Sub
End Class
