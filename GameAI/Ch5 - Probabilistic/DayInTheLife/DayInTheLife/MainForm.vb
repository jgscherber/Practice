Public Class MainForm
    Public Sub Say(someThought As String)
        ThoughtsTextBox.AppendText(someThought & vbCrLf)
    End Sub

    Dim Occupations As New Collection

    Private Sub MainForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

#Region "Adding Jobs"
        ' Format to add: Ocucpations.Add(New Job(Name, Success%, Cost, Gain, Loss))
        Occupations.Add(New Job("Street", 75.0, 0.0, 0.2, 0.0))

        Occupations.Add(New Job("Day Job", 99.0, 0.01, 1.0, 0.0))

        Occupations.Add(New Job("Stuntshow", 70.0, 0.1, 2.5, 1.0))

        Occupations.Add(New Job("Lotto", 0.01, 0.01, 10000.0, 0.0))

        Occupations.Add(New Job("Crime", 30.0, 0.02, 100.0, 200.0))

        Occupations.Add(New Job("Rock Band", 0.5, 0.05, 1000.0, 0.0))

        Occupations.Add(New Job("Financier", 66.0, 100.0, 220.0, 70.0))
#End Region
        Randomize() ' reseed RNd() function, but why? - ensures new random numbers everytime game is executed
    End Sub

    Private Sub RunSim(name As String, Dude As Person)
        ThoughtsTextBox.Clear()

        Dim cash As Double = 10.0
        Dim curJobName As String = "Just starting out"
        Dim curJob As Job = Nothing

        Dim wages As Double
        Dim expense As Double

        Dim daysInJob As Integer = 0
        Dim wins As Double = 0.0
        Dim losses As Double = 0.0
        Dim costs As Double = 0.0
        Dim living As Double = 0.0

        Dim i As Integer
        For i = 1 To 1000
            curJob = Dude.Pick(cash, Occupations)
            If curJob.Name <> curJobName Then
                Say(name & " spent " & daysInJob.ToString & " with job " _
                    & curJobName & " ending with $" & Format(cash, "#,##0.00") _
                    & " from $" & Format(wins, "#,##0.00") & " gains less (" _
                    & Format(losses, "#,##0.00") & " + " & Format(costs, "#,##0.00") _
                    & " + " & Format(living, "#,##0.00") & ") in losses+costs+expenses.")
                curJobName = curJob.Name
                daysInJob = 0
                wins = 0.0
                losses = 0.0
                costs = 0.0
                living = 0.0
            End If
            daysInJob += 1

            cash -= curJob.Cost
            costs += curJob.Cost

            wages = curJob.Wages
            cash += wages
            If wages > 0 Then wins += wages
            If wages < 0 Then losses -= wages

            If cash < 0 Then
                Debug.WriteLine("Bankruptcy")
                cash = 0
            End If
            expense = 0.0
            If cash > 500 Then
                expense = 2.5
            Else
                If cash >= 1 Then
                    expense = 0.25
                Else
                    If cash >= 0.1 Then
                        expense = 0.025
                    End If
                End If
            End If
            living += expense
            cash -= expense
        Next

        Say(name & " spent " & daysInJob.ToString & " with job " _
                    & curJobName & " ending with $" & Format(cash, "#,##0.00") _
                    & " from $" & Format(wins, "#,##0.00") & " gains less (" _
                    & Format(losses, "#,##0.00") & " + " & Format(costs, "#,##0.00") _
                    & " + " & Format(living, "#,##0.00") & ") in losses+costs+expenses.")

    End Sub

    Private Sub EddyButton_Click(sender As Object, e As EventArgs) Handles EddyButton.Click
        RunSim("Eddy", New Eddy)
    End Sub

    Private Sub BarryButton_Click(sender As Object, e As EventArgs) Handles BarryButton.Click
        RunSim("Barry", New Barry)
    End Sub

    Private Sub CarlButton_Click(sender As Object, e As EventArgs) Handles CarlButton.Click
        RunSim("Carl", New Carl)
    End Sub

    Private Sub GaryButton_Click(sender As Object, e As EventArgs) Handles GaryButton.Click
        RunSim("Gary", New Gary)
    End Sub

    Private Sub LarryButton_Click(sender As Object, e As EventArgs) Handles LarryButton.Click
        RunSim("Larry", New Larry)
    End Sub

    Private Sub MikeButton_Click(sender As Object, e As EventArgs) Handles MikeButton.Click
        RunSim("Mike", New Mike)
    End Sub
End Class
