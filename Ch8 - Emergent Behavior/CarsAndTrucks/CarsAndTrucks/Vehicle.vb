Public Class Vehicle

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
        HeadLights.Height = VehicleWidth
        ' and vice versa
        Body.Width = length
        HeadLights.Width = 2 * desiredSpeed

        ' auto-size name tag


    End Sub
End Class
