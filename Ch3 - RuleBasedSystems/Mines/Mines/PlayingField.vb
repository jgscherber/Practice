Public Class PlayingField


    ' global variables
    ' dim a multidimensional array with no dimensions (m,n)
    Public Field(,) As Square
    Dim NumRows, NumCols, NumMines As Integer
    Public Brains As New FrameWork
    Private Sub PlayingField_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' ordering of the rules within collections matters
        ' want certain checks made before others
        Brains.AddRule(New RuleOne)
        Brains.AddRule(New RuleTwoNear)
        Brains.AddRule(New RuleTwoFar)
    End Sub
#Region "New Game"
    Private Sub NewGame(nRows As Integer, nCols As Integer, nMines As Integer)

        Dim Sq As Square

        Me.Cursor = Cursors.WaitCursor

        If Field IsNot Nothing Then  ' if the field isn't already empty
            For Each Sq In Field
                If Sq IsNot Nothing Then ' then clear it out
                    Sq.Parent = Nothing
                End If
            Next
        End If

        'copy the passed in params to the globls
        NumRows = nRows
        NumCols = nCols

        Dim SqCnt As Integer
        SqCnt = (nRows * nCols)
        If nMines >= SqCnt Then ' Error check before assigning nMines to global NumMines
            nMines = SqCnt - 1 ' make sure there's at least 1 empty square in the game board
        End If
        NumMines = nMines

        ReDim Field(NumRows - 1, NumCols - 1) ' -1 for zero-based arrays
        Dim row, col As Integer
        ' Create all the squares
        For col = 0 To NumCols - 1
            For row = 0 To NumRows - 1
                Sq = New Square(row, col) ' give each square object info about where it is
                ' set it's location in the form
                Sq.Top = row * Sq.Height
                Sq.Left = col * Sq.Width
                Sq.Parent = Me ' the parent object of the square is the PlayingField object
                Field(row, col) = Sq ' store it in array for easy referencing
            Next
        Next

        ' Initialize the counters
        MinesLeftLabel.Text = NumMines.ToString
        MovesLeftLabel.Text = SqCnt.ToString
        ThoughtsTextBox.Clear()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ExpertButton_Click(sender As Object, e As EventArgs) Handles ExpertButton.Click
        NewGame(10, 10, 8)
    End Sub

    Public Sub InitializeSquares(ClickedRow As Integer, ClickedCol As Integer)
        ' Called by the first button click, generates the mines and accumulates the neighbors for
        ' each mined square

        ' track # of mines remaining
        Dim minesLeft As Integer = NumMines ' global variable within class

        ' numner of places left to place mines (minus the one we've already clicked) - why?
        Dim squaresLeft As Integer = (NumRows * NumCols) - 1

        ' single precision floating points
        Dim perCent, roll As Single

        Call Randomize() 'reseed the random number generator

        Dim Row, Col As Integer
        Dim Neighbors As Collection

        For Row = 0 To NumRows - 1
            For Col = 0 To NumCols - 1
                If Row <> ClickedRow Or Col <> ClickedCol Then ' -(Row = ClickedRow and Col = ClickedCol) - not the square it was called from
                    perCent = CSng(minesLeft / squaresLeft)
                    roll = Rnd() ' returns single between 0 and 1

                    If (roll < perCent) Or (minesLeft >= squaresLeft) Then ' if more squares than mines, ok to skip some
                        ' Its a mine!
                        Neighbors = NearNeighbors(Row, Col)
                        Field(Row, Col).Init(Square.HiddenValue.Mine, Neighbors) ' field is 2-dim array holding all the squares
                        minesLeft -= 1
                    Else
                        ' only need to update the neighbors if it's mine
                        ' otherwise Neighbors is empty
                        Neighbors = New Collection
                        Field(Row, Col).Init(Square.HiddenValue.Safe, Neighbors)
                    End If
                    squaresLeft -= 1 ' either placed a mine or we didn't
                Else

                    Neighbors = New Collection
                    Field(Row, Col).Init(Square.HiddenValue.Safe, Neighbors)
                End If



            Next Col
        Next Row

        ' all mines should be placed by now

        If minesLeft > 0 Then
            MsgBox(minesLeft.ToString & " Mines Leftover", MsgBoxStyle.OkOnly)
        End If

    End Sub
#End Region

