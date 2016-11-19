Module AI
    'Evalutes world conditions and give back a response as the string
    'As String designates that it's suppose to return a string (vs. a Sub that
    'isn't suppose to return anything)

    ' Enums (Enumerations) like mini-classes, can only hold listed constants
    ' Accessed using dot operators
    Private Enum CurrentMode
        Heat
        Cool
        'Off
        Unknown
    End Enum

    Private Function Furnace(World As House)
        Dim ModeRadios() As RadioButton = {World.AirButton, World.HeatButton}
        Dim ModeValues() As CurrentMode = {CurrentMode.Cool, CurrentMode.Heat}

        Dim i As Integer

        ' GetUpperBound returns the highest valid subscript
        ' (For inclusive on both ends)
        For i = 0 To ModeRadios.GetUpperBound(0)
            If ModeRadios(i).Checked Then
                Return ModeValues(i)
            End If
        Next
        Return CurrentMode.Unknown
    End Function

    Private Function DesiredTemp(World As House) As Integer
        Dim ss As Integer

        Dim foundss As Integer = 3

        ' loops through the the values in the SetTimes array, assigning it to foundss as long as it's bigger
        ' wont assign if it's smaller, so it'll be in the correct range
        For ss = 0 To 3
            If World.TimeUpDown.Value >= World.SetTimes(ss) Then
                foundss = ss
            End If
        Next

        ' SetTemps is an array, index matched to SetTimes
        World.SetPointLabel.Text = CStr(World.SetTemps(foundss))

        Return World.SetTemps(foundss)
    End Function

    Private Function CoreAI(currentTemp As Integer,
                            desiredTemp As Integer, mode As CurrentMode) As String


    End Function
    'World is pass in by House.vb
    'Public function, interacts with environment (House.vb)
    Public Sub RunAI(World As House)
        ' user defined Enum
        Dim mode As CurrentMode
        Dim desired As Integer

        desired = DesiredTemp(World)
        mode = FurnaceMode(World)

        World.StatusLabel.Text = CoreAI(CInt(World.AmbientUpDown.Value), desired, mode)


    End Sub

End Module
