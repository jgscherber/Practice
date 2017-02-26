Imports MonsterAI

Public Class FeelHappy
    Inherits BasicState

    Public Sub New()
        Dim Txn As BasicTransition
        Txn = New SeePlayerHighHealthTxn()
        Txn.Initialize(GetType(FeelAngry).Name)
        MyTransitions.Add(Txn) ' add transitionto angry state
        Txn = New LowHealthTxn()
        Txn.Initialize(GetType(FeelAfraid).Name)
        MyTransitions.Add(Txn) ' add transition to afraid state

    End Sub

    Public Overrides Sub Entry(World As Monster)
        World.Say("I feel happy now")
    End Sub

    Public Overrides Sub ExitFunction(World As Monster)

    End Sub

    Public Overrides Sub Update(World As Monster)
        World.BackColor = Color.LightGreen
    End Sub
End Class
