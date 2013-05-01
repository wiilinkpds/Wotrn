Public Class Modfrm

    Dim Base As Bitmap
    Dim BasePlusGrid As Bitmap

    Private Start As New Point(0, 0)
    Private [End] As New Point(0, 0)
    Private Selecting As Boolean = False

    Public SelectedPoints As New List(Of Point)
    Public SelectedCells As New List(Of Integer)

    Public Sub DrawGrid(ByVal g As Graphics)

        For i As Integer = 0 To Base.Height / 32
            g.DrawLine(Pens.Blue, 0, i * TILE_WIDTH, Base.Width, i * TILE_WIDTH)
        Next

        For i As Integer = 0 To Base.Width / 32
            g.DrawLine(Pens.Blue, i * TILE_WIDTH, 0, i * TILE_WIDTH, Base.Height)
        Next

        For Each Selected As Point In SelectedPoints
            g.DrawRectangle(Pens.Red, Selected.X * TILE_WIDTH, Selected.Y * TILE_WIDTH, TILE_WIDTH, TILE_WIDTH)
        Next

    End Sub

    Private ReadOnly Property TILES_HEIGHT()
        Get
            Return Math.Floor(Base.Height / TILE_WIDTH)
        End Get
    End Property

    Private ReadOnly Property TILES_WIDTH()
        Get
            Return Math.Floor(Base.Width / TILE_WIDTH)
        End Get
    End Property

    Private Sub Modfrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SelectedPoints.Add(New Point(0, 0))
        SelectedCells.Add(0)
        Base = New Bitmap("tiles.png")
        RepaintBox()
        Me.Location = Mainfrm.Location + New Point(30, 20)

    End Sub

    Private Sub RepaintBox()

        BasePlusGrid = New Bitmap(Base.Width + 1, Base.Height + 1)
        Dim g As Graphics = Graphics.FromImage(BasePlusGrid)
        g.DrawImage(Base, 0, 0)
        DrawGrid(g)
        PaintBox.Image = BasePlusGrid

    End Sub

    Private Sub PaintBox_MouseDown(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles PaintBox.MouseDown

        Start = New Point(Math.Floor(e.X / TILE_WIDTH), Math.Floor(e.Y / TILE_WIDTH))
        Selecting = True

    End Sub

    Private Sub ArrangePoints()

        Dim FirstPoint As New Point(500, 500)
        Dim LastPoint As New Point(-1, -1)

        For Each p As Point In SelectedPoints
            If p.X < FirstPoint.X OrElse p.Y < FirstPoint.Y Then
                FirstPoint = p
            End If
            If p.X > LastPoint.X OrElse p.Y > LastPoint.Y Then
                LastPoint = p
            End If
        Next

        SelectedPoints.Clear()
        SelectedCells.Clear()

        Dim Decalage As Point = FirstPoint
        LastPoint -= FirstPoint
        FirstPoint.X = 0
        FirstPoint.Y = 0

        For i As Integer = FirstPoint.X To LastPoint.X
            For j As Integer = FirstPoint.Y To LastPoint.Y
                SelectedPoints.Add(New Point(i, j))
                SelectedCells.Add((j + Decalage.Y) * Math.Floor(Base.Width / TILE_WIDTH) + (i + Decalage.X))
            Next
        Next

    End Sub

    Private Sub PaintSelection()

        SelectedPoints.Clear()
        SelectedCells.Clear()

        For i As Integer = Start.X To [End].X Step If(Start.X > [End].X, -1, 1)
            For j As Integer = Start.Y To [End].Y Step If(Start.Y > [End].Y, -1, 1)
                If i < TILES_WIDTH AndAlso j < TILES_HEIGHT Then
                    SelectedPoints.Add(New Point(i, j))
                    SelectedCells.Add(j * Math.Floor(Base.Width / TILE_WIDTH) + i)
                End If
            Next
        Next

        RepaintBox()

        ArrangePoints()

    End Sub

    Private Sub PaintBox_MouseMove(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles PaintBox.MouseMove

        If Selecting Then

            [End] = New Point(Math.Floor(e.X / TILE_WIDTH), Math.Floor(e.Y / TILE_WIDTH))
            PaintSelection()

        End If

    End Sub

    Private Sub PaintBox_MouseUp(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles PaintBox.MouseUp

        If Selecting Then

            [End] = New Point(Math.Floor(e.X / TILE_WIDTH), Math.Floor(e.Y / TILE_WIDTH))
            PaintSelection()

        End If

        Selecting = False

    End Sub

    Private Sub PaintBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaintBox.Click

    End Sub
End Class