Imports MonsterAI

Public Class AttackState
    Inherits BasicState

    Public Overrides Sub Entry(World As Monster)
        World.Say("Grab weapon and shield!")
    End Sub

    Public Overrides Sub ExitFunction(World As Monster)
        World.Say("I better put my weapon and shield away.")
    End Sub

    Public Overrides Sub Update(World As Monster)
        World.Say("Keep attack!")
    End Sub
End Class
