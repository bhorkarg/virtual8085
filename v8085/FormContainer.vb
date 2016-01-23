Public Class FormContainer
    Private MainForm As FormMain

    Private Sub FormContainer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'initializing the main form
        MainForm = New FormMain
        MainForm.MdiParent = Me
        MainForm.Show()
    End Sub

    Private Sub RAMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RAMToolStripMenuItem.Click
        Dim RamDevice As New RAM
        RamDevice.MdiParent = Me
        RamDevice.Show()
    End Sub

    Private Sub ROMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROMToolStripMenuItem.Click
        Dim RomDevice As New ROM
        RomDevice.MdiParent = Me
        RomDevice.Show()
    End Sub

    Private Sub ViewTimingDiagramToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewTimingDiagramToolStripMenuItem.Click
        Dim frmTiming As New FormTimingDiagram
        frmTiming.ShowDialog()
    End Sub
End Class