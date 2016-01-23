'Programmer Name - Gaurav Bhorkar
'Class name - Conversion

'Purpose - 
'to convert numbers to various formats

Public Class Conversion
    Const _1 As Boolean = True
    Const _0 As Boolean = False

#Region "Data Members"
    Private Shared BinValues(,) As Boolean = _
        { _
            {_0, _0, _0, _0}, _
            {_0, _0, _0, _1}, _
            {_0, _0, _1, _0}, _
            {_0, _0, _1, _1}, _
            {_0, _1, _0, _0}, _
            {_0, _1, _0, _1}, _
            {_0, _1, _1, _0}, _
            {_0, _1, _1, _1}, _
            {_1, _0, _0, _0}, _
            {_1, _0, _0, _1}, _
            {_1, _0, _1, _0}, _
            {_1, _0, _1, _1}, _
            {_1, _1, _0, _0}, _
            {_1, _1, _0, _1}, _
            {_1, _1, _1, _0}, _
            {_1, _1, _1, _1} _
        } '0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F (One element stored in each row)

    Private Shared HexValues As String = "0123456789ABCDEF"
#End Region

#Region "Member Functions"

    ''' <summary>
    ''' Converts Binary Value to Hexadecimal String
    ''' </summary>
    ''' <param name="bits"></param>
    ''' <returns>Hexadecimal Equivalent of binary array as string</returns>
    ''' <remarks></remarks>
    Public Shared Function FromBinToHex(ByVal bits As BitArray) As String
        Dim strBinary As String = String.Empty
        Dim Int As Integer
        Dim strHexadecimal As String = String.Empty

        'converting the bitarray in string of 1's and 0's
        For Each bit As Boolean In bits
            If bit = _1 Then
                strBinary += "1"
            ElseIf bit = _0 Then
                strBinary += "0"
            End If
        Next

        'binary string to int32 value
        Int = Convert.ToInt32(strBinary, 2)

        If strBinary.Length = 8 Then
            strHexadecimal = Int.ToString("X2")
        ElseIf strBinary.Length = 16 Then
            strHexadecimal = Int.ToString("X4")
        Else
            Throw New Exception("A binary number of invalid length specified")
        End If

        Return strHexadecimal
    End Function


    ''' <summary>
    ''' Convert HExadecimal string to Binary number
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns>BitArray of equivalent Hexadecimal number</returns>
    ''' <remarks></remarks>
    Public Shared Function FromHexToBin(ByVal data As String) As BitArray
        Dim bits As BitArray
        If data.Length = 2 Then
            bits = New BitArray(8)
        ElseIf data.Length = 4 Then
            bits = New BitArray(16)
        Else
            Throw New Exception("Invalid length of data (func:HexToBin)")
        End If

        Dim SetIndex As UInteger = 0 'the location of the set within the set of 4 bits each (1111 1111 1111 ...)
        For Each Num As Char In data
            For j As UInteger = 0 To 3
                bits(SetIndex + j) = BinValues(Convert.ToInt32(Num, 16), j)
            Next
            SetIndex += 4
        Next

        Return bits
    End Function


    ''' <summary>
    ''' Converts Hexadecimal string to Unsigned Integer (Decimal)
    ''' </summary>
    ''' <param name="strHexadecimal"></param>
    ''' <returns>Decimal Value as Unsigned Integer of Hexadecimal String</returns>
    ''' <remarks></remarks>
    Public Shared Function FromHexToDec(ByVal strHexadecimal As String) As UInteger
        Dim Int As UInteger
        Int = Convert.ToUInt32(strHexadecimal, 16)
        Return Int
    End Function

#End Region
End Class
