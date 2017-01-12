Public Class Cruise
    Dim Roster As New Collection ' list of all the passengers
    Dim MDB As New MiniDB ' database the handles data manipulation

    Private Sub Cruise_Load(sender As Object, e As EventArgs) Handles Me.Load
        Randomize()

        MDB.Add("tennis", "exercise")
        MDB.Add("swimming", "exercise")
        MDB.Add("workout", "exercise")
        MDB.Add("movie", "culture")
        MDB.Add("tour", "culture")
        MDB.Add("drama", "culture")
        MDB.Add("French cuisine", "dining")
        MDB.Add("Adian cuisine", "dining")
        MDB.Add("pub fare", "dining")

        ' add people using the button
        Call PeopleButton_Click(Nothing, Nothing)
    End Sub

    Private Sub PeopleButton_Click(sender As Object, e As EventArgs) Handles PeopleButton.Click
        Dim people() As String = {"Drackett", "Jones", "Lincoln", "Morrill", "Stradley", "Taylor"}
        Dim surname As String

        Debug.WriteLine("+++++++++ LOADING NEW PEOPLE.")
        Roster.Clear()
        For Each surname In people
            Roster.Add(New Person(surname, MDB))
        Next
    End Sub
End Class
