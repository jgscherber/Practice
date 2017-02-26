Module AI
#Region "Public Interface"
    Public Function MoveFox(GS As GameState) As GameState
        Debug.WriteLine("")
        Debug.WriteLine("Move #" & (GS.MoveCount + 1).ToString)
        Debug.WriteLine("Move Fox.")

        ' Return Fox1(GS) ' code on the CD
        Return Fox2(GS, 1, True)
    End Function

    Public Function MoveHounds(GS As GameState) As GameState
        Debug.WriteLine("")
        Debug.WriteLine("Move #" & (GS.MoveCount + 1).ToString)
        Debug.WriteLine("Move Hounds.")

        ' Return Hounds1(GS) ' code on the CD
        Return Hounds2(GS, 1, True)
    End Function
#End Region

#Region "Internal Stuff"
    Private Sub AddGameStateKeepSorted(newGS As GameState, SortedMoves As Collection)
        Dim i As Integer
        Dim GS As GameState
        For i = 1 To SortedMoves.Count
            GS = CType(SortedMoves(i), GameState)
            If newGS.GameRank < GS.GameRank Then
                SortedMoves.Add(newGS, Nothing, i)
                Return
            End If
        Next i
        SortedMoves.Add(newGS)
    End Sub

    ' Called by Fox2 to compare moves
    Private Function BetterFoxMove(Result As GameState, BetterThan As GameState) As Boolean
        If BetterThan Is Nothing Then Return True

        ' smaller rank is better for the Fox
        ' grab the earliest good move, first that reduces move count
        If Result.GameRank < UNREACHABLE And BetterThan.GameRank < UNREACHABLE Then
            If Result.MoveCount < BetterThan.MoveCount Then
                Debug.WriteLine("Fox: Result of " & Result.GameRank.ToString &
                                " is better than " & BetterThan.GameRank.ToString)
                Return True
            Else
                ' placeholder for debug statement
            End If
        End If

        If Result.GameRank > BetterThan.GameRank Then Return False

        If Result.GameRank < BetterThan.GameRank Then
            Debug.WriteLine("Fox: Result of " & Result.GameRank.ToString & " is better than " _
                            & BetterThan.GameRank.ToString)
            Return True
        Else
            If Result.GameRank < UNREACHABLE Then
                If Result.MoveCount < BetterThan.MoveCount Then
                    Return True
                End If
            Else
                If Result.MoveCount > BetterThan.MoveCount Then
                    Return True
                End If
            End If
        End If
        Return False ' default value
    End Function
    ' Called by Hound2 to compare moves
    Private Function BetterHoundsMove(Result As GameState, BetterThan As GameState) As Boolean
        If BetterThan Is Nothing Then Return True

        If BetterThan.GameRank >= UNREACHABLE And Result.GameRank >= UNREACHABLE Then ' are they both good moves?
            If Result.MoveCount < BetterThan.MoveCount Then
                Return True
            Else
                Return False
            End If
        End If

        If Result.GameRank = BetterThan.GameRank Then
            If Result.GameRank >= UNREACHABLE Then
                If Result.MoveCount < BetterThan.MoveCount Then
                    Return True
                End If
            Else
                If Result.MoveCount > BetterThan.MoveCount Then
                    Return False
                End If
            End If
        End If
        Return (Result.GameRank > BetterThan.GameRank)
    End Function
#End Region

