Module Dice
    Public Function getDx(dots As Integer) As Integer
        Return CInt(Int((Rnd() * dots) + 1))
    End Function
End Module
