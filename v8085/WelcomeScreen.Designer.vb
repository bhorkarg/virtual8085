<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WelcomeScreen
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
        Dim ProgressBar1 As System.Windows.Forms.ProgressBar
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WelcomeScreen))
        Me.MainLayoutPanel = New System.Windows.Forms.TableLayoutPanel
        Me.DetailLayoutsPanel = New System.Windows.Forms.Panel
        Me.Version = New System.Windows.Forms.Label
        Me.Copyright = New System.Windows.Forms.Label
        ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.MainLayoutPanel.SuspendLayout()
        Me.DetailLayoutsPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        ProgressBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        ProgressBar1.Location = New System.Drawing.Point(3, 290)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New System.Drawing.Size(237, 10)
        ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        ProgressBar1.TabIndex = 3
        '
        'MainLayoutPanel
        '
        Me.MainLayoutPanel.BackColor = System.Drawing.Color.White
        Me.MainLayoutPanel.BackgroundImage = CType(resources.GetObject("MainLayoutPanel.BackgroundImage"), System.Drawing.Image)
        Me.MainLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.MainLayoutPanel.ColumnCount = 2
        Me.MainLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 243.0!))
        Me.MainLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 315.0!))
        Me.MainLayoutPanel.Controls.Add(ProgressBar1, 0, 0)
        Me.MainLayoutPanel.Controls.Add(Me.DetailLayoutsPanel, 1, 0)
        Me.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainLayoutPanel.Name = "MainLayoutPanel"
        Me.MainLayoutPanel.RowCount = 1
        Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 303.0!))
        Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 303.0!))
        Me.MainLayoutPanel.Size = New System.Drawing.Size(496, 303)
        Me.MainLayoutPanel.TabIndex = 0
        '
        'DetailLayoutsPanel
        '
        Me.DetailLayoutsPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.DetailLayoutsPanel.BackColor = System.Drawing.Color.Transparent
        Me.DetailLayoutsPanel.Controls.Add(Me.Version)
        Me.DetailLayoutsPanel.Controls.Add(Me.Copyright)
        Me.DetailLayoutsPanel.Location = New System.Drawing.Point(308, 251)
        Me.DetailLayoutsPanel.Name = "DetailLayoutsPanel"
        Me.DetailLayoutsPanel.Size = New System.Drawing.Size(185, 49)
        Me.DetailLayoutsPanel.TabIndex = 4
        '
        'Version
        '
        Me.Version.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Version.BackColor = System.Drawing.Color.Transparent
        Me.Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version.Location = New System.Drawing.Point(6, -1)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(173, 20)
        Me.Version.TabIndex = 3
        Me.Version.Text = "Version {0}.{1:00}"
        '
        'Copyright
        '
        Me.Copyright.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Copyright.BackColor = System.Drawing.Color.Transparent
        Me.Copyright.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Copyright.Location = New System.Drawing.Point(6, 19)
        Me.Copyright.Name = "Copyright"
        Me.Copyright.Size = New System.Drawing.Size(161, 30)
        Me.Copyright.TabIndex = 4
        Me.Copyright.Text = "Copyright"
        '
        'WelcomeScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 303)
        Me.ControlBox = False
        Me.Controls.Add(Me.MainLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WelcomeScreen"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.MainLayoutPanel.ResumeLayout(False)
        Me.DetailLayoutsPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents MainLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Private WithEvents DetailLayoutsPanel As System.Windows.Forms.Panel
    Friend WithEvents Version As System.Windows.Forms.Label
    Friend WithEvents Copyright As System.Windows.Forms.Label

End Class
