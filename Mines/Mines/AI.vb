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

        Next


    End Sub


End Module
