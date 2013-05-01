Public Module Constants

    Public Const MAP_HEIGHT As Integer = 24
    Public Const MAP_WIDTH As Integer = 32

    Public Const TILE_WIDTH As Integer = 32

    Public ReadOnly Property TOTAL_HEIGHT() As Integer
        Get
            Return MAP_HEIGHT * TILE_WIDTH
        End Get
    End Property

    Public ReadOnly Property TOTAL_WIDTH() As Integer
        Get
            Return MAP_WIDTH * TILE_WIDTH
        End Get
    End Property

    Public ReadOnly Property CELL_COUNT() As Integer
        Get
            Return MAP_HEIGHT * MAP_WIDTH
        End Get
    End Property

End Module
