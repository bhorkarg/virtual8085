<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormContainer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim PictureBox2 As System.Windows.Forms.PictureBox
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormContainer))
        Me.VMenu = New System.Windows.Forms.MenuStrip()
        Me.InterfaceDeviceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MemoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RAMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ROMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LearningToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewTimingDiagramToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox2
        '
        PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        PictureBox2.BackColor = System.Drawing.SystemColors.MenuBar
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        PictureBox2.Location = New System.Drawing.Point(785, 0)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New System.Drawing.Size(92, 27)
        PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 14
        PictureBox2.TabStop = False
        '
        'VMenu
        '
        Me.VMenu.BackColor = System.Drawing.SystemColors.MenuBar
        Me.VMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LearningToolStripMenuItem, Me.InterfaceDeviceToolStripMenuItem})
        Me.VMenu.Location = New System.Drawing.Point(0, 0)
        Me.VMenu.Name = "VMenu"
        Me.VMenu.Size = New System.Drawing.Size(877, 27)
        Me.VMenu.TabIndex = 1
        Me.VMenu.Text = "Menu"
        '
        'InterfaceDeviceToolStripMenuItem
        '
        Me.InterfaceDeviceToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDark
        Me.InterfaceDeviceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MemoryToolStripMenuItem})
        Me.InterfaceDeviceToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.InterfaceDeviceToolStripMenuItem.Name = "InterfaceDeviceToolStripMenuItem"
        Me.InterfaceDeviceToolStripMenuItem.Size = New System.Drawing.Size(118, 23)
        Me.InterfaceDeviceToolStripMenuItem.Text = "Interface Device"
        Me.InterfaceDeviceToolStripMenuItem.ToolTipText = "Interface a device to Virtual 8085"
        '
        'MemoryToolStripMenuItem
        '
        Me.MemoryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RAMToolStripMenuItem, Me.ROMToolStripMenuItem})
        Me.MemoryToolStripMenuItem.Name = "MemoryToolStripMenuItem"
        Me.MemoryToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.MemoryToolStripMenuItem.Text = "Memory"
        '
        'RAMToolStripMenuItem
        '
        Me.RAMToolStripMenuItem.Name = "RAMToolStripMenuItem"
        Me.RAMToolStripMenuItem.Size = New System.Drawing.Size(110, 24)
        Me.RAMToolStripMenuItem.Text = "RAM"
        '
        'ROMToolStripMenuItem
        '
        Me.ROMToolStripMenuItem.Name = "ROMToolStripMenuItem"
        Me.ROMToolStripMenuItem.Size = New System.Drawing.Size(110, 24)
        Me.ROMToolStripMenuItem.Text = "ROM"
        '
        'LearningToolStripMenuItem
        '
        Me.LearningToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewTimingDiagramToolStripMenuItem})
        Me.LearningToolStripMenuItem.Name = "LearningToolStripMenuItem"
        Me.LearningToolStripMenuItem.Size = New System.Drawing.Size(65, 23)
        Me.LearningToolStripMenuItem.Text = "Learning"
        '
        'ViewTimingDiagramToolStripMenuItem
        '
        Me.ViewTimingDiagramToolStripMenuItem.Name = "ViewTimingDiagramToolStripMenuItem"
        Me.ViewTimingDiagramToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.ViewTimingDiagramToolStripMenuItem.Text = "View Timing Diagram"
        '
        'FormContainer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 611)
        Me.Controls.Add(PictureBox2)
        Me.Controls.Add(Me.VMenu)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.VMenu
        Me.Name = "FormContainer"
        Me.Text = "Virtual 8085"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VMenu.ResumeLayout(False)
        Me.VMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents InterfaceDeviceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MemoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RAMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ROMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LearningToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewTimingDiagramToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