#Region "Neighbor code"
    Public Function KeyFromRC(row As Integer, col As Integer)
        Return "R" & row.ToString & "C" & col.ToString
    End Function

    ' point array, can then reference the X and Y attributes of each point
    Private NearNeighborsOffSet() As Point = {
        New Point(-1, -1), New Point(-1, 0), New Point(-1, 1), New Point(0, -1),
        New Point(0, 1), New Point(1, -1), New Point(1, 0), New Point(1, 1)} ' all 8 points around our square
    Private FarNeighborOffsets() As Point = {
        New Point(-2, -2), New Point(-2, -1), New Point(-2, 0), New Point(-2, 1), New Point(-2, 2),
        New Point(-1, -2), New Point(-1, 2), New Point(0, -2), New Point(0, 2), New Point(1, -2), New Point(1, 2),
        New Point(2, -2), New Point(2, -1), New Point(2, 0), New Point(2, 1), New Point(2, 2)} ' had a duplicate point
    Public Function NearNeighbors(Row As Integer, Col As Integer) As Collection
        Return GeneralNeighbors(Row, Col, NearNeighborsOffSet)
    End Function

    Private Function GeneralNeighbors(Row As Integer, Col As Integer, Offsets() As Point) As Collection
        Dim Neighbors As New Collection

        If Field IsNot Nothing Then
            Dim Pt As Point
            Dim NeighborRow, NeighborCol As Integer

            For Each Pt In Offsets
                NeighborCol = Col + Pt.X
                NeighborRow = Row + Pt.Y
                If NeighborRow >= 0 And
                        (NeighborRow < NumRows) And
                        (NeighborCol >= 0) And
                        (NeighborCol < NumCols) Then
                    Neighbors.Add(Field(NeighborRow, NeighborCol), KeyFromRC(NeighborRow, NeighborCol))
                End If
            Next
        End If
        Return Neighbors
    End Function

    Public Function FarNeighbors(Row As Integer, Col As Integer) As Collection
        Return GeneralNeighbors(Row, Col, FarNeighborOffsets)
    End Function


#End Region

#Region "Game code"
    ' change the number of moves remaining
    Public Sub DecrementMovesLeft()
        MovesLeftLabel.Text = (CInt(MovesLeftLabel.Text) - 1).ToString
    End Sub

    Public Sub IncrementMovesLeft()
        MovesLeftLabel.Text = (CInt(MovesLeftLabel.Text) + 1).ToString
    End Sub

    ' change the number of mines remaining
    Public Sub DecrementMinesLeft() ' by placing a flag
        MinesLeftLabel.Text = (CInt(MinesLeftLabel.Text) - 1).ToString
    End Sub



    Public Sub IncrementMinesLeft() ' by removing a flag
        MinesLeftLabel.Text = (CInt(MinesLeftLabel.Text) + 1).ToString
    End Sub

    ' something bad happened and a square is calling for the game to end
    Public Sub EndGame()
        Dim Sq As Square
        For Each Sq In Field
            Sq.EndGame() ' will also be a method of the square class
        Next
    End Sub



#End Region

#Region "AI Related"
    Public Sub FirstThoughts(someThought As String)
        ThoughtsTextBox.Clear()
        MoreThoughts(someThought)
    End Sub

    Public Sub MoreThoughts(someThought As String)
        ThoughtsTextBox.AppendText(someThought)
    End Sub

    Public Sub ExecuteBook()

        Dim FirstSquares As New Collection
        Dim SecondSquares As New Collection
        ' top-left corner
        FirstSquares.Add(Field(1, 1))
        SecondSquares.Add(Field(0, 0))
        ' bottom-right corner
        FirstSquares.Add(Field(NumRows - 2, NumCols - 2))
        SecondSquares.Add(Field(NumRows - 1, NumCols - 1))
        ' bottom-left corner
        FirstSquares.Add(Field(NumRows - 2, 1))
        SecondSquares.Add(Field(NumRows - 2, 0))
        ' top-right corner
        FirstSquares.Add(Field(1, NumCols - 2))
        SecondSquares.Add(Field(0, NumCols - 1))
        Dim Col As Integer
        For Col = 1 To NumCols \ 4
            ' top row pairs
            FirstSquares.Add(Field(1, NumCols \ 2 + Col)) ' alternating back and forth unlong the midpoint
            SecondSquares.Add(Field(0, NumCols \ 2 + Col))
            FirstSquares.Add(Field(1, NumCols \ 2 - Col))
            SecondSquares.Add(Field(0, NumCols \ 2 - Col))

            ' bottom row pairs
            FirstSquares.Add(Field(NumRows - 1, NumCols \ 2 + Col))
            SecondSquares.Add(Field(NumRows, NumCols \ 2 + Col))
            FirstSquares.Add(Field(NumRows - 1, NumCols \ 2 - Col))
            SecondSquares.Add(Field(NumRows, NumCols \ 2 - Col))

        Next Col

        ' the left and right edges could be added too

        Dim pass As Integer
        For pass = 1 To 2
            Dim FirstMove As Square
            Dim SecondMove As Square
            Dim i As Integer
            For i = 1 To FirstSquares.Count
                FirstMove = FirstSquares(i)
                SecondMove = SecondSquares(i)
                If pass = 1 Then
                    If BookSecondMove(FirstMove, SecondMove, Me) > 0 Then Return
                Else
                    If BookFirstMove(FirstMove, SecondMove, Me) > 0 Then Return
                End If
            Next i
        Next pass
    End Sub

#End Region

End Class
