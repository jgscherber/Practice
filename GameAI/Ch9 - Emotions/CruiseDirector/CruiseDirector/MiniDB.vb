Public Class MiniDB

    Dim ToDo As New Collection
    Dim Needs As New Collection
    Dim ActivityNames As New Collection

    ' tracking 3 things: activities, names and activities that satisfy specific needs
    Public Sub Add(Activity As String, Satisfies As String)
        Dim Category As Collection
        If Not ToDo.Contains(Satisfies) Then
            Debug.WriteLine("Creating " & Satisfies)
            Needs.Add(Satisfies)
            Category = New Collection
            ToDo.Add(Category, Satisfies) ' allows getting a group of activities that all satisfy one need
        Else
            Category = CType(ToDo.Item(Satisfies), Collection)
        End If

        If Not Category.Contains(Activity) Then
            Debug.WriteLine("Adding " & Activity & " to " & Satisfies)
            Category.Add(Activity, Activity) ' Activity is already a string
        End If
        If Not ActivityNames.Contains(Activity) Then ' keep tracks of all the namesj
            ActivityNames.Add(Activity, Activity)
        End If
    End Sub

    ' used to add needs to a person
    ' this is our DB class, where they should be stored
    Public Function SetOfNeeds() As Collection

        Dim PersonalNeeds As New Collection
        Dim net As Integer = 0
        Dim need As String
        Dim thisNeed As NVP = Nothing ' NVP is our person class
        For Each need In Needs ' go through all needs
            thisNeed = New NVP
            thisNeed.name = need
            thisNeed.value = 21 - getDx(41) ' get dice is dice module, 41 dots on the face
            PersonalNeeds.Add(thisNeed, need)
            net += thisNeed.value
        Next need
        If Needs.Count > 0 Then
            thisNeed = CType(PersonalNeeds(getDx(Needs.Count)), NVP)
            thisNeed.value -= net
        Else
            Debug.WriteLine("cannot create SetOfNeeds: No needs in database.")
        End If
        Return PersonalNeeds
    End Function

    ' Give a person a set of individual preferences.
    ' Preferences run from -2 to +2
    Public Function SetOfPreferences() As Collection
        Dim PersonalPreferences As New Collection
        Dim Activity As String
        For Each Activity In ActivityNames
            Dim thisPreference As New NVP
            thisPreference.name = Activity
            thisPreference.value = getDx(5) - 3  ' gives -2 to +3
            'thisPreference.value = getDx(7) - 4 ' gives -3 to +3
            PersonalPreferences.Add(thisPreference, Activity)
        Next Activity
        Return PersonalPreferences
    End Function

    ' get a random activity for the need passed
    Public Function ActivityForNeed(Satisfies As String) As String

        If ToDo.Contains(Satisfies) Then ' defensive check to ensure the need exists as an activity collection
            Dim category As Collection = CType(ToDo.Item(Satisfies), Collection) ' get the collection of activities that satisfy that need
            Dim i As Integer = getDx(category.Count) ' use our dice to get a random index
            Return CStr(category(i)) ' return the random chose object
        Else ' don't have that need in our list
            Debug.WriteLine("Error: MiniDB unable to meet need " & Satisfies)
            Return "" ' always return something
        End If
    End Function

    Public Function ActivityList() As Collection
        Dim alist As New Collection
        Dim activity As String
        For Each activity In ActivityNames
            alist.Add(activity, activity)
        Next
        Return alist ' get all the activities in a list
    End Function


End Class
