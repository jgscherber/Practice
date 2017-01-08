Imports MonsterAI

Public Class FleeState
    Inherits BasicState

    Public Sub New()
        Dim Txn As BasicTransition
        ' React to players first
        ' imported MonsterAI namespace, don't need to redefine NoPlayersTxn class
        Txn = New NoPlayersTxn
        Txn.Initialize(GetType(HidingState).Name)
        MyTransitions.Add(Txn)

        Txn = New HighHealthTxn
        Txn.Initialize(GetType(AttackState).Name)
        MyTransitions.Add(Txn)

    End Sub

    Public Overrides Sub Entry(World As Monster)
        World.Say("Feet don't fail me now!")
    End Sub

    Public Overrides Sub ExitFunction(World As Monster)
        World.Say("I better slow down.")
    End Sub

    Public Overrides Sub Update(World As Monster)
        World.Say("Keep running!")
        World.BackColor = Color.LightGray
    End Sub
End Class

Public Class HighHealthTxn
    Inherits BasicTransition

    Public Overrides Function ShouldTransition(World As Monster) As String
        If World.GoodHealth Then
            Return (NextState)
        Else
            Return ""
        End If
    End Function
End Class
