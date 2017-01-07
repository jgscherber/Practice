Public Class Vehicle

#Region "Instantiation Code"

    Public Const VehicleWidth As Integer = 20
    Private myName As String
    Private myDesiredSpeed As Integer
    Private myLength As Integer
    Private Xpos As Double = 0
    Private myLane As Integer = 1
    Private CurrentV As Integer

    Dim WithEvents Body As TextBox
    Dim HeadLights As Label
    Dim NameTag As Label


    Public Sub New(length As Integer, desiredSpeed As Integer,
                   parent As Road, X As Integer, V As Integer, callMe As String)
        ' storing data
        myName = callMe
        myDesiredSpeed = desiredSpeed
        CurrentV = V
        Xpos = X
        myLength = length
        ' create objects that will represent them visually
        Body = New TextBox
        HeadLights = New Label
        NameTag = New Label

        If desiredSpeed <= 0 Then ' remove from the screen if not moving
            NameTag.Visible = False
            myLane = 0
        End If

        ' add the objects to the parent (the window)
        Body.Parent = parent
        HeadLights.Parent = parent
        NameTag.Parent = parent

        ' vehicles are sideways on the form (width = height)
        Body.Height = VehicleWidth
        HeadLights.Height = VehicleWidth \ 4 ' \ is integer division (sub-pixel arcuracy is not needed)
        ' and vice versa
        Body.Width = length
        HeadLights.Width = 2 * desiredSpeed

        ' auto-size name tag
        NameTag.Text = myName & ":" & desiredSpeed.ToString
        NameTag.AutoSize = True

        ' Color them
        Body.BackColor = Color.White
        HeadLights.BackColor = Color.Transparent
        NameTag.BackColor = Color.Transparent

        ' outlines
        Body.BorderStyle = BorderStyle.FixedSingle
        HeadLights.BorderStyle = BorderStyle.FixedSingle
        NameTag.BorderStyle = BorderStyle.None

        ' textbox control fixes (only using it as a dsiplay)
        Body.TextAlign = HorizontalAlignment.Center
        Body.ReadOnly = True

        Me.Draw(-200) ' put it on the map after all the setup
    End Sub

    ' places object on the display objecy
    Public Sub Draw(offset As Integer)

        HeadLights.Width = 2 * CurrentV

        ' place vehicle vertically
        Body.Top = VehicleWidth * (10 - 2 * myLane) ' top property is location on screen
        HeadLights.Top = Body.Top
        NameTag.Top = Body.Top - NameTag.Height

        ' place vehical horizontally
        Body.Left = Me.X - Body.Width - offset
        HeadLights.Left = Me.X - offset
        NameTag.Left = Body.Left + Body.Width \ 2 - NameTag.Width \ 2

        Body.Text = CurrentV.ToString
    End Sub
#End Region

