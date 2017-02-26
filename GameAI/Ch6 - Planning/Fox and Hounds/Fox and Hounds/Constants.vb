Public Module Constants
    Public Const UNREACHABLE As Integer = 64
    Public Const TRAPPED As Integer = 127

    Public Class SquareData
        Public Holds As Checker
        Public Kind As SquareColor
        Public Steps As Integer
    End Class

    Public Enum Checker As Integer ' whats on top of the button
        None
        Fox
        Hound
    End Enum

    Public Enum SquareColor As Integer ' how should the square be colored
        Black
        White
        Green
    End Enum

End Module
