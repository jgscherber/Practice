Public MustInherit Class BasicState
    ' MustInherit Class cannot be instantiated by itself, only inherited
    ' (e.g. cats and dogs exist as objects, but mammals doesn't)

    ' Child classes must have a member with this "signature"
    ' Specification will be unique to each subclass
    Public MustOverride Sub Entry(World As Monster)
    Public MustOverride Sub Update(World As Monster)
    Public MustOverride Sub ExitFunction(World As Monster)

    ' Protected only available to subclasses
    Protected MyTransitions As New Collection

    ' States check for transitions
    ' All states will use same method for checking transition, can exist in superclass
    Public Function TransitionCheck(World As Monster) As String
        ' Can hold an subclass in the type of it's superclass (?)
        Dim Txn As BasicTransition
        ' Need to store the name of any state returned
        Dim nextState As String
        ' Loop through collection created above, need to initialize the dummy variable too (Txn)
        For Each Txn In MyTransitions
            ' ShouldTransition will be defined in each state's subclass
            nextState = Txn.ShouldTransition(World)
            ' If the ShouldTransition doesn't return a state to transition-to, don't do anything
            If nextState <> "" Then
                Return (nextState)
            End If
        Next
        Return ("")
    End Function


End Class
