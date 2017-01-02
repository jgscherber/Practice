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

#End Region



End Class
