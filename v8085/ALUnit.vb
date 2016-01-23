Public Class ALUnit
    Const _0 As Boolean = False
    Const _1 As Boolean = True


    Private Sub Get_PF_ZF_SF(ByVal Result As BitArray, ByRef PF As Boolean, ByRef ZF As Boolean, ByRef SF As Boolean)
        Dim Parity As Integer = 0

        ZF = _1 'assume that the result is zero

        For Each bit As Boolean In Result
            If bit = _1 Then
                Parity += 1
                ZF = _0 'if any 1 is encountered, it means that the result is not zero
            End If
        Next

        If Parity Mod 2 = 0 Then
            PF = _1 'parity is even
        Else
            PF = _0 'odd parity
        End If

        SF = Result(0) 'the last bit is the sign bit
    End Sub

    Private Function TwosCompliment(ByVal bits As BitArray) As BitArray
        Dim NewBits As New BitArray(8)
        For i As Integer = 0 To 7
            If bits(i) = _1 Then
                NewBits(i) = _0
            ElseIf bits(i) = _0 Then
                NewBits(i) = _1
            End If
        Next
        '1's compliment done

        Dim flagbits As New BitArray(8) 'just for the sake of passing parameters

        NewBits = Addition(NewBits, Conversion.FromHexToBin("01"), flagbits)
        Return NewBits
    End Function

    Public Function Addition(ByVal R1 As BitArray, ByVal R2 As BitArray, ByRef FlagBits As BitArray, Optional ByVal Carry As Boolean = _0) As BitArray
        Dim AC As Boolean
        Dim Result As New BitArray(8)

        For i As Integer = 7 To 0 Step -1

            If i = 3 Then
                AC = Carry
            End If

            If R1(i) = _0 And R2(i) = _0 And Carry = _0 Then
                '000 = 0'
                Result(i) = _0
                Carry = _0
            ElseIf R1(i) = _0 And R2(i) = _0 And Carry = _1 Then
                '001 = 1'
                Result(i) = _1
                Carry = _0
            ElseIf R1(i) = _0 And R2(i) = _1 And Carry = _0 Then
                '010 = 1'
                Result(i) = _1
                Carry = _0
            ElseIf R1(i) = _0 And R2(i) = _1 And Carry = _1 Then
                '011 = 10'
                Result(i) = _0
                Carry = _1
            ElseIf R1(i) = _1 And R2(i) = _0 And Carry = _0 Then
                '100 = 1'
                Result(i) = _1
                Carry = _0
            ElseIf R1(i) = _1 And R2(i) = _0 And Carry = _1 Then
                '101 = 10'
                R1(i) = _0
                Carry = _1
            ElseIf R1(i) = _1 And R2(i) = _1 And Carry = _0 Then
                '110 = 10'
                Result(i) = _0
                Carry = _1
            ElseIf R1(i) = _1 And R2(i) = _1 And Carry = _1 Then
                '111 = 11'
                Result(i) = _1
                Carry = _1
            End If
        Next

        Get_PF_ZF_SF(Result, FlagBits(5), FlagBits(1), FlagBits(0))
        FlagBits(7) = Carry
        FlagBits(3) = AC

        Return Result
    End Function

    Public Function Subtraction(ByVal R1 As BitArray, ByVal R2 As BitArray, ByRef FlagBits As BitArray, Optional ByVal Borrow As Boolean = _0) As BitArray
        'first subtracting R1 with borrow
        Dim TempBits As New BitArray(8)
        TempBits(7) = Borrow 'padding 1 bit with with 8 bits

        TempBits = TwosCompliment(TempBits)
        R1 = Addition(R1, TempBits, FlagBits)

        'now subtracting r2 with r1
        R2 = TwosCompliment(R2) 'calculating twos compl of second operand
        R1 = Addition(R1, R2, FlagBits) 'and then adding with first operand

        Return R1
    End Function

    Public Function Increment8(ByVal bits As BitArray, ByRef FlagBits As BitArray) As BitArray
        Dim NewBits As BitArray
        NewBits = Addition(bits, Conversion.FromHexToBin("01"), FlagBits)
        Return NewBits
    End Function

    Public Function Increment16(ByVal H8 As BitArray, ByVal L8 As BitArray) As String
        Dim HexValue As String = Conversion.FromBinToHex(H8) & Conversion.FromBinToHex(L8)
        Dim IntValue As UInt16 = Conversion.FromHexToDec(HexValue)

        If IntValue = UInt16.MaxValue Then
            IntValue = UInt16.MinValue
        Else
            IntValue = IntValue + 1
        End If

        HexValue = IntValue.ToString("X4")
        Return HexValue
    End Function

    Public Function Decrement8(ByVal bits As BitArray, ByRef FlagBits As BitArray) As BitArray
        Dim NewBits As BitArray
        NewBits = Subtraction(bits, Conversion.FromHexToBin("01"), FlagBits)
        Return NewBits
    End Function

    Public Function Decrement16(ByVal H8 As BitArray, ByVal L8 As BitArray) As String
        Dim HexValue As String = Conversion.FromBinToHex(H8) & Conversion.FromBinToHex(L8)
        Dim IntValue As UInt16 = Conversion.FromHexToDec(HexValue)

        If IntValue = UInt16.MinValue Then
            IntValue = UInt16.MaxValue
        Else
            IntValue = IntValue - 1
        End If

        HexValue = IntValue.ToString("X4")
        Return HexValue
    End Function

    Public Function ANDing(ByVal R1 As BitArray, ByVal R2 As BitArray, ByRef FlagBits As BitArray) As BitArray
        Dim AndBits As BitArray

        AndBits = R1.And(R2)

        Get_PF_ZF_SF(AndBits, FlagBits(5), FlagBits(1), FlagBits(0))
        FlagBits(7) = _0 'CF = 0
        FlagBits(3) = _1 'AC = 1

        Return AndBits
    End Function

    Public Function ORing(ByVal R1 As BitArray, ByVal R2 As BitArray, ByRef FlagBits As BitArray) As BitArray
        Dim ORbits As BitArray

        ORbits = R1.Or(R2)

        Get_PF_ZF_SF(ORbits, FlagBits(5), FlagBits(1), FlagBits(0))
        FlagBits(7) = _0 'CF = 0
        FlagBits(3) = _0 'AC = 0

        Return ORbits
    End Function

    Public Function XORing(ByVal R1 As BitArray, ByVal R2 As BitArray, ByRef FlagBits As BitArray) As BitArray
        Dim XORbits As BitArray

        XORbits = R1.Xor(R2)

        Get_PF_ZF_SF(XORbits, FlagBits(5), FlagBits(1), FlagBits(0))
        FlagBits(7) = _0 'CF = 0
        FlagBits(3) = _0 'AC = 1

        Return XORbits
    End Function
End Class
