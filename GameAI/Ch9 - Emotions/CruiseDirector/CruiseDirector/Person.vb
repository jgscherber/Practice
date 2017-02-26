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

    Public Sub UpdateRelationships(theirName As String, howMuch As Integer)
        Dim thisRelation As NVP
        If myRelationships.Contains(theirName) Then
            thisRelation = CType(myRelationships(theirName), NVP)
            thisRelation.value += howMuch
        Else
            thisRelation = New NVP
            thisRelation.name = theirName
            thisRelation.value = howMuch
            myRelationships.Add(thisRelation, theirName)
        End If
    End Sub

    Public Function NeedsSome(need As String) As Boolean
        Dim someNeed As NVP = CType(myNeeds(need), NVP)
        Return (someNeed.value <= 0)
    End Function

    Public Function Likes(activity As String) As Integer
        Dim somePref As NVP = CType(myPreferences(activity), NVP)
        Return somePref.value
    End Function

    Public Function CurrentRelationship(theirName As String) As Integer
        If myRelationships.Contains(theirName) Then
            Dim rel As NVP = CType(myRelationships(theirName), NVP)
            Return rel.value
        End If
        Return 0
    End Function

    Public Function ShortDump() As String
        Dim sn As String = myname & "["
        Dim someNeed As NVP
        For Each someNeed In myNeeds
            sn = sn & " " & someNeed.value.ToString
        Next
        sn = sn & " ]"
        Return sn
    End Function

    Public Function LongDump() As String
        Dim ld As String = ""
        Dim opinionated As Double = 0.0
        Dim view As Integer = 0

        Dim attr As NVP
        For Each attr In myPreferences
            opinionated += attr.value * attr.value
            view += attr.value
            ld = ld & " " & attr.name & "=" & attr.value.ToString
        Next
        Return (Me.ShortDump & " View=" & view.ToString & " Op=" & Format(opinionated / myPreferences.Count, "0.00") & "; " & ld)
    End Function




End Class
