Public Class Map

    Public MapTilesHigh As New Dictionary(Of Integer, Integer)
    Public MapTilesMiddle As New Dictionary(Of Integer, Integer)
    Public MapTilesLow As New Dictionary(Of Integer, Integer)
    Public Accessibility As New Dictionary(Of Integer, Integer)
    Public DoorAccess As New Dictionary(Of Integer, Integer)

    Public RedPen As New Pen(Color.Red, 2)
    Public BlueBrush As New SolidBrush(Color.FromArgb(60, Color.Blue))
    Public RedBrush As New SolidBrush(Color.FromArgb(60, Color.Red))
    Public YellowBrush As New SolidBrush(Color.FromArgb(60, Color.Yellow))

    Public Sub Init()

        MapTilesHigh.Clear()
        MapTilesMiddle.Clear()
        MapTilesLow.Clear()
        Accessibility.Clear()
        DoorAccess.Clear()

        For i As Integer = 0 To CELL_COUNT - 1
            MapTilesHigh.Add(i, -1)
            MapTilesMiddle.Add(i, -1)
            MapTilesLow.Add(i, 0)
            Accessibility.Add(i, 0)
            DoorAccess.Add(i, 0)
        Next

    End Sub

    Private Sub FromData(ByVal Dic As Dictionary(Of Integer, Integer), ByVal Reader As IO.BinaryReader)

        Dic.Clear()

        For i As Integer = 0 To CELL_COUNT - 1
            Dic.Add(i, Reader.ReadInt16)
        Next

    End Sub

    Public Function FromFile(ByVal File As String) As Boolean

        Dim Reader As New IO.BinaryReader(New IO.FileStream(File, IO.FileMode.Open))

        Dim Header As Integer = Reader.ReadInt32
        If Header <> 1196446285 Then
            Return False
        End If

        Dim Version As Integer = Reader.ReadInt16()

        If (Version >= 2) Then
            Reader.ReadInt16()
            Reader.ReadInt16()
        End If

        FromData(MapTilesHigh, Reader)
        FromData(MapTilesMiddle, Reader)
        FromData(MapTilesLow, Reader)
        FromData(Accessibility, Reader)
        FromData(DoorAccess, Reader)

        Reader.Close()

        Return True

    End Function

    Private Sub ToData(ByVal Dic As Dictionary(Of Integer, Integer), ByVal Writer As IO.BinaryWriter)

        For i As Integer = 0 To CELL_COUNT - 1
            Writer.Write(CShort(Dic(i)))
        Next

    End Sub

    Public Function ToFile(ByVal File As String) As Boolean

        Dim Writer As New IO.BinaryWriter(New IO.FileStream(File, IO.FileMode.Create))

        Writer.Write(CInt(1196446285))
        Writer.Write(CShort(2))

        Writer.Write(CShort(MAP_WIDTH))
        Writer.Write(CShort(MAP_HEIGHT))

        ToData(MapTilesHigh, Writer)
        ToData(MapTilesMiddle, Writer)
        ToData(MapTilesLow, Writer)
        ToData(Accessibility, Writer)
        ToData(DoorAccess, Writer)

        Writer.Close()

        Return True

    End Function

    Public Sub DrawGrid(ByVal g As Graphics)

        For i As Integer = 0 To MAP_HEIGHT
            g.DrawLine(Pens.Blue, 0, i * TILE_WIDTH, TOTAL_WIDTH, i * TILE_WIDTH)
        Next

        For i As Integer = 0 To MAP_WIDTH
            g.DrawLine(Pens.Blue, i * TILE_WIDTH, 0, i * TILE_WIDTH, TOTAL_HEIGHT)
        Next

    End Sub

    Public Sub DrawHigh(ByVal g As Graphics)

        For i As Integer = 0 To CELL_COUNT - 1
            If MapTilesHigh(i) <> -1 Then _
                g.DrawImage(Tiles.Get(MapTilesHigh(i)), Cells.GetScreenPos(i))
        Next

    End Sub

    Public Sub DrawMiddle(ByVal g As Graphics)

        For i As Integer = 0 To CELL_COUNT - 1
            If MapTilesMiddle(i) <> -1 Then _
                g.DrawImage(Tiles.Get(MapTilesMiddle(i)), Cells.GetScreenPos(i))
        Next

    End Sub

    Public Sub DrawLow(ByVal g As Graphics)

        For i As Integer = 0 To CELL_COUNT - 1
            If MapTilesLow(i) <> -1 Then _
                g.DrawImage(Tiles.Get(MapTilesLow(i)), Cells.GetScreenPos(i))
        Next

    End Sub

    Public Sub DrawAccess(ByVal g As Graphics)

        For i As Integer = 0 To CELL_COUNT - 1
            Dim Pos As PointF = Cells.GetScreenPos(i)

            Dim Brush As SolidBrush = BlueBrush
            Select Case Accessibility(i)
                Case 1
                    Brush = RedBrush
                Case 2
                    Brush = YellowBrush
            End Select
            g.FillRectangle(Brush, Pos.X, Pos.Y, TILE_WIDTH, TILE_WIDTH)

            If DoorAccess(i) <> 0 Then

                If DoorAccess(i) And 1 Then
                    g.DrawLine(RedPen, Pos.X, Pos.Y, Pos.X + TILE_WIDTH, Pos.Y)
                End If
                If DoorAccess(i) And 2 Then
                    g.DrawLine(RedPen, Pos.X, Pos.Y + TILE_WIDTH, Pos.X + TILE_WIDTH, Pos.Y + TILE_WIDTH)
                End If
                If DoorAccess(i) And 4 Then
                    g.DrawLine(RedPen, Pos.X, Pos.Y, Pos.X, Pos.Y + TILE_WIDTH)
                End If
                If DoorAccess(i) And 8 Then
                    g.DrawLine(RedPen, Pos.X + TILE_WIDTH, Pos.Y, Pos.X + TILE_WIDTH, Pos.Y + TILE_WIDTH)
                End If

            End If

        Next

    End Sub

    Public Function IsOnMap(ByVal X As Integer, ByVal Y As Integer) As Boolean
        Return Not (X < 0 OrElse Y < 0 OrElse X >= MAP_WIDTH OrElse Y >= MAP_HEIGHT)
    End Function

End Class
