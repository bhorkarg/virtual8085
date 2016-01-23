Public Class ROM
    Inherits RAM
    Implements IDevice

    Private components As System.ComponentModel.IContainer
    Friend WithEvents RightClickMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ChangeDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Overrides Property bits(ByVal HexString As String) As BitArray 'Implements IDevice.bits
        Get
            Return MyBase.bits(HexString)
        End Get
        Set(ByVal value As BitArray)
            Throw New Exception8085("Cannot write to this address: " & HexString & vbNewLine & "No write operation can be performed on a Read Only Memory!")
        End Set
    End Property

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.RightClickMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ChangeDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RightClickMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'RightClickMenu
        '
        Me.RightClickMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeDataToolStripMenuItem})
        Me.RightClickMenu.Name = "RightClickMenu"
        Me.RightClickMenu.Size = New System.Drawing.Size(152, 26)
        '
        'ChangeDataToolStripMenuItem
        '
        Me.ChangeDataToolStripMenuItem.Name = "ChangeDataToolStripMenuItem"
        Me.ChangeDataToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.ChangeDataToolStripMenuItem.Text = "Change Data..."
        '
        'ROM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(165, 227)
        Me.ContextMenuStrip = Me.RightClickMenu
        Me.Name = "ROM"
        Me.Text = "RAM - 4KB"
        Me.RightClickMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub


    Private Sub ROM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Me.Text.Replace("RAM", "ROM")
    End Sub

    Private Sub Memory_DoubleClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Memory.DoubleClick
        Dim WriteDialog As New DlgWriteData(Me)
        WriteDialog.Show()
    End Sub
End Class
