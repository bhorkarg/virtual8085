'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'Programmer Name - Gaurav Bhorkar
'Class Name - Virtual8085
'Purpose - To simulate the working of real microprocessor 8085
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

'''''''''
'Working'
'''''''''
'1. Take input the whole program and process it line by line
'2. Generate Tokens ie. seperate the mnemonic, label, operands from lines
'3. Based on the mnemonic, call its corresponding function and pass operands to execute it.
'4. Use cases to accomplish task no 3.
'5. Repeat 2, 3, 4 for next lines to come.
''''''''''''''''''''''''''''''''''''''''''''

''''''''''
'Contents'
''''''''''
'1. All registers (A, B, C, D, E, H, L, SP)
'2. Memory (64 KB)
'3. All functions corresponding to each mnemonic
''''''''''''''''''''''''''''''''''''''''''''''''

''''''''''''''''''''''''''
'Unsupported Instructions'
''''''''''''''''''''''''''
'EI / DI / RIM / SIM / PCHL / IN / OUT
''''''''''''''''''''''''''''''''''''''

'This structure defines the contents of an element "i.e. a label" inside the label table
Structure LabelTable
    Dim Label As String
    Dim LineNo As UInteger
End Structure

Public Class Virtual8085
    Const _1 As Boolean = True
    Const _0 As Boolean = False

#Region "Events"

    Public Event InitializationCompleted()
    Public Event LineExecuted(ByVal LineNumber As Integer)
    Public Event ProgramExecuted()

#End Region

    'Creating a label table for all the "Labels:" which occur in the program
    Private Labels As New List(Of LabelTable)

    ''''''''''''''''''''''''''''''''
    'Counter for program
    Public CurrentLine As Integer
    Dim LastLine As Integer
    ''''''''''''''''''''''''''''''''

    ''''''''''''''''''''''''''''''''''''''''''''''''
    Dim Wbits As New BitArray(8) 'register W's bits
    Dim Zbits As New BitArray(8) 'register Z's bits
    ''''''''''''''''''''''''''''''''''''''''''''''''

    ''''''''''''''''''''''''''''''''''''''''''''''''
    'Arithmetic and logical unit
    Dim ALU As New ALUnit
    ''''''''''''''''''''''''''''''''''''''''''''''''

    ''''''''''''''''''''''''''''''''''''''''''''''''
    'Memory (infact AddressBus)
    Public Memory As New AddressBus
    ''''''''''''''''''''''''''''''''''''''''''''''''

    Dim HLMemoryIndex As String 'contents of the HL pair in HexString format, so that memory can be indexed more easily


#Region "Event Handlers"
    Private Sub Flags_BitsChanged() Handles F.BitsChanged, F.BitChanged
        lblFlags.Text = String.Empty
        For Each bit As Boolean In F.bits
            If bit = _1 Then
                lblFlags.Text += "1"
            ElseIf bit = _0 Then
                lblFlags.Text += "0"
            End If
            lblFlags.Text += "   "
        Next
    End Sub

#End Region


#Region "Publicly available functions"
    Public Sub Initialize()
        CurrentLine = 0
        MVI("A", "00")
        LXI("B", "0000")
        LXI("D", "0000")
        LXI("H", "0000")
        LXI("SP", "0000")
        F.bits = Conversion.FromHexToBin("00")
    End Sub

    Public Shared Sub GenerateTokens(ByVal Instr As String, ByRef Label As String, ByRef Mnemonic As String, ByRef Operand1 As String, ByRef Operand2 As String)
        Instr = Instr.Trim()
        Dim delimiters() As Char = {" ", ",", ControlChars.Tab} 'separate string based on delimiters
        Dim DelimitedStrings() As String = Instr.Split(delimiters)

        For Each DelimitedString In DelimitedStrings
            If DelimitedString = "" Then
                Continue For
            ElseIf DelimitedString.StartsWith(";") Then
                'if the delimited string is a comment then no need to go ahead
                Exit For

            Else

                If Label = String.Empty And DelimitedString.EndsWith(":") Then
                    Label = DelimitedString
                ElseIf Mnemonic = String.Empty Then
                    Mnemonic = DelimitedString
                Else
                    If Operand1 = String.Empty Then
                        Operand1 = DelimitedString
                    Else
                        If Operand2 = String.Empty Then
                            Operand2 = DelimitedString
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Public Sub ExecuteProgram(ByVal ProgramLines As String())
        'load labels from the programs (if present)
        LoadLabels(ProgramLines)

        LastLine = ProgramLines.Length - 1
        CurrentLine = 0

        While CurrentLine <= LastLine
            RaiseEvent LineExecuted(CurrentLine)
            ExecuteInstruction(ProgramLines(CurrentLine))

            CurrentLine += 1
        End While
    End Sub

    Public Sub ExecuteLineByLine(ByVal ProgramLines As String())
        Static AreLabelsLoaded As Boolean = False

        If AreLabelsLoaded = False Then
            LoadLabels(ProgramLines)
        End If

        LastLine = ProgramLines.Length - 1

        If CurrentLine <= LastLine Then
            RaiseEvent LineExecuted(CurrentLine)
            ExecuteInstruction(ProgramLines(CurrentLine))

            CurrentLine += 1
        End If
    End Sub

#End Region


