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
        Next i
    End Sub
#End Region
End Module
