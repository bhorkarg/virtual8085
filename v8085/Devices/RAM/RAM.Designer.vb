<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RAM
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
        Dim Label8 As System.Windows.Forms.Label
        Me.gbMemory = New System.Windows.Forms.GroupBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.ProgressBarMemory = New System.Windows.Forms.ProgressBar()
        Me.tbAddress = New System.Windows.Forms.TextBox()
        Me.Memory = New _8085Interpreter.Memory64KB()
        Label8 = New System.Windows.Forms.Label()
        Me.gbMemory.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label8.Location = New System.Drawing.Point(43, 182)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(79, 13)
        Label8.TabIndex = 3
        Label8.Text = "Select Location"
        '
        'gbMemory
        '
        Me.gbMemory.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbMemory.Controls.Add(Me.btnRefresh)
        Me.gbMemory.Controls.Add(Me.Memory)
        Me.gbMemory.Controls.Add(Me.ProgressBarMemory)
        Me.gbMemory.Controls.Add(Label8)
        Me.gbMemory.Controls.Add(Me.tbAddress)
        Me.gbMemory.Location = New System.Drawing.Point(3, 3)
        Me.gbMemory.Name = "gbMemory"
        Me.gbMemory.Size = New System.Drawing.Size(158, 220)
        Me.gbMemory.TabIndex = 5
        Me.gbMemory.TabStop = False
        Me.gbMemory.Text = "Memory"
        '
        'btnRefresh
        '
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(126, 172)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(30, 29)
        Me.btnRefresh.TabIndex = 6
        Me.btnRefresh.Text = "->" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<-"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'ProgressBarMemory
        '
        Me.ProgressBarMemory.Location = New System.Drawing.Point(3, 204)
        Me.ProgressBarMemory.Name = "ProgressBarMemory"
        Me.ProgressBarMemory.Size = New System.Drawing.Size(149, 10)
        Me.ProgressBarMemory.TabIndex = 4
        '
        'tbAddress
        '
        Me.tbAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbAddress.Location = New System.Drawing.Point(3, 178)
        Me.tbAddress.MaxLength = 4
        Me.tbAddress.Name = "tbAddress"
        Me.tbAddress.Size = New System.Drawing.Size(34, 20)
        Me.tbAddress.TabIndex = 2
        '
        'Memory
        '
        Me.Memory.BackColor = System.Drawing.SystemColors.Window
        Me.Memory.Dock = System.Windows.Forms.DockStyle.Top
        Me.Memory.FirstIndex = 0
        Me.Memory.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Memory.FormattingEnabled = True
        Me.Memory.ItemHeight = 25
        Me.Memory.LastIndex = 0
        Me.Memory.Location = New System.Drawing.Point(3, 16)
        Me.Memory.Name = "Memory"
        Me.Memory.Size = New System.Drawing.Size(152, 154)
        Me.Memory.TabIndex = 5
        '
        'RAM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(165, 226)
        Me.Controls.Add(Me.gbMemory)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RAM"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RAM"
        Me.gbMemory.ResumeLayout(False)
        Me.gbMemory.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ProgressBarMemory As System.Windows.Forms.ProgressBar
    Private WithEvents tbAddress As System.Windows.Forms.TextBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Private WithEvents gbMemory As System.Windows.Forms.GroupBox
    Public WithEvents Memory As _8085Interpreter.Memory64KB
End Class
