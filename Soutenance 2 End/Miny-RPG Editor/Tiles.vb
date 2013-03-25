Public Class Tiles

    Private Shared This As Tiles

    Public Shared Function [Get](ByVal TileId As Integer) As Bitmap

        If This Is Nothing Then This = New Tiles

        Return This.Tiles(TileId)

    End Function

    Private Tiles As New Dictionary(Of Integer, Bitmap)

    Public Sub New()

        Dim b As New Bitmap("tiles.png")

        Dim i As Integer = 0

        For y As Integer = 0 To b.Height - 1 Step TILE_WIDTH
            For x As Integer = 0 To b.Width - 1 Step TILE_WIDTH

                Dim a As New Bitmap(TILE_WIDTH, TILE_WIDTH)
                For xa As Integer = 0 To TILE_WIDTH - 1
                    For ya As Integer = 0 To TILE_WIDTH - 1
                        Dim c As Color = b.GetPixel(x + xa, y + ya)
                        a.SetPixel(xa, ya, c)
                    Next
                Next
                Tiles.Add(i, a)
                i += 1

            Next
        Next

    End Sub

End Class
