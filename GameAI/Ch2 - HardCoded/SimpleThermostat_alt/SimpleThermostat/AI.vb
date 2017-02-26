Module AI
    'Evalutes world conditions and give back a response as the string'
    'As String designates that it's suppose to return a string (vs. a Sub that'
    'isn't suppose to return anything)'

    'Will take in the currentTemp and the desiredTemp from our environment'
    'program (House.vb)'

    'Private function because it's only called w/in this module'
    Private Function CoreAI(currentTemp As Integer, desiredTemp As Integer) As String
        If currentTemp < desiredTemp Then
            Return ("Heat")
        Else
            Return ("Off")
        End If
    End Function
    'Public Wrapper function. How the module interacts with outside variables'
    'Takes a variable of the House class. Our window defines the class House (House.vb)'
    Public Sub RunAI(World As House)
        'Takes the variables from the public and passes them to our private - Encapsulation!'
        'Returns a string and passes it to the StatusLabel (Heat or Off)'
        If (DateTime.Now.TimeOfDay > World.NightTimePicker.Value.TimeOfDay) And (DateTime.Now.TimeOfDay < World.DayDateTime.Value.TimeOfDay) Then
            World.StatusLabel.Text = CoreAI(CInt(World.AmbientUpDown.Value) _
        , CInt(World.NightUpDown.Value))
        Else
            World.StatusLabel.Text = CoreAI(CInt(World.AmbientUpDown.Value) _
        , CInt(World.DayUpDown.Value))
        End If

    End Sub

End Module
