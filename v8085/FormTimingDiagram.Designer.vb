<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTimingDiagram
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
        Me.picTiming = New System.Windows.Forms.PictureBox()
        Me.cbxInstr = New System.Windows.Forms.ComboBox()
        CType(Me.picTiming, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picTiming
        '
        Me.picTiming.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picTiming.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.picTiming.Location = New System.Drawing.Point(12, 64)
        Me.picTiming.Name = "picTiming"
        Me.picTiming.Size = New System.Drawing.Size(532, 484)
        Me.picTiming.TabIndex = 0
        Me.picTiming.TabStop = False
        '
        'cbxInstr
        '
        Me.cbxInstr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxInstr.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxInstr.FormattingEnabled = True
        Me.cbxInstr.Items.AddRange(New Object() {"MOV Rd, Rs", "XCHG", "ADD R", "ADC R", "SUB  R", "SBB R", "CMP R", "INR R", "DCR R", "DAA ", "ANA R", "ORA R", "XRA R", "CMA", "CMC", "STC", "RLC", "RAL", "RRC", "RAR", "NOP", "EI", "DI", "SIM", "RIM", "--------------------", "MVI Rd, data8", "ADI data8", "ACI data8", "SUI data8", "SBI data8", "CPI data8", "ANI data8", "ORI data8", "XRI data8", "--------------------", "MOV Rd, M", "LDAX RP", "ADD M", "ADC M", "SUB M", "SBB M", "CMP M", "ANA M", "ORA M", "XRA M", "---------------------", "MOV M, Rs", "STAX RP", "---------------------", "LHLD Addr16", "---------------------", "LDA Addr16", "---------------------", "LXI Rp, Addr16", "JMP Addr16", "Jcondition Addr16", "---------------------", "SHLD Addr16", "---------------------", "STA Addr16", "---------------------", "XTHL", "---------------------", "POP Rp", "RET", "---------------------", "INR M", "DCR M", "---------------------", "OUT data8", "---------------------", "IN data8", "---------------------", "PUSH Rp", "---------------------", "CALL Addr16", "---------------------", "INX Rp", "DCX Rp", "SPHL", "PCHL", "---------------------", "Rcondition", "---------------------", "RST n", "---------------------", "DAD Rp", "---------------------", "HALT"})
        Me.cbxInstr.Location = New System.Drawing.Point(12, 12)
        Me.cbxInstr.Name = "cbxInstr"
        Me.cbxInstr.Size = New System.Drawing.Size(222, 28)
        Me.cbxInstr.TabIndex = 1
        '
        'FormTimingDiagram
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 560)
        Me.Controls.Add(Me.cbxInstr)
        Me.Controls.Add(Me.picTiming)
        Me.Name = "FormTimingDiagram"
        Me.Text = "Timing Diagram"
        CType(Me.picTiming, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picTiming As System.Windows.Forms.PictureBox
    Private WithEvents cbxInstr As System.Windows.Forms.ComboBox
End Class
