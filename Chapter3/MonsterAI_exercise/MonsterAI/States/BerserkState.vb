Imports MonsterAI

Public Class BerserkState
    Inherits BasicState

    Public Sub New()
        Dim Txn As BasicTransition
        ' Will stay in Berserk until either full enough health to return to attacking
        ' or player leaves. Will never flee

        ' From Berserk to hiding
        Txn = New NoPlayersTxn
        Txn.Initialize(GetType(HidingState).Name)
        MyTransitions.Add(Txn)

        'From Berserk to attacking
        Txn = New HighHealthTxn
        Txn.Initialize(GetType(AttackState).Name)
        MyTransitions.Add(Txn)

    End Sub

    Public Overrides Sub Entry(World As Monster)
        World.Say("This is impossible!")
    End Sub

    Public Overrides Sub ExitFunction(World As Monster)
        World.Say("You better run!")
    End Sub

    Public Overrides Sub Update(World As Monster)
        World.Say("You will not defeat me!")
    End Sub
End Class

