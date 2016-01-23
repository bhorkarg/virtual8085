<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Me.components = New System.ComponentModel.Container()
        Dim GroupBox2 As System.Windows.Forms.GroupBox
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.btnNext = New System.Windows.Forms.Button()
        Me.lbxProgram = New System.Windows.Forms.ListBox()
        Me.Tabs = New System.Windows.Forms.TabControl()
        Me.TabPageSource = New System.Windows.Forms.TabPage()
        Me.cbxStepByStep = New System.Windows.Forms.CheckBox()
        Me.SourceCodeMenu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.rtbSrc = New System.Windows.Forms.RichTextBox()
        Me.rtbContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CutContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllContextMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rtbIntelligentHelp = New System.Windows.Forms.RichTextBox()
        Me.SourceCodeTools = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CopyToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PasteToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.TabPageOutput = New System.Windows.Forms.TabPage()
        Me.v8085 = New _8085Interpreter.Virtual8085()
        Me.ofdOpen = New System.Windows.Forms.OpenFileDialog()
        Me.sfdSave = New System.Windows.Forms.SaveFileDialog()
        GroupBox2 = New System.Windows.Forms.GroupBox()
        GroupBox2.SuspendLayout()
        Me.Tabs.SuspendLayout()
        Me.TabPageSource.SuspendLayout()
        Me.SourceCodeMenu.SuspendLayout()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        Me.rtbContextMenu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SourceCodeTools.SuspendLayout()
        Me.TabPageOutput.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.None
        GroupBox2.Controls.Add(Me.btnNext)
        GroupBox2.Controls.Add(Me.lbxProgram)
        GroupBox2.Location = New System.Drawing.Point(240, 48)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New System.Drawing.Size(225, 388)
        GroupBox2.TabIndex = 14
        GroupBox2.TabStop = False
        GroupBox2.Text = "Program"
        '
        'btnNext
        '
        Me.btnNext.Enabled = False
        Me.btnNext.Location = New System.Drawing.Point(75, 19)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 1
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'lbxProgram
        '
        Me.lbxProgram.BackColor = System.Drawing.SystemColors.Window
        Me.lbxProgram.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbxProgram.Enabled = False
        Me.lbxProgram.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbxProgram.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbxProgram.HorizontalScrollbar = True
        Me.lbxProgram.ItemHeight = 16
        Me.lbxProgram.Location = New System.Drawing.Point(6, 47)
        Me.lbxProgram.Name = "lbxProgram"
        Me.lbxProgram.Size = New System.Drawing.Size(212, 324)
        Me.lbxProgram.TabIndex = 0
        Me.lbxProgram.TabStop = False
        '
        'Tabs
        '
        Me.Tabs.Controls.Add(Me.TabPageSource)
        Me.Tabs.Controls.Add(Me.TabPageOutput)
        Me.Tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tabs.Location = New System.Drawing.Point(0, 0)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SelectedIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(479, 467)
        Me.Tabs.TabIndex = 0
        '
        'TabPageSource
        '
        Me.TabPageSource.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageSource.Controls.Add(Me.cbxStepByStep)
        Me.TabPageSource.Controls.Add(Me.SourceCodeMenu)
        Me.TabPageSource.Controls.Add(Me.btnRun)
        Me.TabPageSource.Controls.Add(Me.SplitContainer)
        Me.TabPageSource.Controls.Add(Me.SourceCodeTools)
        Me.TabPageSource.Location = New System.Drawing.Point(4, 22)
        Me.TabPageSource.Name = "TabPageSource"
        Me.TabPageSource.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageSource.Size = New System.Drawing.Size(471, 441)
        Me.TabPageSource.TabIndex = 0
        Me.TabPageSource.Text = "Source Code"
        '
        'cbxStepByStep
        '
        Me.cbxStepByStep.AutoSize = True
        Me.cbxStepByStep.Location = New System.Drawing.Point(378, 3)
        Me.cbxStepByStep.Name = "cbxStepByStep"
        Me.cbxStepByStep.Size = New System.Drawing.Size(87, 17)
        Me.cbxStepByStep.TabIndex = 12
        Me.cbxStepByStep.Text = "Step by Step"
        Me.cbxStepByStep.UseVisualStyleBackColor = True
        '
        'SourceCodeMenu
        '
        Me.SourceCodeMenu.BackColor = System.Drawing.Color.Transparent
        Me.SourceCodeMenu.Dock = System.Windows.Forms.DockStyle.None
        Me.SourceCodeMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.SourceCodeMenu.Location = New System.Drawing.Point(5, 3)
        Me.SourceCodeMenu.Name = "SourceCodeMenu"
        Me.SourceCodeMenu.Size = New System.Drawing.Size(128, 24)
        Me.SourceCodeMenu.TabIndex = 7
        Me.SourceCodeMenu.Text = "SourceCodeMenu"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.toolStripSeparator, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.toolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = CType(resources.GetObject("OpenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(143, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Image = CType(resources.GetObject("SaveToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save &As"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(143, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.toolStripSeparator4, Me.SelectAllToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Image = CType(resources.GetObject("CutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.CutToolStripMenuItem.Text = "Cu&t"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Image = CType(resources.GetObject("CopyToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CopyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.CopyToolStripMenuItem.Text = "&Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Image = CType(resources.GetObject("PasteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.PasteToolStripMenuItem.Text = "&Paste"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New System.Drawing.Size(141, 6)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select &All"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator5, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'toolStripSeparator5
        '
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        Me.toolStripSeparator5.Size = New System.Drawing.Size(113, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AboutToolStripMenuItem.Text = "&About..."
        '
        'btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(299, 3)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(73, 47)
        Me.btnRun.TabIndex = 9
        Me.btnRun.Text = "Run"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'SplitContainer
        '
        Me.SplitContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer.Location = New System.Drawing.Point(0, 55)
        Me.SplitContainer.Name = "SplitContainer"
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.Controls.Add(Me.rtbSrc)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer.Size = New System.Drawing.Size(468, 386)
        Me.SplitContainer.SplitterDistance = 219
        Me.SplitContainer.TabIndex = 11
        '
        'rtbSrc
        '
        Me.rtbSrc.AcceptsTab = True
        Me.rtbSrc.BackColor = System.Drawing.SystemColors.Window
        Me.rtbSrc.ContextMenuStrip = Me.rtbContextMenu
        Me.rtbSrc.DetectUrls = False
        Me.rtbSrc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbSrc.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbSrc.HideSelection = False
        Me.rtbSrc.Location = New System.Drawing.Point(0, 0)
        Me.rtbSrc.Name = "rtbSrc"
        Me.rtbSrc.Size = New System.Drawing.Size(219, 386)
        Me.rtbSrc.TabIndex = 0
        Me.rtbSrc.Text = ""
        Me.rtbSrc.WordWrap = False
        '
        'rtbContextMenu
        '
        Me.rtbContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CutContextMenuItem, Me.CopyContextMenuItem, Me.PasteContextMenuItem, Me.SelectAllContextMenuItem})
        Me.rtbContextMenu.Name = "ContextMenuStrip1"
        Me.rtbContextMenu.Size = New System.Drawing.Size(123, 92)
        '
        'CutContextMenuItem
        '
        Me.CutContextMenuItem.Name = "CutContextMenuItem"
        Me.CutContextMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.CutContextMenuItem.Text = "Cu&t"
        '
        'CopyContextMenuItem
        '
        Me.CopyContextMenuItem.Name = "CopyContextMenuItem"
        Me.CopyContextMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.CopyContextMenuItem.Text = "&Copy"
        '
        'PasteContextMenuItem
        '
        Me.PasteContextMenuItem.Name = "PasteContextMenuItem"
        Me.PasteContextMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.PasteContextMenuItem.Text = "&Paste"
        '
        'SelectAllContextMenuItem
        '
        Me.SelectAllContextMenuItem.Name = "SelectAllContextMenuItem"
        Me.SelectAllContextMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.SelectAllContextMenuItem.Text = "Select &All"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rtbIntelligentHelp)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(245, 386)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Intelligent Help"
        '
        'rtbIntelligentHelp
        '
        Me.rtbIntelligentHelp.BackColor = System.Drawing.SystemColors.Control
        Me.rtbIntelligentHelp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbIntelligentHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbIntelligentHelp.Location = New System.Drawing.Point(3, 16)
        Me.rtbIntelligentHelp.Name = "rtbIntelligentHelp"
        Me.rtbIntelligentHelp.ReadOnly = True
        Me.rtbIntelligentHelp.ShortcutsEnabled = False
        Me.rtbIntelligentHelp.Size = New System.Drawing.Size(239, 367)
        Me.rtbIntelligentHelp.TabIndex = 0
        Me.rtbIntelligentHelp.Text = ""
        '
        'SourceCodeTools
        '
        Me.SourceCodeTools.BackColor = System.Drawing.Color.Transparent
        Me.SourceCodeTools.Dock = System.Windows.Forms.DockStyle.None
        Me.SourceCodeTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.SourceCodeTools.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.toolStripSeparator6, Me.CutToolStripButton, Me.CopyToolStripButton, Me.PasteToolStripButton})
        Me.SourceCodeTools.Location = New System.Drawing.Point(5, 27)
        Me.SourceCodeTools.Name = "SourceCodeTools"
        Me.SourceCodeTools.Size = New System.Drawing.Size(147, 25)
        Me.SourceCodeTools.TabIndex = 8
        Me.SourceCodeTools.Text = "SourceCodeTools"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'toolStripSeparator6
        '
        Me.toolStripSeparator6.Name = "toolStripSeparator6"
        Me.toolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'CutToolStripButton
        '
        Me.CutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CutToolStripButton.Image = CType(resources.GetObject("CutToolStripButton.Image"), System.Drawing.Image)
        Me.CutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripButton.Name = "CutToolStripButton"
        Me.CutToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CutToolStripButton.Text = "C&ut"
        '
        'CopyToolStripButton
        '
        Me.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopyToolStripButton.Image = CType(resources.GetObject("CopyToolStripButton.Image"), System.Drawing.Image)
        Me.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyToolStripButton.Name = "CopyToolStripButton"
        Me.CopyToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CopyToolStripButton.Text = "&Copy"
        '
        'PasteToolStripButton
        '
        Me.PasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PasteToolStripButton.Image = CType(resources.GetObject("PasteToolStripButton.Image"), System.Drawing.Image)
        Me.PasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteToolStripButton.Name = "PasteToolStripButton"
        Me.PasteToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PasteToolStripButton.Text = "&Paste"
        '
        'TabPageOutput
        '
        Me.TabPageOutput.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TabPageOutput.Controls.Add(GroupBox2)
        Me.TabPageOutput.Controls.Add(Me.v8085)
        Me.TabPageOutput.Location = New System.Drawing.Point(4, 22)
        Me.TabPageOutput.Name = "TabPageOutput"
        Me.TabPageOutput.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageOutput.Size = New System.Drawing.Size(471, 441)
        Me.TabPageOutput.TabIndex = 1
        Me.TabPageOutput.Text = "Under the hood!"
        '
        'v8085
        '
        Me.v8085.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.v8085.BackColor = System.Drawing.SystemColors.Control
        Me.v8085.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.v8085.Location = New System.Drawing.Point(5, 48)
        Me.v8085.Name = "v8085"
        Me.v8085.Size = New System.Drawing.Size(229, 388)
        Me.v8085.TabIndex = 0
        '
        'ofdOpen
        '
        Me.ofdOpen.Filter = "8085 Assembly Language code|*.asm85|All Files|*.*"
        '
        'sfdSave
        '
        Me.sfdSave.Filter = "Assembly Language Code|.asm85|Text File|.txt"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(479, 467)
        Me.Controls.Add(Me.Tabs)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMain"
        Me.ShowIcon = False
        Me.Text = "Virtual 8085"
        GroupBox2.ResumeLayout(False)
        Me.Tabs.ResumeLayout(False)
        Me.TabPageSource.ResumeLayout(False)
        Me.TabPageSource.PerformLayout()
        Me.SourceCodeMenu.ResumeLayout(False)
        Me.SourceCodeMenu.PerformLayout()
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.ResumeLayout(False)
        Me.rtbContextMenu.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.SourceCodeTools.ResumeLayout(False)
        Me.SourceCodeTools.PerformLayout()
        Me.TabPageOutput.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tabs As System.Windows.Forms.TabControl
    Friend WithEvents TabPageSource As System.Windows.Forms.TabPage
    Friend WithEvents SourceCodeMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SourceCodeTools As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CopyToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PasteToolStripButton As System.Windows.Forms.ToolStripButton
    Private WithEvents rtbContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CutContextMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyContextMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteContextMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAllContextMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents rtbSrc As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rtbIntelligentHelp As System.Windows.Forms.RichTextBox
    Private WithEvents btnRun As System.Windows.Forms.Button
    Private WithEvents ofdOpen As System.Windows.Forms.OpenFileDialog
    Private WithEvents sfdSave As System.Windows.Forms.SaveFileDialog
    Private WithEvents TabPageOutput As System.Windows.Forms.TabPage
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents lbxProgram As System.Windows.Forms.ListBox
    Private WithEvents cbxStepByStep As System.Windows.Forms.CheckBox
    Private WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents v8085 As _8085Interpreter.Virtual8085
End Class
