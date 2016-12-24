Public Class GameState
    Dim Fox As Integer
    Dim Hounds(3) As Integer

    Dim Turn As Integer
    Dim Rank As Integer
    Dim Squares(31) As SquareData

#Region "Class New"
    Public Sub New() ' setup a new game
        Dim i As Integer

        Fox = 30 ' set fox location on board
        For i = 0 To 3 ' set the 3 hounds' locations
            Hounds(i) = i
        Next i

        Turn = 0
        For i = 0 To 31 ' create all the SquareData objects
            Squares(i) = New SquareData
        Next
        Call ColorMe() ' make square visible
    End Sub
#End Region
#Region "Internal Stuff"
    Protected Sub ColorMe()
        Dim StateSquare As SquareData
        Dim i As Integer
        Dim ss As Integer

        For Each StateSquare In Squares
            StateSquare.Holds = Checker.None
            StateSquare.Kind = SquareColor.Black
            StateSquare.Steps = UNREACHABLE
        Next

        ' Put the fox and hounds in their square
        Squares(Fox).Holds = Checker.Fox
        For i = 0 To 3
            Squares(Hounds(i)).Holds = Checker.Hound
        Next

        For i = 0 To 3 ' top row is always green after the hounds move off
            StateSquare = Squares(i)
            If StateSquare.Holds <> Checker.Hound Then
                StateSquare.Kind = SquareColor.Green
                StateSquare.Steps = 0
            End If
        Next

        For i = 4 To 31
            StateSquare = Squares(i)

            If StateSquare.Holds <> Checker.Hound Then ' if no hound on the square
                Dim AmGreen As Boolean = True
                For Each ss In Moves.MovesUp(i)
                    AmGreen = AmGreen And (Squares(ss).Kind = SquareColor.Green) ' and all the squares above are green
                Next
                If AmGreen Then ' then the square is also green
                    StateSquare.Kind = SquareColor.Green
                    StateSquare.Steps = 0
                End If
            End If
        Next

        Dim NeedsMorePasses As Boolean = True
        While NeedsMorePasses
            NeedsMorePasses = False ' done unless need to go through again
            For i = 4 To 31
                StateSquare = Squares(i)




            Next
        End While







    End Sub
#End Region


End Class
