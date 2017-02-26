Imports MonsterAI

Public Class AttackState

    Inherits BasicState

    Public Sub New()
        ' Subclasses can occupy type of superclass
        ' No "New" before BasicTransition so no object was instantiate
        ' (BasicTransition set to MustInherit, can't be instantiated by itself)
        Dim Txn As BasicTransition

        ' Order is important: React to players first
        ' Evaluated by FSN in the oreder they are added to MyTransitions
        ' (ordered structure)
        Txn = New NoPlayersTxn
        ' Transtion to hiding
        Txn.Initialize(GetType(HidingState).Name)
        MyTransitions.Add(Txn)

        ' Transition to flee
        Txn = New LowHealthTxn
        Txn.Initialize(GetType(FleeState).Name)
        MyTransitions.Add(Txn)


    End Sub

    Public Overrides Sub Entry(World As Monster)
        World.Say("Grab weapon and shield!")
    End Sub

    Public Overrides Sub ExitFunction(World As Monster)
        World.Say("I better put my weapon and shield away.")
    End Sub

    Public Overrides Sub Update(World As Monster)
        World.Say("Keep attack!")
        'World.BackColor = Color.Pink
    End Sub
End Class

' Two transition criteria for attack state
Public Class NoPlayersTxn
    Inherits BasicTransition

    Public Overrides Function ShouldTransition(World As Monster) As String
        ' World (monster) returns boolean, depending on how detecting a player is done
        If Not World.DetectsPlayers Then
            Return NextState
        Else
            Return ""
        End If
    End Function
End Class

Public Class LowHealthTxn
    Inherits BasicTransition

    Public Overrides Function ShouldTransition(World As Monster) As String
        If Not World.GoodHealth Then
            Return NextState
        Else
            Return ""
        End If
    End Function
End Class
