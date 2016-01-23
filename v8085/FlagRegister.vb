'Programmer - Gaurav Bhorkar
'Class name - FlagRegister

'Inherited this class from Register8 because Flag Register in 8085 is 8 bits
'As flag register is a special register we add more functionality for manipulating bits


Public Class FlagRegister
    Inherits Register8

    Public Event BitChanged()

    Public Sub InvertFlag(ByVal Flag As String)
        Dim BitNo As Integer
        Select Case Flag
            Case "CF"
                BitNo = 7
            Case "PF"
                BitNo = 5
            Case "AC"
                BitNo = 3
            Case "ZF"
                BitNo = 1
            Case "SF"
                BitNo = 0
        End Select

        If bits(BitNo) = True Then
            bits(BitNo) = False
        ElseIf bits(BitNo) = False Then
            bits(BitNo) = True
        End If

        RaiseEvent BitChanged()
    End Sub

    Public Function GetFlagStatus(ByVal Flag As String) As Boolean
        Dim BitNo As Integer

        Select Case Flag
            Case "CF"
                BitNo = 7
            Case "PF"
                BitNo = 5
            Case "AC"
                BitNo = 3
            Case "ZF"
                BitNo = 1
            Case "SF"
                BitNo = 0
        End Select

        Return bits(BitNo)
    End Function

    Public Sub SetFlagStatus(ByVal Flag As String, ByVal Status As Boolean)
        Dim BitNo As Integer

        Select Case Flag
            Case "CF"
                BitNo = 7
            Case "PF"
                BitNo = 5
            Case "AC"
                BitNo = 3
            Case "ZF"
                BitNo = 1
            Case "SF"
                BitNo = 0
        End Select

        bits(BitNo) = Status
        RaiseEvent BitChanged()
    End Sub
End Class