#Region "With Lookahead"
    Private Function Fox2(GS As GameState, depth As Integer, WantMove As Boolean) As GameState

        If GS.GameRank = 0 Or GS.GameRank = TRAPPED Then ' check if game is already over
            Debug.WriteLine("Fox2: Game over, not moving")
            Return GS
        End If

        Dim Candidate As GameState = ConsultFoxBook(GS)
        If Candidate IsNot Nothing Then Return Candidate


        Dim ss As Integer
        Dim SortedMoves As New Collection
        For Each ss In Moves.Neighbors(GS.FoxAt)

            If Not GS.HasChecker(ss) Then ' move isn't blocked
                'Debug.WriteLine(GS.HasChecker(ss))
                ' potential move, store it
                AddGameStateKeepSorted(GS.ProposeFoxTo(ss), SortedMoves)
            End If
        Next ss

        ' if no move, return existing game (shouldn't ever happen)
        If SortedMoves.Count = 0 Then
            Debug.WriteLine("Fox2: not trapped, but no moves")
            Return GS
        End If

        'Dim Candidate As GameState 
        Candidate = CType(SortedMoves(1), GameState)

        'is freedom reachable
        If GS.GameRank < UNREACHABLE Then
            Return Candidate
        Else

            If WantMove And SortedMoves.Count = 1 Then
                Return Candidate
            End If

            Dim BestCurrentMove As GameState = Nothing
            Dim BestFutureResult As GameState = Nothing

            For Each Candidate In SortedMoves
                Dim FutureGame As GameState = FoxLookAhead(Candidate, depth)
                If BetterFoxMove(FutureGame, BestFutureResult) Then
                    BestCurrentMove = Candidate
                    BestFutureResult = FutureGame
                End If
            Next Candidate

            If BestCurrentMove IsNot Nothing Then
                If WantMove Then
                    Return BestCurrentMove
                Else
                    Return BestFutureResult
                End If
            End If
        End If
        Debug.WriteLine("############### Fox2: Hit Default Return")
        Return CType(SortedMoves(1), GameState)
    End Function

    Private Function FoxLookAhead(GS As GameState, depth As Integer) As GameState
        If GS.GameRank < UNREACHABLE Then
            Debug.WriteLine(" *********** FoxLookAhead: line is broken, shouldn't need to look")
            Return GS
        End If

        If depth > 5 Then ' if recursive depth is more than 5, stop looking
            Return GS
        End If

        ' im not moving if i already won or lost
        If GS.GameRank = 0 Or GS.GameRank = TRAPPED Then Return GS

        Dim TheirMove As GameState = Hounds2(GS, depth, True)
        If TheirMove.GameRank < UNREACHABLE Then
            Return TheirMove
        End If
        Return Fox2(TheirMove, depth + 1, False) ' recursive call
    End Function

    Private Function Hounds2(GS As GameState, depth As Integer, WantMove As Boolean) As GameState
        If GS.GameRank = 0 Or GS.GameRank = TRAPPED Then ' game over
            Return GS
        End If

        Dim ss As Integer
        Dim SortedMoves As New Collection
        Dim i As Integer
        Dim Hounds() As Integer = GS.HoundsAt()
        For i = 0 To 3
            For Each ss In Moves.MovesDown(Hounds(i))
                If Not GS.HasChecker(ss) Then ' if spot isn't blocked
                    AddGameStateKeepSorted(GS.ProposeHoundTo(i, ss), SortedMoves)
                End If
            Next ss
        Next i

        If SortedMoves.Count = 0 Then ' if no valid moves
            Return GS ' return current GameState
        End If

        Dim Candidate As GameState
        Candidate = CType(SortedMoves(SortedMoves.Count), GameState)
        If Candidate.GameRank >= UNREACHABLE Then
            If GS.GameRank < UNREACHABLE Then
                Debug.WriteLine(depth.ToString & "Hounds found a way to win or restore the line")
            End If
            Return Candidate
        End If

        If GS.GameRank >= UNREACHABLE Then
            Return Candidate
        End If

        Dim BestCurrentMove As GameState = Nothing
        Dim BestFutureResult As GameState = Nothing

        For Each Candidate In SortedMoves
            Dim FutureGame As GameState = HoundsLookAhead(Candidate, depth)
            If BetterHoundsMove(FutureGame, BestFutureResult) Then
                BestCurrentMove = Candidate
                BestFutureResult = FutureGame
            End If
        Next Candidate

        If BestCurrentMove IsNot Nothing Then
            If WantMove Then
                Return BestCurrentMove
            Else
                Return BestFutureResult
            End If
        End If
        Debug.WriteLine("#################### Hounds2: Hit default Return")
        Return CType(SortedMoves(SortedMoves.Count), GameState)
    End Function

    Private Function HoundsLookAhead(GS As GameState, depth As Integer) As GameState
        If GS.GameRank > UNREACHABLE Then
            Debug.WriteLine("************* HoundsLookAhead: line is good, shouldn't be looking ahead")
            Return GS
        End If

        If depth > 6 Then
            Return GS
        End If

        If GS.GameRank = 0 Or GS.GameRank = TRAPPED Then Return GS ' game already won/lost

        Dim TheirMove As GameState = Fox2(GS, depth, True)
        If TheirMove.GameRank <= 1 Then
            Return TheirMove
        End If
        Return Hounds2(TheirMove, depth + 1, False)
    End Function

#End Region

#Region "Book of Moves"
    Private Function ConsultFoxBook(GS As GameState) As GameState
        If GS.MoveCount > 8 Then ' only applicable for first 8 moves
            Return Nothing
        End If

        Dim bestMove As Byte = 64
        Dim ss As Byte ' why Bytes and not integer
        For Each ss In Moves.Neighbors(GS.FoxAt)
            If Not GS.HasChecker(ss) Then
                If ss < bestMove Then bestMove = ss
            End If
        Next ss
        Return GS.ProposeFoxTo(bestMove)
    End Function
#End Region

End Module
