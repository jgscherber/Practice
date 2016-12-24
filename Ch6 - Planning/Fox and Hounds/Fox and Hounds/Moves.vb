Public Module Moves ' Public allows the other parts of the project to access code in this module

    Public MovesUp(31) As Collection ' indices are square numbers, each spot holds a collection of those types of moves
    Public MovesDown(31) As Collection ' e.g index 0: down-moves possible from square 0
    Public Neighbors(31) As Collection ' edge squares will have limited moves assigned to them

    ' Initialization could be done manually (200 different options)
    Public Sub InitMoves()
        Dim row As Integer
        Dim col As Integer

        Dim ss As Integer ' ss: subscript
        Dim finalss As Integer

        Dim offset As Integer

        ' put up moves in first so that Fox perfers them
        For row = 0 To 7
            offset = row Mod 2 ' even and odd rows have different relations between squares
            For col = 0 To 3
                ss = row * 4 + col
                MovesUp(ss) = New Collection ' put a collection in everyspot, it might be empty
                MovesDown(ss) = New Collection
                Neighbors(ss) = New Collection

                If offset = 0 Then ' 0 is an even row
                    If row > 0 Then
                        If col <> 3 Then ' up and right spaces
                            finalss = ss - 3
                            MovesUp(ss).Add(finalss, finalss.ToString) ' collection keys must be strings
                            Neighbors(ss).Add(finalss, finalss.ToString)
                        End If

                        finalss = ss - 4
                        MovesUp(ss).Add(finalss, finalss.ToString)
                        Neighbors(ss).Add(finalss, finalss.ToString)
                    End If

                    finalss = ss + 4
                    MovesDown(ss).Add(finalss, finalss.ToString)
                    Neighbors(ss).Add(finalss, finalss.ToString)

                    If col <> 3 Then ' down and right spaces
                        finalss = ss + 5
                        MovesDown(ss).Add(finalss, finalss.ToString)
                        Neighbors(ss).Add(finalss, finalss.ToString)
                    End If
                Else ' not 0 is an even row
                    If col <> 0 Then
                        finalss = ss - 5
                        MovesUp(ss).Add(finalss, finalss.ToString)
                        Neighbors(ss).Add(finalss, finalss.ToString)
                    End If

                    finalss = finalss - 4
                    MovesUp(ss).Add(finalss, finalss.ToString)
                    Neighbors(ss).Add(finalss, finalss.ToString)

                    If row < 7 Then
                        finalss = ss + 4
                        MovesDown(ss).Add(finalss, finalss.ToString)
                        Neighbors(ss).Add(finalss, finalss.ToString)
                        If col <> 0 Then
                            finalss = ss + 3
                            MovesDown(ss).Add(finalss, finalss.ToString)
                            Neighbors(ss).Add(finalss, finalss.ToString)
                        End If
                    End If
                End If
            Next col
        Next row
    End Sub


End Module
