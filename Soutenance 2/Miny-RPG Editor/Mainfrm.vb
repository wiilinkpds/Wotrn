Public Class Mainfrm

    Public Map As New Map
    Private Painting As Boolean = False
    Private FileName As String = ""
    Public EditionType As Integer = 0

    Private LastCell As Integer = -1

    Private Sub Mainfrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitMap()
    End Sub

    Private Sub NouveauToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouveauToolStripMenuItem.Click
        InitMap()
    End Sub

    Private Sub QuitterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitterToolStripMenuItem.Click
        ExitProgram()
    End Sub

    Private Sub GrilleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrilleToolStripMenuItem.Click
        DrawAll()
    End Sub

    Private Sub Couche1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Couche1ToolStripMenuItem.Click
        DrawAll()
    End Sub

    Private Sub Couche2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Couche2ToolStripMenuItem.Click
        DrawAll()
    End Sub

    Private Sub Couche3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Couche3ToolStripMenuItem.Click
        DrawAll()
    End Sub

    Private Sub MainPicture_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainPicture.MouseDown
        Painting = True
    End Sub

    Private Sub MainPicture_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainPicture.MouseUp
        Painting = False
    End Sub

    Private Sub MainPicture_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainPicture.MouseMove
        Dim X As Integer = Math.Floor(e.X / TILE_WIDTH)
        Dim Y As Integer = Math.Floor(e.Y / TILE_WIDTH)

        If Not Map.IsOnMap(X, Y) Then Exit Sub

        Dim Cell As Integer = Cells.GetId(X, Y)

        If Cell <> LastCell Then
            LastCell = Cell

            LabelStatus.Text = "X: " & X & "  Y: " & Y & "  Id: " & Cell

            If EditionType = 0 Then

                If Painting AndAlso Modfrm.BrushContinue.Checked Then

                    If e.Button = Windows.Forms.MouseButtons.Left Then
                        PaintOnCell(Cell, False)
                    ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                        PaintOnCell(Cell, True)
                    End If

                End If

            End If
        End If

    End Sub

    Private Sub MainPicture_Click(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles MainPicture.MouseDown

        Dim X As Integer = Math.Floor(e.X / TILE_WIDTH)
        Dim Y As Integer = Math.Floor(e.Y / TILE_WIDTH)

        If Not Map.IsOnMap(X, Y) Then Exit Sub

        Dim Cell As Integer = Cells.GetId(X, Y)

        If EditionType = 0 And (Modfrm.BrushNormal.Checked Or Modfrm.BrushContinue.Checked) Then

            If e.Button = Windows.Forms.MouseButtons.Left Then
                PaintOnCell(Cell, False)
            ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                PaintOnCell(Cell, True)
            End If

        ElseIf EditionType = 1 Then

            If Accessfrm.AccessGlobal.Checked Then
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    Map.Accessibility(Cell) += 1
                    If Map.Accessibility(Cell) > 2 Then Map.Accessibility(Cell) = 0
                Else
                    Map.Accessibility(Cell) -= 1
                    If Map.Accessibility(Cell) < 0 Then Map.Accessibility(Cell) = 2
                End If
            Else
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    Dim Bool As Integer = 0
                    If Accessfrm.DoorTop.Checked Then Bool += 1
                    If Accessfrm.DoorBottom.Checked Then Bool += 2
                    If Accessfrm.DoorLeft.Checked Then Bool += 4
                    If Accessfrm.DoorRight.Checked Then Bool += 8
                    Map.DoorAccess(Cell) = Bool
                Else
                    Map.DoorAccess(Cell) = 0
                End If
            End If
            DrawAll()

        End If

    End Sub

    Private Sub InitMap()

        Map.Init()
        DrawAll()

    End Sub

    Private Sub PaintOnCell(ByVal Cell As Integer, ByVal [Erase] As Boolean)

        Dim Draw As Boolean = False

        Dim i As Integer = 0
        Dim StartPoint As Point = Cells.GetPos(Cell)

        For Each Selected As Point In If([Erase], New Point() {StartPoint}, Modfrm.SelectedPoints)

            Dim ActualPoint As Point = If([Erase], StartPoint, StartPoint + Selected)

            If ActualPoint.X < MAP_WIDTH AndAlso ActualPoint.Y < MAP_HEIGHT Then

                Cell = Cells.GetId(ActualPoint.X, ActualPoint.Y)

                Dim ToWrite As Integer = If([Erase], -1, Modfrm.SelectedCells(i))
                Dim Tiles As Dictionary(Of Integer, Integer) = Nothing
                If Modfrm.ModificationHigh.Checked Then
                    Tiles = Map.MapTilesHigh
                ElseIf Modfrm.ModificationMiddle.Checked Then
                    Tiles = Map.MapTilesMiddle
                ElseIf Modfrm.ModificationLow.Checked Then
                    Tiles = Map.MapTilesLow
                End If

                If Not Tiles Is Nothing AndAlso Tiles.ContainsKey(Cell) AndAlso Not Tiles(Cell) = ToWrite Then
                    Tiles(Cell) = ToWrite
                    Draw = True
                End If

            End If

            i += 1

        Next

        If Draw Then DrawAll()

    End Sub

    Private Sub DrawAll()

        Dim b As New Bitmap(TOTAL_WIDTH + TILE_WIDTH, TOTAL_HEIGHT + TILE_WIDTH)
        Dim g As Graphics = Graphics.FromImage(b)

        If Couche1ToolStripMenuItem.Checked Then Map.DrawLow(g)
        If Couche2ToolStripMenuItem.Checked Then Map.DrawMiddle(g)
        If Couche3ToolStripMenuItem.Checked Then Map.DrawHigh(g)
        If GrilleToolStripMenuItem.Checked Then Map.DrawGrid(g)
        If EditionType = 1 Then Map.DrawAccess(g)

        MainPicture.Image = b

    End Sub

    Private Sub ExitProgram()
        Application.Exit()
    End Sub

    Private Sub EnregistrerSousToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnregistrerSousToolStripMenuItem.Click

        Dim Save As New SaveFileDialog
        Save.Filter = "Cartes RPG (*.mrm)|*.mrm"
        If Save.ShowDialog = Windows.Forms.DialogResult.OK Then
            FileName = Save.FileName
            Map.ToFile(FileName)
        End If

    End Sub

    Private Sub OuvrirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OuvrirToolStripMenuItem.Click

        Dim Open As New OpenFileDialog
        Open.Filter = "Cartes RPG (*.mrm)|*.mrm"
        If Open.ShowDialog = Windows.Forms.DialogResult.OK Then
            Map.FromFile(Open.FileName)
        End If
        DrawAll()

    End Sub

    Private Sub EnregistrerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnregistrerToolStripMenuItem.Click

        If FileName = "" Then
            EnregistrerSousToolStripMenuItem_Click(sender, e)
        Else
            Map.ToFile(FileName)
        End If

    End Sub

    Private Sub TerrainToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TerrainToolStripMenuItem.Click
        EditionType = 0
        DrawAll()
    End Sub

    Private Sub AccessibiliteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccessibilitéToolStripMenuItem.Click
        EditionType = 1
        DrawAll()
    End Sub

    Private Sub EditionToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditionToolStripMenuItem1.Click
        Modfrm.Show()
    End Sub

    Private Sub AccessibilitéToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccessibilitéToolStripMenuItem1.Click
        Accessfrm.Show()
    End Sub
End Class
