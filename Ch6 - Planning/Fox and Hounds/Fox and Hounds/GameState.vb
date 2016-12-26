Public Class GameState
    Dim Fox As Integer
    Dim Hounds(3) As Integer

    Dim Turn As Integer
    Dim Rank As Integer
    Dim Squares(31) As SquareData

#Region "Class New"
    ' setup a new game
    Public Sub New()
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

        ' Still unsure what this is doing... looking for shortest path??
        Dim NeedsMorePasses As Boolean = True
        While NeedsMorePasses
            NeedsMorePasses = False ' done unless need to go through again
            For i = 4 To 31
                StateSquare = Squares(i)
                If StateSquare.Holds <> Checker.Hound Then
                    For Each ss In Moves.Neighbors(i)
                        If Squares(ss).Steps + 1 < StateSquare.Steps Then ' how is steps defined??
                            StateSquare.Steps = Squares(ss).Steps + 1
                            StateSquare.Kind = SquareColor.White
                            NeedsMorePasses = True
                        End If
                    Next ss
                End If
            Next i
        End While

        ' Is the fox trapped?
        StateSquare = Squares(Fox) ' StateSquare changed to whatever is currently being worked on
        Dim CanMove As Boolean = False
        For Each ss In Moves.Neighbors(Fox)
            If Squares(ss).Holds <> Checker.Hound Then
                CanMove = True
            End If
        Next ss

        ' Set the game rank
        If Not CanMove Then ' if no possible moves available to the fox, it's trapped!
            StateSquare.Steps = TRAPPED
            Rank = TRAPPED
        Else ' it can move
            If StateSquare.Steps < UNREACHABLE Then
                Rank = StateSquare.Steps
            Else
                ' Rank = TRAPPED - NaiveBlackCount()
                Rank = TRAPPED - BetterBlackCount()
            End If
        End If
    End Sub
    ' count the number of black squares (suboptimal)
    Private Function NaiveBlackCount() As Integer
        Dim NBC As Integer = 0
        For i = 0 To 31
            If Squares(i).Kind = SquareColor.Black Then NBC = NBC + 1
        Next
        Return NBC
    End Function
    ' optimal
    Private Function BetterBlackCount() As Integer
        Dim BN As New Collection
        Dim stopAt As Integer = 1
        Dim startAt As Integer = 1
        Dim ss As Integer
        Dim pbs As Integer

        Dim i As Integer
        BN.Add(Fox, Fox.ToString) ' add the foxes location
        While startAt <= stopAt
            For i = startAt To stopAt
                ss = CInt(BN(i))
                For Each pbs In Moves.Neighbors(ss)
                    If Squares(pbs).Holds = Checker.None Then ' ok space to move to
                        If Not BN.Contains(pbs.ToString) Then ' check if it's already in our collection
                            BN.Add(pbs, pbs.ToString)
                        End If
                    End If
                Next pbs
            Next i
            startAt = stopAt + 1
            stopAt = BN.Count ' will increment if one is added
        End While
        Return BN.Count + 4 ' add 4 for the hound squares
    End Function

#End Region

#Region "Public Methods"
    ' make the board
    Public Sub MarkButtons(Board() As Button)
        Dim i As Integer
        Dim BoardSquare As Button
        Dim StateSquare As SquareData

        For i = 0 To 31
            BoardSquare = Board(i)
            StateSquare = Squares(i)

            Select Case StateSquare.Kind
                Case SquareColor.Black
                    BoardSquare.BackColor = Color.Black ' change button attribute to match game attribute
                Case SquareColor.Green
                    BoardSquare.BackColor = Color.Green
                Case SquareColor.White
                    BoardSquare.BackColor = Color.White
            End Select
            Select Case StateSquare.Holds
                Case Checker.Fox
                    BoardSquare.Text = "Fox"
                    ' Fox square gets special coloring
                    Select Case StateSquare.Kind
                        Case SquareColor.White
                            BoardSquare.BackColor = Color.LightPink
                        Case SquareColor.Black
                            BoardSquare.BackColor = Color.Red
                        Case SquareColor.Green
                            BoardSquare.BackColor = Color.LightGreen
                    End Select
                Case Checker.Hound
                    BoardSquare.Text = "Hnd"
                    BoardSquare.BackColor = Color.DarkGray
                Case Checker.None
                    Select Case StateSquare.Kind
                        Case SquareColor.Black, SquareColor.Green
                            BoardSquare.Text = ""
                        Case SquareColor.White
                            BoardSquare.Text = Squares(i).Steps.ToString
                    End Select
            End Select
        Next i
    End Sub

    ' only fox and hound pieces can move, good to know where they're at
    Public Function FoxAt() As Integer
        Return (Fox)
    End Function
    Public Function HoundsAt() As Integer()
        Dim Locations(3) As Integer
        Dim i As Integer
        For i = 0 To 3
            Locations(i) = Hounds(i)
        Next
        Return Locations
    End Function
    ' can only move to empty squares
    Public Function HasChecker(ss As Integer) As Boolean
        If ss = Fox Then Return True
        Dim i As Integer
        For i = 0 To 3
            If ss = Hounds(i) Then Return True
        Next
        Return False
    End Function

    ' AI methods
    ' Fox wants 0, Hounds want TRAPPED (127)
    Public Function GameRank() As Integer
        Return Rank
    End Function
    ' turn count
    Public Function MoveCount() As Integer
        Return Turn
    End Function


#End Region

End Class
