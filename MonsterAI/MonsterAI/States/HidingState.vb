Imports MonsterAI

Public Class HidingState
    ' Typing in the Inherits ... code automatically populates class w/ import
    ' statement and all the functions that we declared as MustOVeride in the
    ' superclass BasicState ... import statement isn't necessary, already in
    ' MonsterAI namespace (same project)
    Inherits BasicState
    ' runs when the sclass is instantiated; like Python __init__
    Public Sub New()
        Dim Txn As BasicTransition
        ' Creates the exit transition when the state is entered into for the
        ' first time
        Txn = New SeePlayerHighHealthTxn

    End Sub

    Public Overrides Sub Entry(World As Monster)
        ' Only code to show it's entered, real game would have it perform
        ' more complex tasks (moving to a "hidden" location, etc.)
        World.Say("This looks like a great hiding spot")
    End Sub

    Public Overrides Sub ExitFunction(World As Monster)
        World.Say("I can't stay hiding here!")
    End Sub

    Public Overrides Sub Update(World As Monster)
        World.Say("Shhh! I'm hiding.")
    End Sub
End Class

' Storing transitions in the state that it leaves from
' i.e. all transitions out of this state
Public Class SeePlayerHighHealthTxn
    Inherits BasicTransition

    ' NextState is defined in the parent class
    Public Overrides Function ShouldTransition(World As Monster) As String
        If World.DetectsPlayers And World.GoodHealth Then
            Return NextState
        Else
            Return ""
        End If
    End Function
End Class
