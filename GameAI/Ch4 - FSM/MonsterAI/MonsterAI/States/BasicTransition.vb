Public MustInherit Class BasicTransition

    ' Will return the name of the next state as a string
    Public MustOverride Function ShouldTransition(World As Monster) As String

    Protected NextState As String

    Public Sub Initialize(someStateName As String)
        NextState = someStateName
    End Sub



End Class
