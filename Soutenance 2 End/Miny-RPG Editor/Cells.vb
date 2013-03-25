Public Class Cells

    Public Shared Function GetId(ByVal x As Integer, ByVal y As Integer) As Integer
        Return y * MAP_WIDTH + x
    End Function

    Public Shared Function GetPos(ByVal CellId As Integer) As Point
        Return New Point(CellId - Math.Floor(CellId / MAP_WIDTH) * MAP_WIDTH, Math.Floor(CellId / MAP_WIDTH))
    End Function

    Public Shared Function GetScreenPos(ByVal CellId As Integer) As PointF
        Dim p As Point = GetPos(CellId)
        Return New PointF(p.X * TILE_WIDTH, p.Y * TILE_WIDTH)
    End Function

End Class
