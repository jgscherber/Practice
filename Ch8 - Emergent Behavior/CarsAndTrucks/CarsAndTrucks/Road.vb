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

    End Sub
#End Region

    Dim FrameRate As Integer = 6
    Dim ThinkRate As Integer

    Dim startTime As Date
    Dim framecount As Integer

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        startTime = Now
        framecount = 0
        AnimationTimer.Interval = CInt(1000 / FrameRate)
        AnimationTimer.Enabled = True

        ThinkTimer.Interval = CInt(1000 / ThinkRate)
        ThinkTimer.Enabled = True


    End Sub



End Class
