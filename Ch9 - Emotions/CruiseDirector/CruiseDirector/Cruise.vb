Public Class Cruise
    Dim Roster As New Collection
    Dim MDB As New MiniDB

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
        'Call PeopleButton_Click(Nothing,Nothing)
    End Sub
End Class
