Imports MonsterAI

Public Class FeelAngry
    Inherits BasicState

    Public Sub New()
        Dim Txn As BasicTransition

        Txn = New LowHealthTxn()
        Txn.Initialize(GetType(FeelAfraid).Name)
        MyTransitions.Add(Txn)

        Txn = New NoPlayersTxn()
        Txn.Initialize(GetType(FeelHappy).Name)
        MyTransitions.Add(Txn)
    End Sub
    Public Overrides Sub Entry(World As Monster)
        World.Say("I feel so angry!")
    End Sub

    Public Overrides Sub ExitFunction(World As Monster)

    End Sub

    Public Overrides Sub Update(World As Monster)
        World.BackColor = Color.Pink
    End Sub
End Class
