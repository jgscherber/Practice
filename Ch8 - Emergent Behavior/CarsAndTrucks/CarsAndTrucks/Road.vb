Public Class Road

#Region "Adding Vehicles"
    Public ToyBox As New Collection ' collection to hold all the objects

    Private Sub Road_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Vehicle( length, desired soeed, parent, Xpos, initial speed, name)

        ' add in ascending X pos
        ' sorting allows the collision detector to only have to check next object in the list
        ' re-sorting everytime won't be too bad as most items remain in place
        ToyBox.Add(New Vehicle(35, 600, Me, -3025, 50, "F1+")) ' crash test car
        ToyBox.Add(New Vehicle(35, 180, Me, -1025, 50, "Exotic")) ' fast car
        ToyBox.Add(New Vehicle(30, 95, Me, -605, 50, "Bike F")) ' 3 motorcycles
        ToyBox.Add(New Vehicle(30, 90, Me, -545, 50, "Bike E"))
        ToyBox.Add(New Vehicle(30, 85, Me, -485, 50, "Bike D"))
        ToyBox.Add(New Vehicle(35, 120, Me, -425, 50, "Sport")) ' another fast car
        ToyBox.Add(New Vehicle(30, 80, Me, -365, 50, "Bike C")) ' more varying speeds

        ' initial test vehicles
        ToyBox.Add(New Vehicle(30, 75, Me, -305, 50, "Bike B"))
        ToyBox.Add(New Vehicle(45, 60, Me, -240, 50, "Coupe"))
        ToyBox.Add(New Vehicle(200, 50, Me, 0, 50, "Truck"))
        ToyBox.Add(New Vehicle(45, 60, Me, 70, 50, "Sedan"))
        ToyBox.Add(New Vehicle(30, 80, Me, 120, 50, "Bike A"))

        ' slow trucks
        ToyBox.Add(New Vehicle(200, 55, Me, 1000, 50, "Truck"))
        ToyBox.Add(New Vehicle(200, 50, Me, 1400, 50, "Truck"))

        Me.ReferenceVehicle = CType(ToyBox(1 + ToyBox.Count \ 2), Vehicle) ' middle vehicle is the default reference

    End Sub
#End Region

    Dim FrameRate As Integer = 15
    Dim ThinkRate As Integer = 2

    Dim startTime As Date
    Dim framecount As Integer

    Public WriteOnly Property ReferenceVehicle() As Vehicle
        Set(value As Vehicle)
            refVehicle = value
            RefLabel.Text = refVehicle.ID
        End Set
    End Property

    Public Function Lanes() As Integer
        Return CInt(LanesUpDown.Value)
    End Function

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        startTime = Now
        framecount = 0
        AnimationTimer.Interval = CInt(1000 / FrameRate)
        AnimationTimer.Enabled = True

        ThinkTimer.Interval = CInt(1000 / ThinkRate)
        ThinkTimer.Enabled = True

        FPSLabel.Visible = False
        PanScrollBar.Enabled = False

    End Sub

    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        AnimationTimer.Enabled = False
        ThinkTimer.Enabled = False

        Dim stopTime As Date = Now
        Dim min As Integer = stopTime.Subtract(startTime).Minutes
        Dim secs As Integer = stopTime.Subtract(startTime).Seconds + 60 * min
        If secs < 1 Then secs = 1

        FPSLabel.Text = Format((framecount / secs), "0.0") & " FPS "
        FPSLabel.Visible = True
        PanScrollBar.Enabled = True
    End Sub

    ' every one second tick of the animation timer
    Private Sub AnimationTimer_Tick(sender As Object, e As EventArgs) Handles AnimationTimer.Tick
        Dim Toy As Vehicle

        framecount += 1
        Dim offset As Integer = CInt(Me.Width / 2)

        For Each Toy In ToyBox
            Toy.MoveForward(FrameRate)
            ' Toy.Draw(-offset) ' ground reference
            Toy.Draw(refVehicle.X - offset) ' vehicle reference

            FloatingMarker.MoveFloatingMarker(refVehicle, FrameRate, offset)
            FloatingMarker.Draw(refVehicle.X - offset)
        Next Toy
    End Sub

    ' car tracking code
    Private refVehicle As Vehicle
    Dim FloatingMarker As New Vehicle(2, 0, Me, 0, 0, "Floating Marker") ' mile marker

    ' need collision detect and list sorting
    Private Sub SortToys()
        Dim swapped As Boolean
        Dim Behind As Vehicle
        Dim Ahead As Vehicle

        While swapped
            swapped = False
            Dim i As Integer
            For i = 1 To ToyBox.Count - 1 ' sorting ToyBox
                Behind = CType(ToyBox(i), Vehicle) ' back has the lowest subscript
                Ahead = CType(ToyBox(i + 1), Vehicle) ' ahead has the next subscript
                If Ahead.X < Behind.X Then ' if ordering isn't correct
                    swapped = True
                    ' Debug.WriteLine("***" & Behind.ID & " has passed " & _ Ahead.ID)
                    ToyBox.Remove(i + 1) ' swap them
                    ToyBox.Add(Ahead,, i)
                End If
            Next
        End While

        ' grab the leader and trailer to set scrollbar
        Behind = CType(ToyBox(1), Vehicle)
        Ahead = CType(ToyBox(ToyBox.Count), Vehicle)

        Dim offset As Integer = CInt(Me.Width / 2)

        PanScrollBar.Minimum = Behind.X - offset
        PanScrollBar.Maximum = Ahead.X - offset
        If refVehicle IsNot Nothing Then
            PanScrollBar.Value = refVehicle.X - offset
        End If

        PanScrollBar.LargeChange = Me.Width \ 4
        Call CollisionDetect()

    End Sub

    Private Sub CollisionDetect()
        Dim Toy As Vehicle
        Dim Bag As New Collection ' groups vehicles by lane
        Dim myBag As Collection

        Dim key As String

        For Each Toy In ToyBox
            key = Toy.Lane.ToString
            If Not Bag.Contains(key) Then
                Bag.Add(New Collection, key)
            End If
            myBag = CType(Bag(key), Collection)
            myBag.Add(Toy)
        Next

        Dim Behind As Vehicle
        Dim Ahead As Vehicle

        Dim i As Integer
        For Each myBag In Bag ' same sorting code as in SortToys() w/o swapping
            For i = 1 To myBag.Count - 1
                Behind = CType(ToyBox(i), Vehicle) ' back has the lowest subscript
                Ahead = CType(ToyBox(i + 1), Vehicle) ' ahead has the next subscript
                If Ahead.X < Behind.X Then ' if ordering isn't correct
                    ' Debug.WriteLine("***" & Behind.ID & " has passed " & _ Ahead.ID)
                    ToyBox.Remove(i + 1) ' swap them
                    ToyBox.Add(Ahead,, i)
                End If
            Next i
        Next myBag
    End Sub

    Private Sub ThinkTimer_Tick(sender As Object, e As EventArgs) Handles ThinkTimer.Tick
        Call SortToys()

        Dim Toy As Vehicle
        Dim i As Integer

        ' run the AI front to back
        For i = ToyBox.Count To 1 Step -1 ' going backwards
            Toy = CType(ToyBox(i), Vehicle)
            Toy.Think(i, Me)
        Next i
    End Sub

    Private Sub PanScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles PanScrollBar.Scroll
        Dim Toy As Vehicle
        For Each Toy In ToyBox
            Toy.Draw(PanScrollBar.Value) ' redraws the buttons using the scrollbars current position as the offset
        Next
    End Sub
End Class
