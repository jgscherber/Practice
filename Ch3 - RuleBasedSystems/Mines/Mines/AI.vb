Module AI


    Public Function BasicStatsAndBlanks(ByVal RevealedSquare As Square _
            , ByVal Neighbors As Collection _
            , ByRef sees As Integer, ByRef flags As Integer _
            , ByRef blanks As Integer) As Collection
        Dim BlankSquares As New Collection
        If RevealedSquare.Text <> "" Then
            sees = CInt(RevealedSquare.Text) ' assigns the number of nearby mines to a square
        End If

        Dim Sq As Square
        For Each Sq In Neighbors ' neighbors passed in as an argument
            If Not Sq.IsRevealed Then ' only hidden squares
                Select Case Sq.Text
                    Case ""
                        blanks += 1
                        BlankSquares.Add(Sq, PlayingField.KeyFromRC(Sq.R, Sq.C))
                    Case Square.ShowFlag
                        flags += 1
                End Select

            End If
        Next
        Return BlankSquares
    End Function

    ' doesn't need to return anything because it passes SimonSays and SquaresList by reference
    ' (changes their memory location directly)
    Public Sub TwoSquareMatcher(RevealedSquare As Square _
                                , Helpers As Collection _
                                , ByRef SimonSays As BasicRule.PossibleActions _
                                , ByRef SquaresList As Collection)
        SquaresList.Clear() ' passed by reference so might already have values, clear it in case we don't find any new moves
        Dim theField As PlayingField = RevealedSquare.Parent ' get reference to playing field

        Dim Neighbors As Collection = theField.NearNeighbors(RevealedSquare.R, RevealedSquare.C) ' same data, maybe like python lists, need new reference?

        Dim sees As Integer = 0
        Dim flags As Integer = 0
        Dim blanks As Integer = 0
        Dim BlankSquares As Collection

        BlankSquares = BasicStatsAndBlanks(RevealedSquare, Neighbors, sees,
                                            flags, blanks) ' get info about nearby 

        If blanks = 0 Then ' blanks set byref in BasicStatsAndBlanks
            Return ' no blanks nothing to do
        End If

        Dim Helper As Square
        For Each Helper In Helpers

            If Not Helper.IsRevealed Then Continue For ' if the helper isn't revealed, it can't help us, go to the next

            Dim TheirNeighbors As Collection = theField.NearNeighbors(Helper.R, Helper.C) ' get neighbors of current neighbor square
            Dim theySee As Integer = 0
            Dim theirFlags As Integer = 0
            Dim theirBlanks As Integer = 0
            Dim TheirBlankSquares As Collection

            TheirBlankSquares = BasicStatsAndBlanks(Helper, TheirNeighbors, theySee, theirFlags, theirBlanks) ' get info for the current neighbor
            If theirBlanks = 0 Then Continue For ' if they lack blanks, can't help

            Dim PrivateBlanks As New Collection
            Dim commonBlankCount As Integer = 0 ' forgot to define as 0 on creation (but should default to 0?)

            Dim Sq As Square

            For Each Sq In BlankSquares
                Dim sqKey As String = theField.KeyFromRC(Sq.R, Sq.C)
                If TheirBlankSquares.Contains(sqKey) Then
                    commonBlankCount += 1
                Else
                    PrivateBlanks.Add(Sq, sqKey)
                End If
            Next
            If commonBlankCount = 0 Then Continue For ' no shared blanks, move onto next neighbor, nothing can be learned
            If PrivateBlanks.Count = 0 Then Continue For ' no blanks that are private, nothing can be done

            ' If there are some common blanks and some private blanks, might be able to do something!

            Dim theirPrivateBlankCount As Integer = theirBlanks - commonBlankCount
            Dim minCommonMines As Integer = theySee - theirPrivateBlankCount - theirFlags ' how many mines might there be?
            If minCommonMines < 0 Then minCommonMines = 0 ' can't be less than 0 ...

            Dim minCommonClear As Integer = theirBlanks - (theySee - theirFlags) - theirPrivateBlankCount
            If minCommonClear < 0 Then minCommonClear = 0
            ' wasn't clearing negative, ending loop instead, maybe was fucking up the subtraction

            If minCommonClear = 0 And minCommonMines = 0 Then Continue For ' both zero, no information

            If minCommonMines > 0 Then
                If minCommonMines = sees - flags Then ' all mines must be in the common mines, private blanks must be ok!
                    SimonSays = BasicRule.PossibleActions.ClickBlanks
                    SquaresList = PrivateBlanks ' passed byref
                    Return ' found a move, can be done
                End If
            End If

            If minCommonClear > 0 Then
                If blanks - minCommonClear = sees - flags Then ' common blanks account for all clear, privats must be all mines
                    SimonSays = BasicRule.PossibleActions.BlanksToFlags
                    SquaresList = PrivateBlanks
                    Return
                End If
            End If

        Next
        
    End Sub

#Region "Book of Moves"

    Public Function BookFirstMove(FirstSq As Square, SecondSq As Square, theField As PlayingField) As Integer
        If FirstSq.IsRevealed Then Return 0 ' has the square already been clicked?
        If FirstSq.Text <> "" Then Return 0 ' avoid flagged squares
        If SecondSq.Text <> "" Then Return 0 ' 2nd square also can't be flagged

        Dim Sq As Square
        For Each Sq In theField.NearNeighbors(FirstSq.R, FirstSq.C)
            If Sq.IsRevealed() Then Return 0 ' don't click any with revealed neighbors
        Next Sq

        theField.MoreThoughts("Book First Move attempting R" & FirstSq.R.ToString &
                              "C" & FirstSq.C.ToString)
        Call FirstSq.LeftClick()
        Return 1 ' one move done
    End Function

    Public Function BookSecondMove(FirstSq As Square, SecondSq As Square, theField As PlayingField) As Integer
        If FirstSq.Text <> "1" Then Return 0 ' only continue if minimal risk

        Dim Sq As Square
        For Each Sq In theField.NearNeighbors(FirstSq.R, FirstSq.C)
            If Sq.IsRevealed() Then Return 0
        Next Sq

        theField.MoreThoughts("Book SEcond Move attempting R" &
                              SecondSq.R.ToString & "C" & SecondSq.C.ToString)
        Call SecondSq.LeftClick()
        Return 1
    End Function
#End Region

End Module
