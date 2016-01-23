<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Virtual8085
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim Label9 As System.Windows.Forms.Label
        Dim gbSPRs As System.Windows.Forms.GroupBox
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Virtual8085))
        Dim gbGPRs As System.Windows.Forms.GroupBox
        Dim Label7 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim gbFlags As System.Windows.Forms.GroupBox
        Dim Label12 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Me.tblSPRs = New System.Windows.Forms.TableLayoutPanel()
        Me.SP = New _8085Interpreter.Register16()
        Me.tblGPRs = New System.Windows.Forms.TableLayoutPanel()
        Me.L = New _8085Interpreter.Register8()
        Me.H = New _8085Interpreter.Register8()
        Me.E = New _8085Interpreter.Register8()
        Me.D = New _8085Interpreter.Register8()
        Me.C = New _8085Interpreter.Register8()
        Me.B = New _8085Interpreter.Register8()
        Me.A = New _8085Interpreter.Register8()
        Me.lblFlags = New System.Windows.Forms.Label()
        Me.tblFlags = New System.Windows.Forms.TableLayoutPanel()
        Me.F = New _8085Interpreter.FlagRegister()
        Me.BackgroundInitializer = New System.ComponentModel.BackgroundWorker()
        Label9 = New System.Windows.Forms.Label()
        gbSPRs = New System.Windows.Forms.GroupBox()
        gbGPRs = New System.Windows.Forms.GroupBox()
        Label7 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        gbFlags = New System.Windows.Forms.GroupBox()
        Label12 = New System.Windows.Forms.Label()
        Label10 = New System.Windows.Forms.Label()
        gbSPRs.SuspendLayout()
        Me.tblSPRs.SuspendLayout()
        gbGPRs.SuspendLayout()
        Me.tblGPRs.SuspendLayout()
        gbFlags.SuspendLayout()
        Me.tblFlags.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label9.ForeColor = System.Drawing.Color.DimGray
        Label9.Location = New System.Drawing.Point(6, 27)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(41, 25)
        Label9.TabIndex = 8
        Label9.Text = "SP"
        '
        'gbSPRs
        '
        gbSPRs.Anchor = System.Windows.Forms.AnchorStyles.None
        gbSPRs.Controls.Add(Label9)
        gbSPRs.Controls.Add(Me.tblSPRs)
        gbSPRs.Location = New System.Drawing.Point(5, 210)
        gbSPRs.Name = "gbSPRs"
        gbSPRs.Size = New System.Drawing.Size(217, 61)
        gbSPRs.TabIndex = 5
        gbSPRs.TabStop = False
        gbSPRs.Text = "Special Purpose Registers"
        '
        'tblSPRs
        '
        Me.tblSPRs.BackColor = System.Drawing.SystemColors.Window
        Me.tblSPRs.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble
        Me.tblSPRs.ColumnCount = 1
        Me.tblSPRs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblSPRs.Controls.Add(Me.SP, 0, 0)
        Me.tblSPRs.Location = New System.Drawing.Point(48, 17)
        Me.tblSPRs.Name = "tblSPRs"
        Me.tblSPRs.RowCount = 1
        Me.tblSPRs.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblSPRs.Size = New System.Drawing.Size(121, 38)
        Me.tblSPRs.TabIndex = 0
        '
        'SP
        '
        Me.SP.AutoSize = True
        Me.SP.bits = CType(resources.GetObject("SP.bits"), System.Collections.BitArray)
        Me.SP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SP.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SP.Location = New System.Drawing.Point(6, 3)
        Me.SP.Name = "SP"
        Me.SP.Size = New System.Drawing.Size(109, 32)
        Me.SP.TabIndex = 0
        Me.SP.Text = "0000"
        Me.SP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbGPRs
        '
        gbGPRs.Anchor = System.Windows.Forms.AnchorStyles.None
        gbGPRs.BackColor = System.Drawing.SystemColors.Control
        gbGPRs.Controls.Add(Label7)
        gbGPRs.Controls.Add(Label6)
        gbGPRs.Controls.Add(Label5)
        gbGPRs.Controls.Add(Label4)
        gbGPRs.Controls.Add(Label3)
        gbGPRs.Controls.Add(Label2)
        gbGPRs.Controls.Add(Label1)
        gbGPRs.Controls.Add(Me.tblGPRs)
        gbGPRs.ForeColor = System.Drawing.Color.Black
        gbGPRs.Location = New System.Drawing.Point(5, 0)
        gbGPRs.Name = "gbGPRs"
        gbGPRs.Size = New System.Drawing.Size(218, 204)
        gbGPRs.TabIndex = 6
        gbGPRs.TabStop = False
        gbGPRs.Text = "General Purpose Registers"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label7.ForeColor = System.Drawing.Color.DimGray
        Label7.Location = New System.Drawing.Point(175, 158)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(24, 25)
        Label7.TabIndex = 8
        Label7.Text = "L"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.ForeColor = System.Drawing.Color.DimGray
        Label6.Location = New System.Drawing.Point(15, 158)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(27, 25)
        Label6.TabIndex = 7
        Label6.Text = "H"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label5.ForeColor = System.Drawing.Color.DimGray
        Label5.Location = New System.Drawing.Point(175, 121)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(26, 25)
        Label5.TabIndex = 6
        Label5.Text = "E"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label4.ForeColor = System.Drawing.Color.DimGray
        Label4.Location = New System.Drawing.Point(15, 121)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(27, 25)
        Label4.TabIndex = 5
        Label4.Text = "D"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.ForeColor = System.Drawing.Color.DimGray
        Label3.Location = New System.Drawing.Point(175, 87)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(28, 25)
        Label3.TabIndex = 4
        Label3.Text = "C"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.ForeColor = System.Drawing.Color.DimGray
        Label2.Location = New System.Drawing.Point(15, 87)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(26, 25)
        Label2.TabIndex = 3
        Label2.Text = "B"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.ForeColor = System.Drawing.Color.DimGray
        Label1.Location = New System.Drawing.Point(96, 16)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(27, 25)
        Label1.TabIndex = 2
        Label1.Text = "A"
        '
        'tblGPRs
        '
        Me.tblGPRs.BackColor = System.Drawing.SystemColors.Window
        Me.tblGPRs.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble
        Me.tblGPRs.ColumnCount = 2
        Me.tblGPRs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblGPRs.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblGPRs.Controls.Add(Me.L, 0, 3)
        Me.tblGPRs.Controls.Add(Me.H, 1, 2)
        Me.tblGPRs.Controls.Add(Me.E, 0, 2)
        Me.tblGPRs.Controls.Add(Me.D, 1, 1)
        Me.tblGPRs.Controls.Add(Me.C, 0, 1)
        Me.tblGPRs.Controls.Add(Me.B, 1, 0)
        Me.tblGPRs.Controls.Add(Me.A, 0, 0)
        Me.tblGPRs.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tblGPRs.Location = New System.Drawing.Point(48, 44)
        Me.tblGPRs.Name = "tblGPRs"
        Me.tblGPRs.RowCount = 4
        Me.tblGPRs.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tblGPRs.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tblGPRs.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tblGPRs.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tblGPRs.Size = New System.Drawing.Size(121, 144)
        Me.tblGPRs.TabIndex = 1
        '
        'L
        '
        Me.L.AutoSize = True
        Me.L.bits = CType(resources.GetObject("L.bits"), System.Collections.BitArray)
        Me.L.Dock = System.Windows.Forms.DockStyle.Fill
        Me.L.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L.Location = New System.Drawing.Point(65, 108)
        Me.L.Name = "L"
        Me.L.Size = New System.Drawing.Size(50, 33)
        Me.L.TabIndex = 6
        Me.L.Text = "00"
        Me.L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'H
        '
        Me.H.AutoSize = True
        Me.H.bits = CType(resources.GetObject("H.bits"), System.Collections.BitArray)
        Me.H.Dock = System.Windows.Forms.DockStyle.Fill
        Me.H.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.H.Location = New System.Drawing.Point(6, 108)
        Me.H.Name = "H"
        Me.H.Size = New System.Drawing.Size(50, 33)
        Me.H.TabIndex = 5
        Me.H.Text = "00"
        Me.H.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'E
        '
        Me.E.AutoSize = True
        Me.E.bits = CType(resources.GetObject("E.bits"), System.Collections.BitArray)
        Me.E.Dock = System.Windows.Forms.DockStyle.Fill
        Me.E.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.E.Location = New System.Drawing.Point(65, 73)
        Me.E.Name = "E"
        Me.E.Size = New System.Drawing.Size(50, 32)
        Me.E.TabIndex = 4
        Me.E.Text = "00"
        Me.E.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'D
        '
        Me.D.AutoSize = True
        Me.D.bits = CType(resources.GetObject("D.bits"), System.Collections.BitArray)
        Me.D.Dock = System.Windows.Forms.DockStyle.Fill
        Me.D.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.D.Location = New System.Drawing.Point(6, 73)
        Me.D.Name = "D"
        Me.D.Size = New System.Drawing.Size(50, 32)
        Me.D.TabIndex = 3
        Me.D.Text = "00"
        Me.D.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'C
        '
        Me.C.AutoSize = True
        Me.C.bits = CType(resources.GetObject("C.bits"), System.Collections.BitArray)
        Me.C.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C.Location = New System.Drawing.Point(65, 38)
        Me.C.Name = "C"
        Me.C.Size = New System.Drawing.Size(50, 32)
        Me.C.TabIndex = 2
        Me.C.Text = "00"
        Me.C.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'B
        '
        Me.B.AutoSize = True
        Me.B.bits = CType(resources.GetObject("B.bits"), System.Collections.BitArray)
        Me.B.Dock = System.Windows.Forms.DockStyle.Fill
        Me.B.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B.Location = New System.Drawing.Point(6, 38)
        Me.B.Name = "B"
        Me.B.Size = New System.Drawing.Size(50, 32)
        Me.B.TabIndex = 1
        Me.B.Text = "00"
        Me.B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'A
        '
        Me.A.AutoSize = True
        Me.A.bits = CType(resources.GetObject("A.bits"), System.Collections.BitArray)
        Me.tblGPRs.SetColumnSpan(Me.A, 2)
        Me.A.Dock = System.Windows.Forms.DockStyle.Fill
        Me.A.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.A.Location = New System.Drawing.Point(6, 3)
        Me.A.Name = "A"
        Me.A.Size = New System.Drawing.Size(109, 32)
        Me.A.TabIndex = 0
        Me.A.Text = "00"
        Me.A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbFlags
        '
        gbFlags.Anchor = System.Windows.Forms.AnchorStyles.None
        gbFlags.Controls.Add(Label12)
        gbFlags.Controls.Add(Me.lblFlags)
        gbFlags.Controls.Add(Label10)
        gbFlags.Controls.Add(Me.tblFlags)
        gbFlags.Location = New System.Drawing.Point(5, 277)
        gbFlags.Name = "gbFlags"
        gbFlags.Size = New System.Drawing.Size(217, 101)
        gbFlags.TabIndex = 7
        gbFlags.TabStop = False
        gbFlags.Text = "Flag Register"
        '
        'Label12
        '
        Label12.AutoSize = True
        Label12.Location = New System.Drawing.Point(30, 76)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(157, 13)
        Label12.TabIndex = 10
        Label12.Text = "SF  ZF   X   AC   X    PF   X   CF"
        '
        'lblFlags
        '
        Me.lblFlags.AutoSize = True
        Me.lblFlags.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlags.Location = New System.Drawing.Point(30, 59)
        Me.lblFlags.Name = "lblFlags"
        Me.lblFlags.Size = New System.Drawing.Size(156, 17)
        Me.lblFlags.TabIndex = 9
        Me.lblFlags.Text = "0   0   0   0   0   0   0   0"
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label10.ForeColor = System.Drawing.Color.DimGray
        Label10.Location = New System.Drawing.Point(17, 27)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(25, 25)
        Label10.TabIndex = 8
        Label10.Text = "F"
        '
        'tblFlags
        '
        Me.tblFlags.BackColor = System.Drawing.SystemColors.Window
        Me.tblFlags.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble
        Me.tblFlags.ColumnCount = 1
        Me.tblFlags.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblFlags.Controls.Add(Me.F, 0, 0)
        Me.tblFlags.Location = New System.Drawing.Point(48, 19)
        Me.tblFlags.Name = "tblFlags"
        Me.tblFlags.RowCount = 1
        Me.tblFlags.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblFlags.Size = New System.Drawing.Size(56, 34)
        Me.tblFlags.TabIndex = 1
        '
        'F
        '
        Me.F.AutoSize = True
        Me.F.bits = CType(resources.GetObject("F.bits"), System.Collections.BitArray)
        Me.F.Dock = System.Windows.Forms.DockStyle.Fill
        Me.F.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F.Location = New System.Drawing.Point(6, 3)
        Me.F.Name = "F"
        Me.F.Size = New System.Drawing.Size(44, 28)
        Me.F.TabIndex = 0
        Me.F.Text = "00"
        Me.F.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BackgroundInitializer
        '
        '
        'Virtual8085
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(gbFlags)
        Me.Controls.Add(gbGPRs)
        Me.Controls.Add(gbSPRs)
        Me.Name = "Virtual8085"
        Me.Size = New System.Drawing.Size(229, 379)
        gbSPRs.ResumeLayout(False)
        gbSPRs.PerformLayout()
        Me.tblSPRs.ResumeLayout(False)
        Me.tblSPRs.PerformLayout()
        gbGPRs.ResumeLayout(False)
        gbGPRs.PerformLayout()
        Me.tblGPRs.ResumeLayout(False)
        Me.tblGPRs.PerformLayout()
        gbFlags.ResumeLayout(False)
        gbFlags.PerformLayout()
        Me.tblFlags.ResumeLayout(False)
        Me.tblFlags.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tblSPRs As System.Windows.Forms.TableLayoutPanel
    Private WithEvents BackgroundInitializer As System.ComponentModel.BackgroundWorker
    Private WithEvents tblGPRs As System.Windows.Forms.TableLayoutPanel
    Private WithEvents L As _8085Interpreter.Register8
    Private WithEvents H As _8085Interpreter.Register8
    Private WithEvents E As _8085Interpreter.Register8
    Private WithEvents D As _8085Interpreter.Register8
    Private WithEvents C As _8085Interpreter.Register8
    Private WithEvents B As _8085Interpreter.Register8
    Private WithEvents A As _8085Interpreter.Register8
    Private WithEvents SP As _8085Interpreter.Register16
    Private WithEvents tblFlags As System.Windows.Forms.TableLayoutPanel
    Private WithEvents lblFlags As System.Windows.Forms.Label
    Private WithEvents F As _8085Interpreter.FlagRegister

End Class
