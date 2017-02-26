Imports MonsterAI

Public Class FeelAfraid
    Inherits BasicState

    Public Sub New()
        Dim Txn As BasicTransition

        Txn = New SeePlayerHighHealthTxn()
        Txn.Initialize(GetType(FeelAngry).Name)
        MyTransitions.Add(Txn)

        Txn = New HighHealthTxn()
        Txn.Initialize(GetType(FeelHappy).Name)
        MyTransitions.Add(Txn)


    End Sub

    Public Overrides Sub Entry(World As Monster)
        World.Say("I feel afraid!")
    End Sub

    Public Overrides Sub ExitFunction(World As Monster)

    End Sub

    Public Overrides Sub Update(World As Monster)
        World.BackColor = Color.LightGray
    End Sub
End Class
