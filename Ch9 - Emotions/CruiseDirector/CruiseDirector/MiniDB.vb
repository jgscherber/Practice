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


    End Function


End Class
