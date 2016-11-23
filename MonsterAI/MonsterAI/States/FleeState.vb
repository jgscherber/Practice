Imports MonsterAI

Public Class FleeState
    Inherits BasicState

    Public Overrides Sub Entry(World As Monster)
        World.Say("Feet don't fail me now!")
    End Sub

    Public Overrides Sub ExitFunction(World As Monster)
        World.Say("I better slow down.")
    End Sub

    Public Overrides Sub Update(World As Monster)
        World.Say("Keep running!")
    End Sub
End Class
