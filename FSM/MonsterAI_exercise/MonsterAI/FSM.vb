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
            ' TransitionCheck is a method of the state class
            nextStateName = stateObj.TransitionCheck(World)
            ' Check if there is a transition
            If nextStateName <> "" Then
                If States.Contains(nextStateName) Then
                    ' Leave current state
                    stateObj.ExitFunction(World)
                    ' get the next state from our States collections
                    stateObj = States(nextStateName)
                    currentStateName = nextStateName
                    ' Enter and run the new state
                    stateObj.Entry(World)
                    stateObj.Update(World)

                Else
                    ' Catch if we forgot to add a state to the machine
                    ' or forgot to remove one from the transitions
                    World.Say("Error: State" & stateObj.GetType.Name &
                              " wants to transition to " & nextStateName &
                              " but that state is not in the machine!")
                End If
            Else
                ' If we don't need to transition, only update
                stateObj.Update(World)

            End If
        Else
            ' In case we somehow start in a state not in the machine
            World.Say("Error: Current state " & currentStateName _
                      & " is not found in the machine")
        End If
    End Sub


End Class
