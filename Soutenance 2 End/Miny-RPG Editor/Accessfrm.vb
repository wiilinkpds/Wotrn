Public Class Accessfrm

    Private Sub Accessfrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Location = Mainfrm.Location + New Point(30, 20)

    End Sub

End Class