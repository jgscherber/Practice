Public Class Job

#Region "Instantiation"
    Private myName As String
    Private myPSuccess As Double
    Private myCost As Double
    Private myGain As Double
    Private myLoss As Double

    Public Sub New(Name As String, PSuccessAsPercentage As Double,
                   Cost As Double, Gain As Double, Loss As Double) ' get attribute on creation
        myName = Name
        If PSuccessAsPercentage > 100 Or PSuccessAsPercentage < 0 Then
            MsgBox("Bad PSuccess value fed to Job.New")
        End If
        myPSuccess = PSuccessAsPercentage / 100.0 ' convert from percentage to double
        myCost = Cost
        myGain = Gain
        myLoss = Loss
    End Sub
    Public Function Name() As String
        Return myName
    End Function
    Public Function PSuccess() As Double
        Return myPSuccess
    End Function
    Public Function Cost() As Double
        Return myCost
    End Function
    Public Function Gain() As Double
        Return myGain
    End Function
    Public Function Loss() As Double
        Return myLoss
    End Function
#End Region

    Public Function Wages() As Double
        If Rnd() < myPSuccess Then
            Return myGain
        Else
            Return -myLoss
        End If
    End Function


End Class
