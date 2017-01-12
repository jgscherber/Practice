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

    Private Sub DumpButton_Click(sender As Object, e As EventArgs) Handles DumpButton.Click
        Dim PersonA As Person
        Dim PersonB As Person

        For Each PersonA In Roster
            Debug.WriteLine("")
            Debug.WriteLine(PersonA.LongDump)
            For Each PersonB In Roster
                If PersonA IsNot PersonB Then
                    Call DumpRelationships(PersonA, PersonB)
                End If
            Next
        Next

    End Sub


    Private Sub DumpRelationships(PersonA As Person, PersonB As Person)
        Dim compatibility As Integer = 0
        Dim activity As String
        For Each activity In MDB.ActivityList
            compatibility += PersonA.Likes(activity) * PersonB.Likes(activity)
        Next
        ' Debug.WriteLine("[C: " & compatibility.ToString & ", R+R: " & PersonB.CurrentRelationship())
    End Sub

    Public Sub Interact(PerosnA As Person, PersonB As Person, Need As String, Activity As String)
        Dim RCa As Integer
        Dim RCb As Integer

        Dim bonus As Integer = 0

    End Sub



End Class