#Region "Private (Internal Functions)"

    Private Sub LoadLabels(ByRef ProgramLines As String())
        Labels.Clear()
        For i As Integer = 0 To (ProgramLines.Length - 1)
            Dim Label As String = ""
            GenerateTokens(ProgramLines(i).ToUpper(), Label, "", "", "")
            If Label <> String.Empty Then
                Dim LT As New LabelTable
                LT.Label = Label.TrimEnd(":")
                LT.LineNo = i
                'add this new label to the list of labels
                Labels.Add(LT)
            End If
        Next
    End Sub

    Private Sub CheckOperandValidity(ByRef Mnemonic As String, ByRef Opr1 As String, ByRef Opr2 As String)

        'Now checking the no of operands accepted by mnemonics
        Select Case Mnemonic

            ''''Instructions with 0 operands
            Case "XCHG", "SPHL", "HTHL", "DAA", "RET", "RC", "RP", "RM", "RZ", "RNZ", "RPE", "RPO", "PCHL", _
            "RLC", "RRC", "RAL", "RAR", "CMA", "CMC", "STC", "NOP", "HLT", "DI", "EI", "SIM"
                If Opr1 <> String.Empty Or Opr2 <> String.Empty Then
                    Throw New Exception8085("Instruction accepts no operands")
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Instructions with 1 operand
            Case "LDA", "LDAX", "LHLD", "STA", "STAX", "SHLD", "PUSH", "POP", "IN", "OUT", "ADD", "ADC", _
            "ACI", "ADI", "DAD", "SUB", "SBB", "SUI", "SBI", "INR", "INX", "DCR", "DCX", "CMP", "CPI", "ANA", _
            "ANI", "ORA", "ORI", "XRA", "XRI", "RST"
                If Opr1 = String.Empty Then
                    Throw New Exception8085("Operand not specified")
                End If
                If Opr2 <> String.Empty Then
                    Throw New Exception8085("Instruction accepts only 1 operand")
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Jumping Instructions
            Case "JMP", "JC", "JNC", "JP", "JM", "JZ", "JNZ", "JPE", "JPO", _
        "CALL", "CC", "CNC", "CP", "CM", "CZ", "CNZ", "CPE", "CPO"
                If Opr1 = String.Empty Then
                    Throw New Exception8085("Operand not specified")
                End If
                If Opr2 <> String.Empty Then
                    Throw New Exception8085("Instruction accepts only 1 operand")
                End If
                Exit Sub 'do not go forward and alter the operand (it is a label)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Instructions with 2 operands
            Case "MOV", "MVI", "LXI"
                If Opr1 = String.Empty Or Opr2 = String.Empty Then
                    Throw New Exception8085("Operand not specified")
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'if mnemonic is a blank then do nothing
            Case "", " ", "!"
                'do nothing

            Case Else
                Throw New Exception8085("Invalid Instruction")
        End Select

        '''''''''''''''''''''''''''''''''''''''''''''''
        'Now checking and modifying each operand
        '''''''''''''''''''''''''''''''''''''''''''''''

        'checking and modifying operand1
        If Opr1.Length > 1 Then
            Opr1 = Opr1.TrimEnd("H")
            'determining if there is a syntax error. Ex. AF is wrong, 0AF is right
            If Opr1(0) >= "A" And Opr1(0) <= "F" Then
                Throw New Exception8085("Syntax Error!")
            End If

            'leaving out the first zero. Ex. 0AF becomes AF
            If (Opr1.Length = 3 Or Opr1.Length = 5) And Opr1(0) = "0" Then
                Opr1 = Opr1.Substring(1) 'leave out the first zero
            End If
        End If

        'checking and modifying operand2
        If Opr2.Length > 1 Then
            Opr2 = Opr2.TrimEnd("H")
            'determining if there is a syntax error. Ex. AF is wrong, 0AF is right
            If Opr2(0) >= "A" And Opr2(0) <= "F" Then
                Throw New Exception8085("Syntax Error!")
            End If

            'leaving out the first zero. Ex. 0AF becomes AF
            If (Opr2.Length = 3 Or Opr2.Length = 5) And Opr2(0) = "0" Then
                Opr2 = Opr2.Substring(1) 'leave out the first zero
            End If
        End If
    End Sub

    Private Sub ExecuteInstruction(ByVal strLine As String)
        strLine = strLine.ToUpper()

        Dim Mnemonic, Operand1, Operand2 As String
        'Initializing everything to empty
        Mnemonic = String.Empty
        Operand1 = String.Empty
        Operand2 = String.Empty

        GenerateTokens(strLine, "", Mnemonic, Operand1, Operand2) 'separate mnemonic and operands

        'determining the value of memory pointer in HL pair
        HLMemoryIndex = Conversion.FromBinToHex(H.bits) & Conversion.FromBinToHex(L.bits)

        'now checking the validity of operands
        CheckOperandValidity(Mnemonic, Operand1, Operand2)

        'control will move forward only if CheckOperandValidity sub doesn't throw exception
        Select Case Mnemonic

            Case ""
                'if there is nothing in the mnemonic, then do nothing

                ''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''DATA TRANSFER INSTRUCTIONS''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''

            Case "MVI"
                MVI(Operand1, Operand2)

            Case "MOV"
                MOV(Operand1, Operand2)

            Case "LXI"
                LXI(Operand1, Operand2)

            Case "LDAX"
                LDAX(Operand1)

            Case "LDA"
                LDA(Operand1)

            Case "STAX"
                STAX(Operand1)

            Case "STA"
                STA(Operand1)

            Case "XCHG"
                XCHG()

            Case "LHLD"
                LHLD(Operand1)

            Case "SHLD"
                SHLD(Operand1)

            Case "SPHL"
                SPHL()

            Case "PUSH"
                PUSH(Operand1)

            Case "POP"
                POP(Operand1)

            Case "XTHL"
                XTHL()

            Case "IN", "OUT"
                Throw New Exception8085("IN / OUT is not yet supported in Virtual 8085")


                ''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''Arithmetic Instructions''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''

            Case "ADD"
                ADD(Operand1)

            Case "ADI"
                ADI(Operand1)

            Case "ADC"
                ADC(Operand1)

            Case "ACI"
                ACI(Operand1)

            Case "DAD"
                DAD(Operand1)

            Case "DAA"
                DAA()

            Case "SUB"
                SUBT(Operand1)

            Case "SUI"
                SUI(Operand1)

            Case "SBB"
                SBB(Operand1)

            Case "SBI"
                SBI(Operand1)

            Case "INR"
                INR(Operand1)

            Case "DCR"
                DCR(Operand1)

            Case "INX"
                INX(Operand1)

            Case "DCX"
                DCX(Operand1)


                ''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''Logical Instructions''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''
            Case "CMP"
                CMP(Operand1)

            Case "CPI"
                CPI(Operand1)

            Case "ANA"
                ANA(Operand1)

            Case "ANI"
                ANI(Operand1)

            Case "ORA"
                ORA(Operand1)

            Case "ORI"
                ORI(Operand1)

            Case "XRA"
                XRA(Operand1)

            Case "XRI"
                XRI(Operand1)

            Case "STC"
                STC()

            Case "CMC"
                CMC()

            Case "CMA"
                CMA()

            Case "RLC"
                RLC()

            Case "RAL"
                RAL()

            Case "RRC"
                RRC()

            Case "RAR"
                RAR()


                ''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''Branching Instructions''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''
            Case "PCHL"
                'PCHL is not supported'
                Throw New Exception8085("PCHL is not yet supported by Virtual 8085, Please use JMP instead")

            Case "JMP"
                JMP(Operand1)

            Case "JC", "JNC", "JZ", "JNZ", "JPE", "JPO", "JP", "JM"
                JCondition(Mnemonic, Operand1)

            Case "CALL"
                CALLX(Operand1)

            Case "CC", "CNC", "CZ", "CNZ", "CPE", "CPO", "CP", "CM"
                CCondition(Mnemonic, Operand1)

            Case "RET"
                RET()

            Case "RC", "RNC", "RZ", "RNZ", "RPE", "RPO", "RP", "RM"
                RCondition(Mnemonic, Operand1)


                '''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''Control Instructions'''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''

            Case "HLT"
                HLT()

            Case "NOP"
                NOP()

            Case "RST"
                RST(Operand1)

            Case "EI", "DI", "RIM", "SIM"
                'unsupported instructions'
                Throw New Exception8085("EI / DI / RIM / SIM are not yet supported in Virtual 8085")

            Case Else
                Throw New Exception8085("Invalid instruction")
        End Select
    End Sub

#End Region 'Private instructions end

#Region "Instruction Subroutines"

#Region "Data Transfer Instructions"

    Private Sub MVI(ByVal DestReg As String, ByVal Data8 As String)
        If Data8.Length <> 2 Then
            Throw New Exception8085("Only 8 bit second operand can be specified in MVI instruction")
        End If

        Select Case DestReg
            Case "A"
                A.bits = Conversion.FromHexToBin(Data8)
            Case "B"
                B.bits = Conversion.FromHexToBin(Data8)
            Case "C"
                C.bits = Conversion.FromHexToBin(Data8)
            Case "D"
                D.bits = Conversion.FromHexToBin(Data8)
            Case "E"
                E.bits = Conversion.FromHexToBin(Data8)
            Case "H"
                H.bits = Conversion.FromHexToBin(Data8)
            Case "L"
                L.bits = Conversion.FromHexToBin(Data8)
            Case "M"
                Memory.bits(HLMemoryIndex) = Conversion.FromHexToBin(Data8)
            Case Else
                Throw New Exception8085("Invalid Register Specified")
        End Select
    End Sub

    Private Sub MOV(ByVal DestReg As String, ByVal SrcReg As String)
        'copying the source register into W
        Select Case SrcReg
            Case "A"
                Wbits = A.bits
            Case "B"
                Wbits = B.bits
            Case "C"
                Wbits = C.bits
            Case "D"
                Wbits = D.bits
            Case "E"
                Wbits = E.bits
            Case "H"
                Wbits = H.bits
            Case "L"
                Wbits = L.bits
            Case "M"
                Wbits = Memory.bits(HLMemoryIndex)
            Case Else
                Throw New Exception8085("Invalid source")
        End Select
        'writing the source register (copied into W) to the destination register
        Select Case DestReg
            Case "A"
                A.bits = Wbits
            Case "B"
                B.bits = Wbits
            Case "C"
                C.bits = Wbits
            Case "D"
                D.bits = Wbits
            Case "E"
                E.bits = Wbits
            Case "H"
                H.bits = Wbits
            Case "L"
                L.bits = Wbits
            Case "M"
                Memory.bits(HLMemoryIndex) = Wbits
            Case Else
                Throw New Exception8085("Invalid destination")
        End Select
    End Sub

    Private Sub LXI(ByVal DestRp As String, ByVal Data16 As String)
        If Data16.Length <> 4 Then
            Throw New Exception8085("Second operand should be 16 bit immediate data")
        End If
        'determining the msb and lsb bits
        Wbits = Conversion.FromHexToBin(Data16.Substring(0, 2)) 'msb
        Zbits = Conversion.FromHexToBin(Data16.Substring(2, 2)) 'lsb

        'writing the msb and lsb to destination register pair
        Select Case DestRp
            Case "B"
                'LXI B, Data16
                B.bits = Wbits
                C.bits = Zbits
            Case "D"
                'LXI D, Data16
                D.bits = Wbits
                E.bits = Zbits
            Case "H"
                'LXI H, Data16
                H.bits = Wbits
                L.bits = Zbits
            Case "SP"
                SP.bits = Conversion.FromHexToBin(Data16)
            Case Else
                Throw New Exception8085("Invalid destination register pair")
        End Select
    End Sub

    Private Sub LDAX(ByVal RegPair As String)
        Dim HexMemoryIndex As String
        Select Case RegPair
            'location is pointed by either BC or DE pairs
            Case "B"
                HexMemoryIndex = Conversion.FromBinToHex(B.bits) & Conversion.FromBinToHex(C.bits)
            Case "D"
                HexMemoryIndex = Conversion.FromBinToHex(D.bits) & Conversion.FromBinToHex(E.bits)
            Case Else
                Throw New Exception8085("Invalid register pair")
        End Select

        'loading Acc from memory
        A.bits = Memory.bits(HexMemoryIndex)
    End Sub

    Private Sub LDA(ByVal Addr16 As String)
        If Addr16.Length <> 4 Then
            Throw New Exception8085("16 bit address must be specified")
        End If
        A.bits = Memory.bits(Addr16)
    End Sub

    Private Sub STAX(ByVal RegPair As String)
        Dim HexIndex As String
        Select Case RegPair
            'location is pointed by either BC or DE pairs
            Case "B"
                HexIndex = Conversion.FromBinToHex(B.bits) & Conversion.FromBinToHex(C.bits)
            Case "D"
                HexIndex = Conversion.FromBinToHex(D.bits) & Conversion.FromBinToHex(E.bits)
            Case Else
                Throw New Exception8085("Invalid register pair")
        End Select

        'storing Acc into memory
        Memory.bits(HexIndex) = A.bits
    End Sub

    Private Sub STA(ByVal Addr16 As String)
        If Addr16.Length <> 4 Then
            Throw New Exception8085("16 bit address must be specified")
        End If
        Memory.bits(Addr16) = A.bits
    End Sub

    Private Sub XCHG()
        Wbits = H.bits
        Zbits = L.bits

        H.bits = D.bits
        L.bits = E.bits

        D.bits = Wbits
        E.bits = Zbits
    End Sub

    Private Sub LHLD(ByVal Addr16 As String)
        If Addr16.Length <> 4 Then
            Throw New Exception8085("16 bit address must be specified")
        End If

        Dim NextAddress As UInteger = Conversion.FromHexToDec(Addr16) + 1
        L.bits = Memory.bits(Addr16)
        H.bits = Memory.bits(NextAddress.ToString("X4"))
    End Sub

    Private Sub SHLD(ByVal Addr16 As String)
        If Addr16.Length <> 4 Then
            Throw New Exception8085("16 bit address must be specified")
        End If

        Dim NextAddress As UInteger = Conversion.FromHexToDec(Addr16) + 1
        Memory.bits(Addr16) = L.bits
        Memory.bits(NextAddress.ToString("X4")) = H.bits
    End Sub

    Private Sub SPHL()
        'copy contents of HL into SP
        Dim NewBits As New BitArray(16)
        For i As Integer = 0 To 7
            NewBits(i) = H.bits(i)
            NewBits(i + 8) = L.bits(i)
        Next
        SP.bits = NewBits
    End Sub

    Private Sub PUSH(ByVal RegPair As String)
        Select Case RegPair
            Case "B"
                Wbits = B.bits
                Zbits = C.bits
            Case "D"
                Wbits = D.bits
                Zbits = E.bits
            Case "H"
                Wbits = H.bits
                Zbits = L.bits
            Case "PSW"
                Wbits = A.bits
                Zbits = F.bits
            Case "_PC"
                Dim HexValue As String = CurrentLine.ToString("X4")
                Wbits = Conversion.FromHexToBin(HexValue.Substring(0, 2))
                Zbits = Conversion.FromHexToBin(HexValue.Substring(2, 2))
            Case Else
                Throw New Exception8085("Invalid register pair specified")
        End Select

        SP.bits = Conversion.FromHexToBin(ALU.Decrement16(SP.H, SP.L)) 'decrement Sp
        Memory.bits(Conversion.FromBinToHex(SP.bits)) = Wbits 'store Higher register

        SP.bits = Conversion.FromHexToBin(ALU.Decrement16(SP.H, SP.L)) 'decrement Sp
        Memory.bits(Conversion.FromBinToHex(SP.bits)) = Zbits 'store lower register
    End Sub

    Private Sub POP(ByVal RegPair As String)

        Zbits = Memory.bits(Conversion.FromBinToHex(SP.bits)) 'store lower register
        SP.bits = Conversion.FromHexToBin(ALU.Increment16(SP.H, SP.L)) 'increment SP

        Wbits = Memory.bits(Conversion.FromBinToHex(SP.bits)) 'store Higher register
        SP.bits = Conversion.FromHexToBin(ALU.Increment16(SP.H, SP.L)) 'increment SP

        Select Case RegPair
            Case "B"
                B.bits = Wbits
                C.bits = Zbits
            Case "D"
                D.bits = Wbits
                E.bits = Zbits
            Case "H"
                H.bits = Wbits
                L.bits = Zbits
            Case "PSW"
                A.bits = Wbits
                F.bits = Zbits
            Case "_W"
                'do nothing, the tos is already popped in WZ pair
            Case Else
                'decrement sp two times
                SP.bits = Conversion.FromHexToBin(ALU.Decrement16(SP.H, SP.L)) 'decrement Sp
                SP.bits = Conversion.FromHexToBin(ALU.Decrement16(SP.H, SP.L)) 'decrement Sp

                Throw New Exception8085("Invalid register pair specified")
        End Select
        'select the TOS memory location
    End Sub

    Private Sub XTHL()
        POP("_W") 'stored tos in WZ

        'saving WZ pair into temp variables
        Dim Hbits As New BitArray(8)
        Dim Lbits As New BitArray(8)
        Hbits = Wbits
        Lbits = Zbits

        PUSH("H") 'pushed HL into tos

        'now store WZ into HL
        H.bits = Hbits
        L.bits = Lbits
    End Sub

#End Region 'Data transfer instructions end


#Region "Arithmetic Instructions"

    Private Sub ADD(ByVal SrcReg As String, Optional ByVal Carry As Boolean = _0)

        Dim Fbits As New BitArray(8)

        Select Case SrcReg
            Case "A"
                A.bits = ALU.Addition(A.bits, A.bits, Fbits, Carry)
            Case "B"
                A.bits = ALU.Addition(A.bits, B.bits, Fbits, Carry)
            Case "C"
                A.bits = ALU.Addition(A.bits, C.bits, Fbits, Carry)
            Case "D"
                A.bits = ALU.Addition(A.bits, D.bits, Fbits, Carry)
            Case "E"
                A.bits = ALU.Addition(A.bits, E.bits, Fbits, Carry)
            Case "H"
                A.bits = ALU.Addition(A.bits, H.bits, Fbits, Carry)
            Case "L"
                A.bits = ALU.Addition(A.bits, L.bits, Fbits, Carry)
            Case "M"
                Dim HexIndex As String = Conversion.FromBinToHex(H.bits) & Conversion.FromBinToHex(L.bits)
                A.bits = ALU.Addition(A.bits, Memory.bits(HexIndex), Fbits, Carry)
            Case Else
                Throw New Exception8085("Invalid register")
        End Select
        F.bits = Fbits 'copy flag bits into flags
    End Sub

    Private Sub ADI(ByVal Data8 As String, Optional ByVal Carry As Boolean = _0)
        If Data8.Length <> 2 Then
            Throw New Exception8085("8 bit data required")
        End If

        Dim Fbits As New BitArray(8)
        Wbits = Conversion.FromHexToBin(Data8) 'converting into bits hexadecimal data8

        A.bits = ALU.Addition(A.bits, Wbits, Fbits, Carry)
        F.bits = Fbits
    End Sub

    Private Sub ADC(ByVal SrcReg As String)
        Dim CF As Boolean
        CF = F.bits(7) 'the last bit is the Carry Flag

        ADD(SrcReg, CF)
    End Sub

    Private Sub ACI(ByVal Data8 As String)
        Dim CF As Boolean
        CF = F.bits(7) 'the last bit is the Carry Flag

        ADI(Data8, CF)
    End Sub

    Private Sub DAD(ByVal RegPair As String)
        Dim Fbits As New BitArray(8)
        Select Case RegPair
            Case "B"
                L.bits = ALU.Addition(L.bits, C.bits, Fbits)
                H.bits = ALU.Addition(H.bits, B.bits, Fbits, Fbits(7)) '7th Fbit is CF
            Case "D"
                L.bits = ALU.Addition(L.bits, E.bits, Fbits)
                H.bits = ALU.Addition(H.bits, D.bits, Fbits, Fbits(7)) '7th Fbit is CF
            Case "H"
                L.bits = ALU.Addition(L.bits, L.bits, Fbits)
                H.bits = ALU.Addition(H.bits, H.bits, Fbits, Fbits(7)) '7th Fbit is CF
            Case "SP"
                L.bits = ALU.Addition(L.bits, SP.L, Fbits)
                H.bits = ALU.Addition(H.bits, SP.H, Fbits, Fbits(7)) '7th Fbit is CF
            Case Else
                Throw New Exception8085("Invalid register pair specified")
        End Select
        F.bits.Item(7) = Fbits(7) 'only CF is changed in DAD instr
    End Sub

    Private Sub DAA()
        Dim IntLsb As UInteger = Conversion.FromHexToDec(Conversion.FromBinToHex(A.lsb4))

        Dim Fbits As New BitArray(8)

        If F.bits(3) = _1 Or IntLsb > 9 Then
            A.bits = ALU.Addition(A.bits, Conversion.FromHexToBin("06"), Fbits)

            Dim IntMsb As UInteger = Conversion.FromHexToDec(Conversion.FromBinToHex(A.msb4))

            'now setting CF
            If Fbits(7) = _1 Then
                F.bits(7) = _1
            End If

            If F.bits(7) = _1 Or IntMsb > 9 Then
                A.bits = ALU.Addition(A.bits, Conversion.FromHexToBin("60"), Fbits)
            End If
        End If

        'setting the flags
        F.bits(5) = Fbits(5)
        F.bits(3) = Fbits(3)
        F.bits(1) = Fbits(1)
        F.bits(0) = Fbits(0)
        'setting CF
        If Fbits(7) = _1 Then
            F.bits(7) = _1
        End If

        Flags_BitsChanged()
    End Sub

    Private Sub SUBT(ByVal SrcReg As String, Optional ByVal Borrow As Boolean = _0)
        Dim Fbits As New BitArray(8)

        Select Case SrcReg
            Case "A"
                Wbits = A.bits
            Case "B"
                Wbits = B.bits
            Case "C"
                Wbits = C.bits
            Case "D"
                Wbits = D.bits
            Case "E"
                Wbits = E.bits
            Case "H"
                Wbits = H.bits
            Case "L"
                Wbits = L.bits
            Case "M"
                Wbits = Memory.bits(HLMemoryIndex)
            Case Else
                Throw New Exception8085("Invalid Register specified")
        End Select

        'subtracting with borrow, if no borrow is there then it makes no difference because the default borrow is 0
        A.bits = ALU.Subtraction(A.bits, Wbits, Fbits, Borrow)

        F.bits = Fbits

        'now inverting AC and CF because they are borrows not carrys
        F.InvertFlag("CF")
        F.InvertFlag("AC")
    End Sub

    Private Sub SUI(ByVal Data8 As String, Optional ByVal Borrow As Boolean = _0)
        If Data8.Length <> 2 Then
            Throw New Exception8085("8 bit data required")
        End If

        Wbits = Conversion.FromHexToBin(Data8) 'Storing Data8 into temporary bitarray

        Dim Fbits As New BitArray(8)

        A.bits = ALU.Subtraction(A.bits, Wbits, Fbits, Borrow)
        F.bits = Fbits

        'inverting AC and CF
        F.InvertFlag("CF")
        F.InvertFlag("AC")
    End Sub

    Private Sub SBB(ByVal SrcReg As String)
        SUBT(SrcReg, F.bits(7)) '7th fbit is the CF
    End Sub

    Private Sub SBI(ByVal Data8 As String)
        SUI(Data8, F.bits(7)) 'F.bits(7) is the Carry flag, ie. we are subtracting with borrow
    End Sub

    Private Sub INR(ByVal Reg As String)
        Dim Fbits As New BitArray(8)
        Select Case Reg
            Case "A"
                A.bits = ALU.Increment8(A.bits, Fbits)
            Case "B"
                B.bits = ALU.Increment8(B.bits, Fbits)
            Case "C"
                C.bits = ALU.Increment8(C.bits, Fbits)
            Case "D"
                D.bits = ALU.Increment8(D.bits, Fbits)
            Case "E"
                E.bits = ALU.Increment8(E.bits, Fbits)
            Case "H"
                H.bits = ALU.Increment8(H.bits, Fbits)
            Case "L"
                H.bits = ALU.Increment8(L.bits, Fbits)
            Case "M"
                Memory.bits(HLMemoryIndex) = ALU.Increment8(Memory.bits(HLMemoryIndex), Fbits)
            Case Else
                Throw New Exception8085("Invalid register specified")
        End Select

        'not changing CF, ie the 7th bit
        For i As Integer = 0 To 6
            F.bits(i) = Fbits(i)
        Next
        Flags_BitsChanged()
    End Sub

    Private Sub DCR(ByVal Reg As String)
        Dim Fbits As New BitArray(8)
        Select Case Reg
            Case "A"
                A.bits = ALU.Decrement8(A.bits, Fbits)
            Case "B"
                B.bits = ALU.Decrement8(B.bits, Fbits)
            Case "C"
                C.bits = ALU.Decrement8(C.bits, Fbits)
            Case "D"
                D.bits = ALU.Decrement8(D.bits, Fbits)
            Case "E"
                E.bits = ALU.Decrement8(E.bits, Fbits)
            Case "H"
                H.bits = ALU.Decrement8(H.bits, Fbits)
            Case "L"
                H.bits = ALU.Decrement8(L.bits, Fbits)
            Case "M"
                Memory.bits(HLMemoryIndex) = ALU.Decrement8(Memory.bits(HLMemoryIndex), Fbits)
            Case Else
                Throw New Exception8085("Invalid register specified")
        End Select

        'not changing CF, ie the 7th bit
        For i As Integer = 0 To 6
            F.bits(i) = Fbits(i)
        Next

        F.InvertFlag("AC") 'inverting AC flag because it is a borrow not a carry
    End Sub

    Private Sub INX(ByVal RegPair As String)
        Dim InxValue As String
        Select Case RegPair
            Case "B"
                InxValue = ALU.Increment16(B.bits, C.bits)
                B.bits = Conversion.FromHexToBin(InxValue.Substring(0, 2)) 'first 2 digits of Hex value
                C.bits = Conversion.FromHexToBin(InxValue.Substring(2, 2)) 'last 2 digits of Hex value
            Case "D"
                InxValue = ALU.Increment16(D.bits, E.bits)
                D.bits = Conversion.FromHexToBin(InxValue.Substring(0, 2)) 'first 2 digits of Hex value
                E.bits = Conversion.FromHexToBin(InxValue.Substring(2, 2)) 'last 2 digits of Hex value
            Case "H"
                InxValue = ALU.Increment16(H.bits, L.bits)
                H.bits = Conversion.FromHexToBin(InxValue.Substring(0, 2)) 'first 2 digits of Hex value
                L.bits = Conversion.FromHexToBin(InxValue.Substring(2, 2)) 'last 2 digits of Hex value
            Case "SP"
                InxValue = ALU.Increment16(SP.H, SP.L)
                SP.bits = Conversion.FromHexToBin(InxValue)
            Case Else
                Throw New Exception8085("Invalid register pair specified")
        End Select
    End Sub

    Private Sub DCX(ByVal RegPair As String)
        Dim InxValue As String
        Select Case RegPair
            Case "B"
                InxValue = ALU.Decrement16(B.bits, C.bits)
                B.bits = Conversion.FromHexToBin(InxValue.Substring(0, 2)) 'first 2 digits of Hex value
                C.bits = Conversion.FromHexToBin(InxValue.Substring(2, 2)) 'last 2 digits of Hex value
            Case "D"
                InxValue = ALU.Decrement16(D.bits, E.bits)
                D.bits = Conversion.FromHexToBin(InxValue.Substring(0, 2)) 'first 2 digits of Hex value
                E.bits = Conversion.FromHexToBin(InxValue.Substring(2, 2)) 'last 2 digits of Hex value
            Case "H"
                InxValue = ALU.Decrement16(H.bits, L.bits)
                H.bits = Conversion.FromHexToBin(InxValue.Substring(0, 2)) 'first 2 digits of Hex value
                L.bits = Conversion.FromHexToBin(InxValue.Substring(2, 2)) 'last 2 digits of Hex value
            Case "SP"
                InxValue = ALU.Decrement16(SP.H, SP.L)
                SP.bits = Conversion.FromHexToBin(InxValue)
            Case Else
                Throw New Exception8085("Invalid register pair specified")
        End Select
    End Sub
#End Region 'Arithmetic instructions end


#Region "Logical Instructions"

    Private Sub CMP(ByVal SrcReg As String)
        Dim Fbits As New BitArray(8)

        Select Case SrcReg
            Case "A"
                Wbits = A.bits
            Case "B"
                Wbits = B.bits
            Case "C"
                Wbits = C.bits
            Case "D"
                Wbits = D.bits
            Case "E"
                Wbits = E.bits
            Case "H"
                Wbits = H.bits
            Case "L"
                Wbits = L.bits
            Case "M"
                Wbits = Memory.bits(HLMemoryIndex)
            Case Else
                Throw New Exception8085("Invalid Register specified")
        End Select

        'subtracting with borrow, if no borrow is there then it makes no difference because the default borrow is 0
        ALU.Subtraction(A.bits, Wbits, Fbits, _0)

        F.bits = Fbits

        'now inverting AC and CF because they are borrows not carrys
        F.InvertFlag("CF")
        F.InvertFlag("AC")
    End Sub

    Private Sub CPI(ByVal Data8 As String)
        If Data8.Length <> 2 Then
            Throw New Exception8085("8 bit data required")
        End If

        Wbits = Conversion.FromHexToBin(Data8)

        Dim Fbits As New BitArray(8)

        ALU.Subtraction(A.bits, Wbits, Fbits, _0)
        F.bits = Fbits

        'inverting AC and CF
        F.InvertFlag("CF")
        F.InvertFlag("AC")
    End Sub

    Private Sub ANA(ByVal Reg As String)
        Dim Fbits As New BitArray(8)
        Select Case Reg
            Case "A"
                Wbits = A.bits
            Case "B"
                Wbits = B.bits
            Case "C"
                Wbits = C.bits
            Case "D"
                Wbits = D.bits
            Case "E"
                Wbits = E.bits
            Case "H"
                Wbits = H.bits
            Case "L"
                Wbits = L.bits
            Case "M"
                Wbits = Memory.bits(HLMemoryIndex)
            Case Else
                Throw New Exception8085("Invalid register")
        End Select

        A.bits = ALU.ANDing(A.bits, Wbits, Fbits)
        F.bits = Fbits
    End Sub

    Private Sub ANI(ByVal Data8 As String)
        If Data8.Length <> 2 Then
            Throw New Exception8085("8 bit data required")
        End If

        Wbits = Conversion.FromHexToBin(Data8)
        Dim Fbits As New BitArray(8)

        A.bits = ALU.ANDing(A.bits, Wbits, Fbits)
        F.bits = Fbits
    End Sub

    Private Sub ORA(ByVal Reg As String)
        Dim Fbits As New BitArray(8)
        Select Case Reg
            Case "A"
                Wbits = A.bits
            Case "B"
                Wbits = B.bits
            Case "C"
                Wbits = C.bits
            Case "D"
                Wbits = D.bits
            Case "E"
                Wbits = E.bits
            Case "H"
                Wbits = H.bits
            Case "L"
                Wbits = L.bits
            Case "M"
                Wbits = Memory.bits(HLMemoryIndex)
            Case Else
                Throw New Exception8085("Invalid register")
        End Select

        A.bits = ALU.ORing(A.bits, Wbits, Fbits)
        F.bits = Fbits
    End Sub

    Private Sub ORI(ByVal Data8 As String)
        If Data8.Length <> 2 Then
            Throw New Exception8085("8 bit data required")
        End If

        Wbits = Conversion.FromHexToBin(Data8)
        Dim Fbits As New BitArray(8)

        A.bits = ALU.ORing(A.bits, Wbits, Fbits)
        F.bits = Fbits
    End Sub

    Private Sub XRA(ByVal Reg As String)
        Dim Fbits As New BitArray(8)
        Select Case Reg
            Case "A"
                Wbits = A.bits
            Case "B"
                Wbits = B.bits
            Case "C"
                Wbits = C.bits
            Case "D"
                Wbits = D.bits
            Case "E"
                Wbits = E.bits
            Case "H"
                Wbits = H.bits
            Case "L"
                Wbits = L.bits
            Case "M"
                Wbits = Memory.bits(HLMemoryIndex)
            Case Else
                Throw New Exception8085("Invalid register")
        End Select

        A.bits = ALU.XORing(A.bits, Wbits, Fbits)
        F.bits = Fbits
    End Sub

    Private Sub XRI(ByVal Data8 As String)
        If Data8.Length <> 2 Then
            Throw New Exception8085("8 bit data required")
        End If

        Wbits = Conversion.FromHexToBin(Data8)
        Dim Fbits As New BitArray(8)

        A.bits = ALU.XORing(A.bits, Wbits, Fbits)
        F.bits = Fbits
    End Sub

    Private Sub STC()
        F.bits(7) = _1
        Flags_BitsChanged()
    End Sub

    Private Sub CMC()
        F.InvertFlag("CF")
    End Sub

    Private Sub CMA()
        Dim NewBits As New BitArray(8)

        For i As Integer = 0 To 7
            If A.bits(i) = _1 Then
                NewBits(i) = _0
            Else
                NewBits(i) = _1
            End If
        Next

        A.bits = NewBits
    End Sub


    Private Sub RLC()
        Dim NewBits As New BitArray(8)

        'example 10011111 -> 00111111 with 1 being transferred in CF
        F.SetFlagStatus("CF", A.bits(0)) 'only CF is changed

        For i As Integer = 1 To 7
            NewBits(i - 1) = A.bits(i)
        Next
        NewBits(7) = A.bits(0)

        A.bits = NewBits
    End Sub

    Private Sub RAL()
        Dim NewBits As New BitArray(8)

        NewBits(7) = F.GetFlagStatus("CF")
        F.SetFlagStatus("CF", A.bits(0))

        For i As Integer = 1 To 7
            NewBits(i - 1) = A.bits(i)
        Next

        A.bits = NewBits
    End Sub

    Private Sub RRC()
        Dim NewBits As New BitArray(8)

        'example 10011111 -> 00111111 with 1 being transferred in CF
        F.SetFlagStatus("CF", A.bits(7)) 'only CF is changed

        For i As Integer = 1 To 7
            NewBits(i) = A.bits(i - 1)
        Next
        NewBits(0) = A.bits(7)

        A.bits = NewBits
    End Sub

    Private Sub RAR()
        Dim NewBits As New BitArray(8)

        NewBits(0) = F.GetFlagStatus("CF")
        F.SetFlagStatus("CF", A.bits(7))

        For i As Integer = 1 To 7
            NewBits(i) = A.bits(i - 1)
        Next

        A.bits = NewBits
    End Sub
#End Region 'logical instructions end


#Region "Branching instructions"

    Private Sub JMP(ByVal TargetLabel As String)
        For Each Lbl As LabelTable In Labels
            If Lbl.Label = TargetLabel Then
                'change the program counter
                CurrentLine = Lbl.LineNo - 1 ' minus 1 because CurrentLine will be incremented once the control goes back
                'to execute next line
                Return
            End If
        Next

        Throw New Exception8085("No Label found!")
    End Sub

    Private Sub JCondition(ByVal JInstr As String, ByVal TargetLabel As String)
        Dim CanJump As Boolean = False

        Select Case JInstr
            Case "JC"
                If F.GetFlagStatus("CF") = _1 Then
                    CanJump = True
                End If

            Case "JNC"
                If F.GetFlagStatus("CF") = _0 Then
                    CanJump = True
                End If

            Case "JZ"
                If F.GetFlagStatus("ZF") = _1 Then
                    CanJump = True
                End If

            Case "JNZ"
                If F.GetFlagStatus("ZF") = _0 Then
                    CanJump = True
                End If

            Case "JP"
                If F.GetFlagStatus("SF") = _0 Then
                    CanJump = True
                End If

            Case "JM"
                If F.GetFlagStatus("SF") = _1 Then
                    CanJump = True
                End If

            Case "JPE"
                If F.GetFlagStatus("PF") = _1 Then
                    CanJump = True
                End If

            Case "JPO"
                If F.GetFlagStatus("PF") = _0 Then
                    CanJump = True
                End If
        End Select

        If CanJump = True Then
            JMP(TargetLabel)
        End If
    End Sub

    Private Sub CALLX(ByVal TargetLabel As String)
        PUSH("_PC")
        JMP(TargetLabel)
    End Sub

    Private Sub CCondition(ByVal CInstr As String, ByVal TargetLabel As String)
        PUSH("_PC")
        CInstr = CInstr.Substring(1) 'leaving the first char "C"
        CInstr = "J" + CInstr 'Adding "J" at the start (for JCondition)
        JCondition(CInstr, TargetLabel)
    End Sub

    Private Sub RET()
        POP("_W")
        Dim HexValue As String = Conversion.FromBinToHex(Wbits) & Conversion.FromBinToHex(Zbits)
        Dim IntValue As String = Conversion.FromHexToDec(HexValue)

        CurrentLine = IntValue
    End Sub

    Private Sub RCondition(ByVal RInstr As String, ByVal TargetLabel As String)
        Dim CanJump As Boolean = False

        Select Case RInstr
            Case "RC"
                If F.GetFlagStatus("CF") = _1 Then
                    CanJump = True
                End If

            Case "RNC"
                If F.GetFlagStatus("CF") = _0 Then
                    CanJump = True
                End If

            Case "RZ"
                If F.GetFlagStatus("ZF") = _1 Then
                    CanJump = True
                End If

            Case "RNZ"
                If F.GetFlagStatus("ZF") = _0 Then
                    CanJump = True
                End If

            Case "RP"
                If F.GetFlagStatus("SF") = _0 Then
                    CanJump = True
                End If

            Case "RM"
                If F.GetFlagStatus("SF") = _1 Then
                    CanJump = True
                End If

            Case "RPE"
                If F.GetFlagStatus("PF") = _1 Then
                    CanJump = True
                End If

            Case "RPO"
                If F.GetFlagStatus("PF") = _0 Then
                    CanJump = True
                End If
        End Select

        If CanJump = True Then
            RET()
        End If
    End Sub

#End Region 'branching instructions end


#Region "Control Instructions"

    Private Sub NOP()
        'no operation
    End Sub

    Private Sub HLT()
        CurrentLine = LastLine
        RaiseEvent ProgramExecuted()
    End Sub

    Private Sub RST(ByVal Op1 As String)
        Dim n As Integer = Conversion.FromHexToDec(Op1)
        If n >= 1 And n <= 7 Then
            HLT()
        Else
            Throw New Exception8085("Invalid Operand")
        End If
    End Sub

#End Region 'control instructions end


#End Region

End Class