Public Class FormTimingDiagram

    Private Sub cbxInstr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxInstr.SelectedIndexChanged
        Dim instr As String = cbxInstr.SelectedItem
        instr = instr.ToLower()

        Select Case instr
            Case "mov rd, rs", "xchg", "add r", "adc r", "sub r", "sbb r", "cmp r", "inr r", "dcr r", "daa ", "ana r", _
                "ora r", "xra r", "cma", "cmc", "stc", "rlc", "ral", "rrc", "rar", "nop", "ei", "di", "sim", "rim"
                picTiming.BackgroundImage = My.Resources._a

            Case "mvi rd, data8", "adi data8", "aci data8", "sui data8", " sbi data8", "cpi data8", "ani data8", _
                "ori dat8", "xri data8"
                picTiming.BackgroundImage = My.Resources._b

            Case "mov rd, m", "ldax rp", "add m", "adc m", "sub m", "sbb m", "cmp m", "ana m", "ora m", "xra m"
                picTiming.BackgroundImage = My.Resources._c

            Case "mov m, rs", "stax rp"
                picTiming.BackgroundImage = My.Resources._d

            Case "lhld addr16"
                picTiming.BackgroundImage = My.Resources._lhld1

            Case "lda addr16"
                picTiming.BackgroundImage = My.Resources._lda1

            Case "lxi rp, data16", "jmp addr16", "jcondition addr16"
                picTiming.BackgroundImage = My.Resources._lxi_jmp_jcond

            Case "shld addr16"
                picTiming.BackgroundImage = My.Resources._shld1

            Case "sta addr16"
                picTiming.BackgroundImage = My.Resources._sta1

            Case "xthl"
                picTiming.BackgroundImage = My.Resources._xthl1

            Case "pop rp", "ret"
                picTiming.BackgroundImage = My.Resources._pop1

            Case "inr m", "dcr m"
                picTiming.BackgroundImage = My.Resources._inr_m_dcr_m

            Case "out data8"
                picTiming.BackgroundImage = My.Resources._out

            Case "in data8"
                picTiming.BackgroundImage = My.Resources._in

            Case "call addr16"
                picTiming.BackgroundImage = My.Resources._call

            Case "push rp", "rst n"
                picTiming.BackgroundImage = My.Resources._push_rst_n

            Case "inx rp", "dcx rp", "sphl", "pchl"
                picTiming.BackgroundImage = My.Resources._inx_dcx_sphl_pchl

            Case "rcondition"
                picTiming.BackgroundImage = My.Resources._RCondition

            Case "dad rp"
                picTiming.BackgroundImage = My.Resources._dad1

            Case "hlt"
                picTiming.BackgroundImage = My.Resources._hlt1
        End Select
    End Sub
End Class