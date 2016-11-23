Imports MonsterAI

Public Class HidingState
    ' Typing in the Inherits ... code automatically populates class w/ import
    ' statement and all the functions that we declared as MustOVeride in the
    ' superclass BasicState
    Inherits BasicState

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
