Imports System.IO
Imports System.Text.RegularExpressions

Public Class FormMain
    Dim mFileName As String = String.Empty
    Dim IsSaved As Boolean = False

    Dim ExePath As String

#Region "Internal Functions"

    Private Sub FileOpen()
        Dim SrcFile As StreamReader = File.OpenText(mFileName)
        rtbSrc.Text = SrcFile.ReadToEnd()
        SrcFile.Close()
        'now syntax highlight each line
        For i As Integer = 0 To rtbSrc.Lines.Length - 1
            SyntaxHighlightLine(i)
        Next
        IsSaved = True
    End Sub

    Private Sub SelectLine(ByVal LineNo As Integer)
        Dim SelectionStart, SelectionLength As Integer
        SelectionStart = rtbSrc.GetFirstCharIndexFromLine(LineNo)
        SelectionLength = rtbSrc.Lines(LineNo).Length

        rtbSrc.Select(SelectionStart, SelectionLength)
    End Sub

#End Region 'end internal functions

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

#Region "Main Form Events"

    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Tabs.SelectTab(TabPageOutput)

        'v8085.InitializeMemory()

        'SplashScr.ShowDialog()

        'loading the file if a file association has been set
        Dim args() As String = Environment.GetCommandLineArgs()
        If args.Length = 2 Then
            mFileName = args(1)
            FileOpen()
        End If

        ExePath = ""
    End Sub

    Private Sub FormMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If IsSaved = False And rtbSrc.Text <> String.Empty Then
            Dim Result As Integer = MessageBox.Show("File not saved, do you want to save?", "Save File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
            If Result = DialogResult.Yes Then
                SaveToolStripMenuItem_Click(sender, e)
            ElseIf Result = DialogResult.Cancel Then
                e.Cancel = True 'cancel form closing
                Return
            End If
        End If
        e.Cancel = False
    End Sub

    Private Sub FormMain_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

#End Region 'End main Form event handlers

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

#Region "Tool Strip Menu Item's event handlers"

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        If ofdOpen.ShowDialog() = Windows.Forms.DialogResult.OK Then
            mFileName = ofdOpen.FileName
            FileOpen()
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        If rtbSrc.Text = String.Empty Then
            Exit Sub 'because there is nothing to save
        End If

        If sfdSave.ShowDialog = Windows.Forms.DialogResult.OK Then
            rtbSrc.SaveFile(sfdSave.FileName, RichTextBoxStreamType.PlainText)
            mFileName = sfdSave.FileName
            IsSaved = True
        End If

    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click, SaveToolStripButton.Click
        If rtbSrc.Text = String.Empty Then
            Exit Sub 'because there is nothing to save

        End If
        If mFileName = String.Empty Then
            'if the filename is empty then show the save as dialog, otherwise save the file
            SaveAsToolStripMenuItem_Click(sender, e)
        Else
            rtbSrc.SaveFile(mFileName, RichTextBoxStreamType.PlainText)
            IsSaved = True
        End If
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click, CutToolStripButton.Click, CutContextMenuItem.Click
        rtbSrc.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click, CopyToolStripButton.Click, CopyContextMenuItem.Click
        rtbSrc.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click, PasteToolStripButton.Click, PasteContextMenuItem.Click
        Dim CurrentLineNo As Integer = rtbSrc.GetLineFromCharIndex(rtbSrc.GetFirstCharIndexOfCurrentLine())

        rtbSrc.Paste()

        For i As Integer = CurrentLineNo To rtbSrc.Lines.Length - 1
            SyntaxHighlightLine(i)
        Next
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rtbSrc.Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rtbSrc.Redo()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click, SelectAllContextMenuItem.Click
        rtbSrc.SelectAll()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim frmAboutUs As New AboutUsBox
        frmAboutUs.ShowDialog()
    End Sub

#End Region 'Tool strip menu items end

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

#Region "User Interface (Syntax Highlighting, Help providing)"

    Private Sub SyntaxHighlightLine(ByVal LineNumber As Integer)
        rtbIntelligentHelp.Focus() 'focus on something else so that the selection doesn't show up

        Dim CurrentLineFirstCharIndex = rtbSrc.GetFirstCharIndexFromLine(LineNumber)
        Dim SelectionStart As Integer = rtbSrc.SelectionStart
        Dim Line As String = rtbSrc.Lines(LineNumber)

        Static Pattern As String _
        = "^;| ;" & _
        "|MOV|MVI|LDAX?|LXI|LHLD|STAX?|SHLD|XCHG|SPHL|XTHL|PUSH|POP|OUT" & _
        "|ADD|ADC|ADI|ACI|DAD|SUB|SBB|SUI|SBI|INR?X?|DCR|DCX|DAA" & _
        "|JMP|JC|JNC|JP|JM|JZ|JNZ|JPE|JPO|CALL|CC|CNC|CPI?E?O?|CZ|CNZ" & _
        "|RET|RC|RNC|RPE?O?|RM|RZ|RNZ|PCHL|RST" & _
        "|CMP|CPI|ANA|ANI|XRA|XRI|ORA|ORI|RLC|RRC|RAL|RAR|CMA?C?|STC" & _
        "|NOP|HLT|DI|EI|RIM|SIM" & _
        "|:"

        'first select the whole line and de-syntax highlight the whole line
        rtbSrc.SelectionStart = CurrentLineFirstCharIndex
        rtbSrc.SelectionLength = Line.Length
        rtbSrc.SelectionColor = Color.Black

        'now match the line with the above pattern
        Dim matches As MatchCollection = Regex.Matches(Line, Pattern, RegexOptions.IgnoreCase)

        'syntax highlight, if a match is found
        For Each m As Match In matches
            'coming to the index of matched pattern
            rtbSrc.SelectionStart = m.Index + CurrentLineFirstCharIndex
            If m.Value = ";" Or m.Value = " ;" Then
                'colouring comments
                rtbSrc.SelectionLength = rtbSrc.Lines(LineNumber).Length - m.Index
                'rtbSrc.SelectionFont = New Font(rtbSrc.Font.FontFamily, rtbSrc.Font.Size - 5, GraphicsUnit.Point)
                rtbSrc.SelectionColor = Color.Green
                Exit For
            Else
                'colouring other patterns
                rtbSrc.SelectionLength = m.Length
                If m.Value.EndsWith(":") = True Then
                    rtbSrc.SelectionColor = Color.Red
                Else
                    rtbSrc.SelectionColor = Color.Blue
                    rtbSrc.SelectedText = rtbSrc.SelectedText.ToUpper
                End If
            End If
        Next

        'coming back to previous selection
        rtbSrc.SelectionStart = SelectionStart
        rtbSrc.SelectionLength = 0
        rtbSrc.SelectionColor = Color.Black

        rtbSrc.Focus() 'focus back on source text box
    End Sub

    Private Sub LoadIntelligentHelp(ByVal Mnemonic As String)
        Mnemonic = Mnemonic.ToUpper()
        Mnemonic = Mnemonic.Trim()

        'the mnemonic's help is contained in applications resources
        'For eg, MVI's help is contained in a resource named _MVI, similarly LXI's is in _LXI
        Try
            If rtbIntelligentHelp.TextLength = 0 Then 'if no help is loaded then load help
                'rtbIntelligentHelp.LoadFile(ExePath & "Intelligent Help\" & Mnemonic & ".rtf")
                'in version 1.0 we are loading these files from the application resoureces
                rtbIntelligentHelp.Rtf = My.Resources.ResourceManager.GetObject("_" & Mnemonic)
            End If
        Catch ex As Exception
            'an exception may encounter if file is not found, or invalid filename, etc. So we clear help text
            rtbIntelligentHelp.Text = ":-)"
        End Try
    End Sub

    Private Sub rtbSrc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbSrc.TextChanged
        IsSaved = False

        'now we need to load help if a correct instruction is found.
        If rtbSrc.TextLength > 0 Then
            'get current line number
            Dim LineNo As Integer = rtbSrc.GetLineFromCharIndex(rtbSrc.GetFirstCharIndexOfCurrentLine())

            Dim Line As String = rtbSrc.Lines(LineNo) 'the current line is the instruction
            Dim Mnemonic As String = ""
            Dim Operand1 As String = ""

            'if the user enters a new line then it is empty, so we clear help
            If Line.Length = 0 Then
                rtbIntelligentHelp.Clear()
                Exit Sub
            ElseIf Line(Line.Length - 1) = " " Then
                'if the last char of line is <space>, then no need to go ahead, the user must have entered Mnemonic
                Exit Sub
            End If

            Virtual8085.GenerateTokens(Line, "", Mnemonic, Operand1, "") 'separate mnemonic from instruction

            '8085 mnemonic length is either 3 or 4 characters
            If (Mnemonic.Length >= 2 Or Mnemonic.Length <= 4) And Operand1 = "" Then
                'Clear help text, then load new help
                rtbIntelligentHelp.Clear()
                LoadIntelligentHelp(Mnemonic)
            End If

            SyntaxHighlightLine(LineNo)
        End If
    End Sub

#End Region 'end UI functions

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

#Region "Button event handlers"

    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
        lbxProgram.Items.Clear()
        For Each line As String In rtbSrc.Lines
            lbxProgram.Items.Add(line)
        Next

        v8085.Initialize()
        Tabs.SelectTab(TabPageOutput)
        Try
            If cbxStepByStep.Checked = False Then
                'btnNext.Enabled = False
                v8085.ExecuteProgram(rtbSrc.Lines)
            Else
                btnNext.Enabled = True
                v8085.ExecuteLineByLine(rtbSrc.Lines)
            End If
        Catch ex As Exception8085
            Tabs.SelectTab(TabPageSource)
            SelectLine(v8085.CurrentLine)
            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'if the user presses Ctrl + F5, then we should run the program.
    Private Sub rtbSrc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rtbSrc.KeyDown
        If e.Control = True And e.KeyCode = Keys.F5 Then
            btnRun.PerformClick()
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Try
            v8085.ExecuteLineByLine(rtbSrc.Lines)
            v8085.Refresh()
        Catch ex As Exception8085
            Tabs.SelectTab(TabPageSource)
            SelectLine(v8085.CurrentLine)
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region 'end button event handlers

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

#Region "V8085 Event handlers"

    Private Sub v8085_InitializationCompleted() Handles v8085.InitializationCompleted
        Tabs.SelectTab(TabPageSource)
        'SplashScr.Close()

        rtbSrc.Select() 'activate the source code rich text box
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub v8085_LineExecuted(ByVal LineNumber As System.Int32) Handles v8085.LineExecuted
        lbxProgram.SelectedIndex = LineNumber
    End Sub

    Private Sub v8085_ProgramExecuted() Handles v8085.ProgramExecuted
        btnNext.Enabled = False
    End Sub

#End Region 'V8085 event handlers end

End Class