#Region "Public Stuff"

    Public Function ID() As String
        Return myName
    End Function

    Public Function X() As Integer
        Return CInt(Xpos)
    End Function

    Public Function Speed() As Integer
        Return CurrentV
    End Function

    Public Function Length() As Integer
        Return myLength
    End Function

    Public Function Lane() As Integer
        Return myLane
    End Function

    Public Sub MoveForward(FrameRate As Integer)
        Xpos += CurrentV / FrameRate
    End Sub

    ' acts as an acceleration limit
    Public Function BestNextSpeed() As Integer
        Dim a As Integer = CInt(0.1 * (2 * myDesiredSpeed - CurrentV))
        If a < 1 Then a = 1 ' sets a acceleration floor
        Dim newV As Integer = CurrentV + a
        If newV > myDesiredSpeed Then newV = myDesiredSpeed ' dont go faster than desired
        Return newV
    End Function

    ' who is ahead?
    Private Function CarAhead(desiredLane As Integer, myIndex As Integer, theRoad As Road) As Vehicle
        Dim i As Integer
        Dim OtherGuy As Vehicle
        For i = myIndex + 1 To theRoad.ToyBox.Count
            OtherGuy = CType(theRoad.ToyBox(i), Vehicle)
            If OtherGuy.Lane = desiredLane Then
                Return OtherGuy ' either the next car in the sorted Collection
            End If
        Next
        Return Nothing ' or no one
    End Function

    ' who is behind?
    Private Function CarBehind(desiredLane As Integer, myIndex As Integer, theRoad As Road) As Vehicle
        Dim i As Integer
        Dim OtherGuy As Vehicle
        For i = myIndex - 1 To 1 Step -1
            OtherGuy = CType(theRoad.ToyBox(i), Vehicle)
            If OtherGuy.Lane = desiredLane Then
                Return OtherGuy
            End If
        Next
        Return Nothing
    End Function

    Public Sub Think(myIndex As Integer, theRoad As Road)
        Dim newlane As Integer = myLane - 1
        Dim newspeed As Integer = -100

        Dim i As Integer
        For i = myLane - 1 To myLane + 1
            If i > 0 Then ' keep lane number greater than 0
                Dim otherspeed As Integer = SpeedInLane(i, myIndex, theRoad)
                If otherspeed > newspeed Then
                    newspeed = otherspeed
                    newlane = i
                End If
            End If
        Next

        If CurrentV = newspeed Then Me.Body.BackColor = Color.White
        If newspeed > CurrentV Then Me.Body.BackColor = Color.LightGreen
        If newspeed < CurrentV Then Me.Body.BackColor = Color.Pink

        CurrentV = newspeed
        myLane = newlane

    End Sub

    Private Function SpeedInLane(somelane As Integer, myIndex As Integer, theRoad As Road) As Integer
        Dim CUTOFF_BUFFER As Integer = 21

        If (somelane > theRoad.Lanes()) Or (somelane < 1) Then
            Return 0
        End If

        Dim BlindSpot As Vehicle = CarBehind(somelane, myIndex, theRoad)
        If somelane <> myLane Then
            If BlindSpot IsNot Nothing Then
                Dim tail As Integer = Me.X - Me.Length - CUTOFF_BUFFER
                If tail < BlindSpot.X Then ' my tail is further back than the other cars nose
                    Return -1
                End If
                tail += CUTOFF_BUFFER - BlindSpot.Speed * 2 ' give some breathing room

            End If
        End If
        Dim OtherGuy As Vehicle = CarAhead(somelane, myIndex, theRoad)
        If OtherGuy Is Nothing Then
            Return BestNextSpeed() ' no one ahead, can drive as fast as I want

        Else
            If myLane <> OtherGuy.Lane Then
                Dim tail As Integer = OtherGuy.X - OtherGuy.Length - CUTOFF_BUFFER
                If tail < Me.X Then
                    Return -1
                End If
            End If
        End If

        Dim deltaX As Integer = OtherGuy.X - Me.X - OtherGuy.Length
        Dim matchSpeed As Integer = deltaX \ 2

        If OtherGuy.Lane = Me.Lane Then
            If OtherGuy.Speed > Me.Speed Then
                If Me.Speed > matchSpeed Then
                    matchSpeed = Me.Speed
                End If
            End If

            If OtherGuy.Speed > myDesiredSpeed Then
                matchSpeed = myDesiredSpeed
            End If
        End If
        If matchSpeed > BestNextSpeed() Then matchSpeed = BestNextSpeed()

        Return matchSpeed
    End Function
#End Region

#Region "Reference Car"

    Public Sub MoveFloatingMarker(refV As Vehicle, FrameRate As Integer, halfSize As Integer)
        If refV.Speed = 0 Then Return
        Xpos -= refV.Speed / FrameRate ' marker appears to go backward
        While Xpos < refV.X - halfSize ' after it falls off the end, put it back to the front
            Xpos += 2 * halfSize
        End While
        While Xpos > refV.X + halfSize + 1 ' reset it if the refV gets too fast
            Xpos -= 2 * halfSize
        End While
    End Sub

    Private Sub Body_Click(sender As Object, e As EventArgs) Handles Body.Click
        Dim theRoad As Road = CType(Body.Parent, Road)
        theRoad.ReferenceVehicle = Me
    End Sub
#End Region


End Class
