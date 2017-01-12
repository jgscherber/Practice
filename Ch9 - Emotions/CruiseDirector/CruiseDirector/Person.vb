Public Class Person
    Dim myname As String
    Dim myNeeds As New Collection
    Dim myPreferences As New Collection
    Dim myRelationships As New Collection

    Public Sub New(name As String, MDB As MiniDB) ' need a name and database to reference needs
        myname = name
        myNeeds = MDB.SetOfNeeds
        myPreferences = MDB.SetOfPreferences
    End Sub

    Public Function HighestNeed() As NVP
        Dim highNeed As NVP = CType(myNeeds(1), NVP) ' default to first need
        Dim someNeed As NVP
        For Each someNeed In myNeeds
            If someNeed.value < highNeed.value Then highNeed = someNeed ' look for the highest need (most negative)
        Next
        Return highNeed
    End Function

    Public Sub EaseNeed(Need As String)
        Dim someNeed As NVP = CType(myNeeds(Need), NVP)
        someNeed.value += 10 * myNeeds.Count ' increase the value of the need after satisfaction (balances with # of needs)
        If someNeed.value > 100 Then someNeed.value = 100 ' ceiling
    End Sub

    Public Sub IncAllNeeds()
        Dim someNeed As NVP
        For Each someNeed In myNeeds
            someNeed.value -= 10 ' decrease all needs by 10 every iteration
            If someNeed.value < -100 Then someNeed.value = -100 ' floor
        Next someNeed
    End Sub

End Class
