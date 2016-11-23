Public Class FSM
    ' Collection functions like a Python dictionary: key-value pairs
    Dim States As New Collection
    Dim currentStateName As String

    Public Sub LoadState(state As BasicState)
        Dim stateName As String
        stateName = state.GetType.Name
        If States.Count = 0 Then
            currentStateName = stateName
        End If

        If Not States.Contains(stateName) Then
            ' state is the state object, stateName is name of the state object's class (subclass of the BasicState superclass)
            States.Add(state, stateName)
        End If

    End Sub

    Public Sub RunAI(World As Monster)
        ' currentStateName is a global variable w/in the class
        If States.Contains(currentStateName) Then
            Dim stateObj As BasicState
            stateObj = States(currentStateName)
            Dim nextStateName As String
            nextStateName = stateObj.TransitionCheck(World)








        End If
    End Sub


End Class
