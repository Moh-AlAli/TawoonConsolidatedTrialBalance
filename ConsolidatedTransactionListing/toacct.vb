Imports ACCPAC.Advantage

Friend Class toacct

    Private i As Integer
    Private j As Integer
    Private os As New Session
    Private dblink As DBLink
    Private Sub toacct_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CBfindby.SelectedIndex = 1
        CBSearch.Visible = True
        CBCaptions.Visible = False
        Txtaccno.Visible = True
        Lblfl.Visible = True

        os.Init("", "GL", "GL0001", "67A")
        os.Open("ADMIN", "ADMIN", consldtranslist.compid, System.DateTime.Now, 0)
        ' os.OpenWin("", "", "", consldtranslist.compid, System.DateTime.Now, 0)
        dblink = os.OpenDBLink(DBLinkType.Company, DBLinkFlags.ReadOnly)

        Dim glv As View
        glv = dblink.OpenView("GL0001")
        Dim search As String = "ACCTID like " & consldtranslist.Txttoacct.Text & "% "
        glv.Browse(search, True)


        Dim glds As DataSet = New DataSet("GL")

        Dim glamf As DataTable = glds.Tables.Add("GLAMF")
        Dim unf As DataColumn = glamf.Columns.Add("ACCTID", Type.GetType("System.String"))
        Dim accno As DataColumn = glamf.Columns.Add("ACCTFMTTD", Type.GetType("System.String"))
        Dim accdesc As DataColumn = glamf.Columns.Add("ACCTDESC", Type.GetType("System.String"))
        Dim astatus As DataColumn = glamf.Columns.Add("ACTIVESW", Type.GetType("System.String"))
        Dim atype As DataColumn = glamf.Columns.Add("ACCTTYPE", Type.GetType("System.String"))
        Dim abRk As DataColumn = glamf.Columns.Add("ABRKID", Type.GetType("System.String"))
        Dim acontacc As DataColumn = glamf.Columns.Add("CTRLACCTSW", Type.GetType("System.String"))
        Dim allw As DataColumn = glamf.Columns.Add("ALLOCSW", Type.GetType("System.String"))
        Dim aMulti As DataColumn = glamf.Columns.Add("MCSW", Type.GetType("System.String"))
        Dim aqall As DataColumn = glamf.Columns.Add("QTYSW", Type.GetType("System.String"))
        Dim auom As DataColumn = glamf.Columns.Add("UOM", Type.GetType("System.String"))

        Dim row As DataRow
        row = glamf.NewRow()

        Do While glv.FilterFetch(False)

            Dim aid As String = glv.Fields.FieldByName("ACCTID").Value.ToString()
            Dim acct As String = glv.Fields.FieldByName("ACCTFMTTD").Value.ToString()
            Dim adesc As String = glv.Fields.FieldByName("ACCTDESC").Value.ToString()
            Dim cstat As String = glv.Fields.FieldByName("ACTIVESW").Value.ToString()
            Dim catype As String = glv.Fields.FieldByName("ACCTTYPE").Value.ToString()
            Dim cstco As String = glv.Fields.FieldByName("ABRKID").Value.ToString()
            Dim cconacc As String = glv.Fields.FieldByName("CTRLACCTSW").Value.ToString()
            Dim callw As String = glv.Fields.FieldByName("ALLOCSW").Value.ToString()
            Dim cmult As String = glv.Fields.FieldByName("MCSW").Value.ToString()
            Dim cqall As String = glv.Fields.FieldByName("QTYSW").Value.ToString()
            Dim cuom As String = glv.Fields.FieldByName("UOM").Value.ToString()
            Dim captstatus As String = ""
            Dim capttype As String = ""
            Dim captconacc As String = ""
            Dim captallcw As String = ""
            Dim captmult As String = ""
            Dim captqall As String = ""


            Select Case cstat
                Case 0
                    captstatus = "Inactive"
                Case 1
                    captstatus = "Active"
            End Select

            Select Case catype
                Case "I"
                    capttype = "Income Statement"
                Case "B"
                    capttype = "Balance Sheet"
                Case "R"
                    capttype = "Retained Earnings"
            End Select

            Select Case cconacc
                Case 0
                    captconacc = "No"
                Case 1
                    captconacc = "Yes"
            End Select

            Select Case callw
                Case 0
                    captallcw = "No Allocation"
                Case 1
                    captallcw = "Allocated by Account Balance"
                Case 2
                    captallcw = "Allocated by Account Quantity"
            End Select

            Select Case cmult
                Case 0
                    captmult = "No"
                Case 1
                    captmult = "Yes"
            End Select


            Select Case cqall
                Case 0
                    captqall = "No"
                Case 1
                    captqall = "Yes"
            End Select

            row("ACCTID") = aid
            row("ACCTFMTTD") = acct
            row("ACCTDESC") = adesc
            row("ACTIVESW") = captstatus
            row("ACCTTYPE") = capttype
            row("ABRKID") = cstco
            row("CTRLACCTSW") = captconacc
            row("ALLOCSW") = captallcw
            row("MCSW") = captmult
            row("QTYSW") = captqall
            row("UOM") = cuom
            glds.Tables(0).Rows.Add(row)
            row = glamf.NewRow()
        Loop
        Dim icl As New DataGridViewTextBoxColumn
        icl.DataPropertyName = "ACCTID"
        icl.Name = "clidc"
        icl.HeaderText = "Unformatted Account"
        icl.Width = 150
        DGtacc.Columns.Add(icl)
        Dim dcl As New DataGridViewTextBoxColumn
        dcl.DataPropertyName = "ACCTDESC"
        dcl.Name = "colnc"
        dcl.HeaderText = "Description"
        dcl.Width = 190
        DGtacc.Columns.Add(dcl)
        Dim ncl As New DataGridViewTextBoxColumn
        ncl.DataPropertyName = "ACCTFMTTD"
        ncl.Name = "colnc"
        ncl.HeaderText = "Account Number"
        ncl.Width = 190
        DGtacc.Columns.Add(ncl)

        Dim scl As New DataGridViewTextBoxColumn
        scl.DataPropertyName = "ACTIVESW"
        scl.Name = "colnc"
        scl.HeaderText = "Status"
        scl.Width = 190
        DGtacc.Columns.Add(scl)
        Dim tcl As New DataGridViewTextBoxColumn
        tcl.DataPropertyName = "ACCTTYPE"
        tcl.Name = "colnc"
        tcl.HeaderText = "Type"
        tcl.Width = 190
        DGtacc.Columns.Add(tcl)
        Dim tccl As New DataGridViewTextBoxColumn
        tccl.DataPropertyName = "ABRKID"
        tccl.Name = "colnc"
        tccl.HeaderText = "Structure Code"
        tccl.Width = 190
        DGtacc.Columns.Add(tccl)
        Dim cacl As New DataGridViewTextBoxColumn
        cacl.DataPropertyName = "CTRLACCTSW"
        cacl.Name = "colnc"
        cacl.HeaderText = "Control Account"
        cacl.Width = 190
        DGtacc.Columns.Add(cacl)
        Dim alcl As New DataGridViewTextBoxColumn
        alcl.DataPropertyName = "ALLOCSW"
        alcl.Name = "colnc"
        alcl.HeaderText = "Allocations Allowed"
        alcl.Width = 190
        DGtacc.Columns.Add(alcl)
        Dim mcl As New DataGridViewTextBoxColumn
        mcl.DataPropertyName = "MCSW"
        mcl.Name = "colnc"
        mcl.HeaderText = "MultiCurrency"
        mcl.Width = 190
        DGtacc.Columns.Add(mcl)
        Dim qcl As New DataGridViewTextBoxColumn
        qcl.DataPropertyName = "QTYSW"
        qcl.Name = "colnc"
        qcl.HeaderText = "Quantitties Allowed"
        qcl.Width = 190
        DGtacc.Columns.Add(qcl)
        Dim ucl As New DataGridViewTextBoxColumn
        ucl.DataPropertyName = "UOM"
        ucl.Name = "colnc"
        ucl.HeaderText = "Unit of Measure"
        ucl.Width = 190
        DGtacc.Columns.Add(ucl)


        DGtacc.DataSource = glds.Tables(0)


    End Sub

    Private Sub Txtaccno_MouseLeave(sender As Object, e As EventArgs)

        Try
            Dim glv As View
            glv = dblink.OpenView("GL0001")
            Dim searfil As String = ""
            If CBfindby.SelectedIndex = 1 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTID like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTID like " & Txtaccno.Text & "% "
                    End If
                End If

            ElseIf CBfindby.SelectedIndex = 2 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTFMTTD like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTFMTTD like " & Txtaccno.Text & "% "

                    End If
                End If

            ElseIf CBfindby.SelectedIndex = 3 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTDESC like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTDESC like " & Txtaccno.Text & "% "
                    End If
                End If
            ElseIf CBfindby.SelectedIndex = 4 Then
                searfil = " ACTIVESW = " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 5 Then
                searfil = " ACCTTYPE = " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 6 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ABRKID like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ABRKID like " & Txtaccno.Text & "% "
                    End If
                End If
            ElseIf CBfindby.SelectedIndex = 7 Then
                searfil = " CTRLACCTSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 8 Then
                searfil = " ALLOCSW=  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 9 Then
                searfil = " MCSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 10 Then
                searfil = " QTYSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 11 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " UOM like  %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " UOM like  " & Txtaccno.Text & "% "
                    End If
                End If
            End If


            glv.Browse(searfil, True)
            Dim glds As DataSet = New DataSet("GL")

            Dim glamf As DataTable = glds.Tables.Add("GLAMF")
            Dim unf As DataColumn = glamf.Columns.Add("ACCTID", Type.GetType("System.String"))
            Dim accno As DataColumn = glamf.Columns.Add("ACCTFMTTD", Type.GetType("System.String"))
            Dim accdesc As DataColumn = glamf.Columns.Add("ACCTDESC", Type.GetType("System.String"))
            Dim astatus As DataColumn = glamf.Columns.Add("ACTIVESW", Type.GetType("System.String"))
            Dim atype As DataColumn = glamf.Columns.Add("ACCTTYPE", Type.GetType("System.String"))
            Dim abRk As DataColumn = glamf.Columns.Add("ABRKID", Type.GetType("System.String"))
            Dim acontacc As DataColumn = glamf.Columns.Add("CTRLACCTSW", Type.GetType("System.String"))
            Dim allw As DataColumn = glamf.Columns.Add("ALLOCSW", Type.GetType("System.String"))
            Dim aMulti As DataColumn = glamf.Columns.Add("MCSW", Type.GetType("System.String"))
            Dim aqall As DataColumn = glamf.Columns.Add("QTYSW", Type.GetType("System.String"))
            Dim auom As DataColumn = glamf.Columns.Add("UOM", Type.GetType("System.String"))

            Dim row As DataRow
            row = glamf.NewRow()

            Do While glv.FilterFetch(False)

                Dim aid As String = glv.Fields.FieldByName("ACCTID").Value.ToString()
                Dim acct As String = glv.Fields.FieldByName("ACCTFMTTD").Value.ToString()
                Dim adesc As String = glv.Fields.FieldByName("ACCTDESC").Value.ToString()
                Dim cstat As String = glv.Fields.FieldByName("ACTIVESW").Value.ToString()
                Dim catype As String = glv.Fields.FieldByName("ACCTTYPE").Value.ToString()
                Dim cstco As String = glv.Fields.FieldByName("ABRKID").Value.ToString()
                Dim cconacc As String = glv.Fields.FieldByName("CTRLACCTSW").Value.ToString()
                Dim callw As String = glv.Fields.FieldByName("ALLOCSW").Value.ToString()
                Dim cmult As String = glv.Fields.FieldByName("MCSW").Value.ToString()
                Dim cqall As String = glv.Fields.FieldByName("QTYSW").Value.ToString()
                Dim cuom As String = glv.Fields.FieldByName("UOM").Value.ToString()
                Dim captstatus As String = ""
                Dim capttype As String = ""
                Dim captconacc As String = ""
                Dim captallcw As String = ""
                Dim captmult As String = ""
                Dim captqall As String = ""


                Select Case cstat
                    Case 0
                        captstatus = "Inactive"
                    Case 1
                        captstatus = "Active"
                End Select

                Select Case catype
                    Case "I"
                        capttype = "Income Statement"
                    Case "B"
                        capttype = "Balance Sheet"
                    Case "R"
                        capttype = "Retained Earnings"
                End Select

                Select Case cconacc
                    Case 0
                        captconacc = "No"
                    Case 1
                        captconacc = "Yes"
                End Select

                Select Case callw
                    Case 0
                        captallcw = "No Allocation"
                    Case 1
                        captallcw = "Allocated by Account Balance"
                    Case 2
                        captallcw = "Allocated by Account Quantity"
                End Select

                Select Case cmult
                    Case 0
                        captmult = "No"
                    Case 1
                        captmult = "Yes"
                End Select


                Select Case cqall
                    Case 0
                        captqall = "No"
                    Case 1
                        captqall = "Yes"
                End Select

                row("ACCTID") = aid
                row("ACCTFMTTD") = acct
                row("ACCTDESC") = adesc
                row("ACTIVESW") = captstatus
                row("ACCTTYPE") = capttype
                row("ABRKID") = cstco
                row("CTRLACCTSW") = captconacc
                row("ALLOCSW") = captallcw
                row("MCSW") = captmult
                row("QTYSW") = captqall
                row("UOM") = cuom
                glds.Tables(0).Rows.Add(row)
                row = glamf.NewRow()
            Loop

            DGtacc.DataSource = glds.Tables(0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub DGfven_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGtacc.CellContentClick

        Try

            Dim glv As View
            glv = dblink.OpenView("GL0001")
            Dim searfil As String = ""
            If CBfindby.SelectedIndex = 1 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTID like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTID like " & Txtaccno.Text & "% "
                    End If
                End If

            ElseIf CBfindby.SelectedIndex = 2 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTFMTTD like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTFMTTD like " & Txtaccno.Text & "% "

                    End If
                End If

            ElseIf CBfindby.SelectedIndex = 3 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTDESC like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTDESC like " & Txtaccno.Text & "% "
                    End If
                End If
            ElseIf CBfindby.SelectedIndex = 4 Then
                searfil = " ACTIVESW = " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 5 Then
                searfil = " ACCTTYPE = " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 6 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ABRKID like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ABRKID like " & Txtaccno.Text & "% "
                    End If
                End If
            ElseIf CBfindby.SelectedIndex = 7 Then
                searfil = " CTRLACCTSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 8 Then
                searfil = " ALLOCSW=  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 9 Then
                searfil = " MCSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 10 Then
                searfil = " QTYSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 11 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " UOM like  %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " UOM like  " & Txtaccno.Text & "% "
                    End If
                End If
            End If


            glv.Browse(searfil, True)
            Dim glds As DataSet = New DataSet("GL")

            Dim glamf As DataTable = glds.Tables.Add("GLAMF")
            Dim unf As DataColumn = glamf.Columns.Add("ACCTID", Type.GetType("System.String"))
            Dim accno As DataColumn = glamf.Columns.Add("ACCTFMTTD", Type.GetType("System.String"))
            Dim accdesc As DataColumn = glamf.Columns.Add("ACCTDESC", Type.GetType("System.String"))
            Dim astatus As DataColumn = glamf.Columns.Add("ACTIVESW", Type.GetType("System.String"))
            Dim atype As DataColumn = glamf.Columns.Add("ACCTTYPE", Type.GetType("System.String"))
            Dim abRk As DataColumn = glamf.Columns.Add("ABRKID", Type.GetType("System.String"))
            Dim acontacc As DataColumn = glamf.Columns.Add("CTRLACCTSW", Type.GetType("System.String"))
            Dim allw As DataColumn = glamf.Columns.Add("ALLOCSW", Type.GetType("System.String"))
            Dim aMulti As DataColumn = glamf.Columns.Add("MCSW", Type.GetType("System.String"))
            Dim aqall As DataColumn = glamf.Columns.Add("QTYSW", Type.GetType("System.String"))
            Dim auom As DataColumn = glamf.Columns.Add("UOM", Type.GetType("System.String"))

            Dim row As DataRow
            row = glamf.NewRow()
            Do While glv.FilterFetch(False)

                Dim aid As String = glv.Fields.FieldByName("ACCTID").Value.ToString()
                Dim acct As String = glv.Fields.FieldByName("ACCTFMTTD").Value.ToString()
                Dim adesc As String = glv.Fields.FieldByName("ACCTDESC").Value.ToString()
                Dim cstat As String = glv.Fields.FieldByName("ACTIVESW").Value.ToString()
                Dim catype As String = glv.Fields.FieldByName("ACCTTYPE").Value.ToString()
                Dim cstco As String = glv.Fields.FieldByName("ABRKID").Value.ToString()
                Dim cconacc As String = glv.Fields.FieldByName("CTRLACCTSW").Value.ToString()
                Dim callw As String = glv.Fields.FieldByName("ALLOCSW").Value.ToString()
                Dim cmult As String = glv.Fields.FieldByName("MCSW").Value.ToString()
                Dim cqall As String = glv.Fields.FieldByName("QTYSW").Value.ToString()
                Dim cuom As String = glv.Fields.FieldByName("UOM").Value.ToString()
                Dim captstatus As String = ""
                Dim capttype As String = ""
                Dim captconacc As String = ""
                Dim captallcw As String = ""
                Dim captmult As String = ""
                Dim captqall As String = ""


                Select Case cstat
                    Case 0
                        captstatus = "Inactive"
                    Case 1
                        captstatus = "Active"
                End Select

                Select Case catype
                    Case "I"
                        capttype = "Income Statement"
                    Case "B"
                        capttype = "Balance Sheet"
                    Case "R"
                        capttype = "Retained Earnings"
                End Select

                Select Case cconacc
                    Case 0
                        captconacc = "No"
                    Case 1
                        captconacc = "Yes"
                End Select

                Select Case callw
                    Case 0
                        captallcw = "No Allocation"
                    Case 1
                        captallcw = "Allocated by Account Balance"
                    Case 2
                        captallcw = "Allocated by Account Quantity"
                End Select

                Select Case cmult
                    Case 0
                        captmult = "No"
                    Case 1
                        captmult = "Yes"
                End Select


                Select Case cqall
                    Case 0
                        captqall = "No"
                    Case 1
                        captqall = "Yes"
                End Select

                row("ACCTID") = aid
                row("ACCTFMTTD") = acct
                row("ACCTDESC") = adesc
                row("ACTIVESW") = captstatus
                row("ACCTTYPE") = capttype
                row("ABRKID") = cstco
                row("CTRLACCTSW") = captconacc
                row("ALLOCSW") = captallcw
                row("MCSW") = captmult
                row("QTYSW") = captqall
                row("UOM") = cuom
                glds.Tables(0).Rows.Add(row)
                row = glamf.NewRow()
            Loop

            Dim dt As DataTable = glds.Tables(0)

            i = DGtacc.CurrentCell.RowIndex
            j = DGtacc.CurrentCell.ColumnIndex
            consldtranslist.Txtfrmacct.Text = dt.Rows(i)(0)
            consldtranslist.Txttoacct.Text = dt.Rows(i)(0)
            consldtranslist.btfind.Enabled = True
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Butcan_Click(sender As Object, e As EventArgs) Handles Butcan.Click
        Close()
        consldtranslist.btfind.Enabled = True
    End Sub
    Private Sub toacct_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        consldtranslist.btfind.Enabled = True
    End Sub
    Private Sub Bfind_Click(sender As Object, e As EventArgs) Handles Bfind.Click
        Try

            Dim glv As View
            glv = dblink.OpenView("GL0001")
            Dim searfil As String = ""
            If CBfindby.SelectedIndex = 1 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTID like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTID like " & Txtaccno.Text & "% "
                    End If
                End If

            ElseIf CBfindby.SelectedIndex = 2 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTFMTTD like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTFMTTD like " & Txtaccno.Text & "% "

                    End If
                End If

            ElseIf CBfindby.SelectedIndex = 3 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTDESC like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTDESC like " & Txtaccno.Text & "% "
                    End If
                End If
            ElseIf CBfindby.SelectedIndex = 4 Then
                searfil = " ACTIVESW = " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 5 Then
                searfil = " ACCTTYPE = " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 6 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ABRKID like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ABRKID like " & Txtaccno.Text & "% "
                    End If
                End If
            ElseIf CBfindby.SelectedIndex = 7 Then
                searfil = " CTRLACCTSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 8 Then
                searfil = " ALLOCSW=  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 9 Then
                searfil = " MCSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 10 Then
                searfil = " QTYSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 11 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " UOM like  %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " UOM like  " & Txtaccno.Text & "% "
                    End If
                End If
            End If


            glv.Browse(searfil, True)
            Dim glds As DataSet = New DataSet("GL")

            Dim glamf As DataTable = glds.Tables.Add("GLAMF")
            Dim unf As DataColumn = glamf.Columns.Add("ACCTID", Type.GetType("System.String"))
            Dim accno As DataColumn = glamf.Columns.Add("ACCTFMTTD", Type.GetType("System.String"))
            Dim accdesc As DataColumn = glamf.Columns.Add("ACCTDESC", Type.GetType("System.String"))
            Dim astatus As DataColumn = glamf.Columns.Add("ACTIVESW", Type.GetType("System.String"))
            Dim atype As DataColumn = glamf.Columns.Add("ACCTTYPE", Type.GetType("System.String"))
            Dim abRk As DataColumn = glamf.Columns.Add("ABRKID", Type.GetType("System.String"))
            Dim acontacc As DataColumn = glamf.Columns.Add("CTRLACCTSW", Type.GetType("System.String"))
            Dim allw As DataColumn = glamf.Columns.Add("ALLOCSW", Type.GetType("System.String"))
            Dim aMulti As DataColumn = glamf.Columns.Add("MCSW", Type.GetType("System.String"))
            Dim aqall As DataColumn = glamf.Columns.Add("QTYSW", Type.GetType("System.String"))
            Dim auom As DataColumn = glamf.Columns.Add("UOM", Type.GetType("System.String"))

            Dim row As DataRow
            row = glamf.NewRow()

            Do While glv.FilterFetch(False)

                Dim aid As String = glv.Fields.FieldByName("ACCTID").Value.ToString()
                Dim acct As String = glv.Fields.FieldByName("ACCTFMTTD").Value.ToString()
                Dim adesc As String = glv.Fields.FieldByName("ACCTDESC").Value.ToString()
                Dim cstat As String = glv.Fields.FieldByName("ACTIVESW").Value.ToString()
                Dim catype As String = glv.Fields.FieldByName("ACCTTYPE").Value.ToString()
                Dim cstco As String = glv.Fields.FieldByName("ABRKID").Value.ToString()
                Dim cconacc As String = glv.Fields.FieldByName("CTRLACCTSW").Value.ToString()
                Dim callw As String = glv.Fields.FieldByName("ALLOCSW").Value.ToString()
                Dim cmult As String = glv.Fields.FieldByName("MCSW").Value.ToString()
                Dim cqall As String = glv.Fields.FieldByName("QTYSW").Value.ToString()
                Dim cuom As String = glv.Fields.FieldByName("UOM").Value.ToString()
                Dim captstatus As String = ""
                Dim capttype As String = ""
                Dim captconacc As String = ""
                Dim captallcw As String = ""
                Dim captmult As String = ""
                Dim captqall As String = ""


                Select Case cstat
                    Case 0
                        captstatus = "Inactive"
                    Case 1
                        captstatus = "Active"
                End Select

                Select Case catype
                    Case "I"
                        capttype = "Income Statement"
                    Case "B"
                        capttype = "Balance Sheet"
                    Case "R"
                        capttype = "Retained Earnings"
                End Select

                Select Case cconacc
                    Case 0
                        captconacc = "No"
                    Case 1
                        captconacc = "Yes"
                End Select

                Select Case callw
                    Case 0
                        captallcw = "No Allocation"
                    Case 1
                        captallcw = "Allocated by Account Balance"
                    Case 2
                        captallcw = "Allocated by Account Quantity"
                End Select

                Select Case cmult
                    Case 0
                        captmult = "No"
                    Case 1
                        captmult = "Yes"
                End Select


                Select Case cqall
                    Case 0
                        captqall = "No"
                    Case 1
                        captqall = "Yes"
                End Select

                row("ACCTID") = aid
                row("ACCTFMTTD") = acct
                row("ACCTDESC") = adesc
                row("ACTIVESW") = captstatus
                row("ACCTTYPE") = capttype
                row("ABRKID") = cstco
                row("CTRLACCTSW") = captconacc
                row("ALLOCSW") = captallcw
                row("MCSW") = captmult
                row("QTYSW") = captqall
                row("UOM") = cuom
                glds.Tables(0).Rows.Add(row)
                row = glamf.NewRow()
            Loop

            DGtacc.DataSource = glds.Tables(0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButSel_Click(sender As Object, e As EventArgs) Handles ButSel.Click
        Try

            Dim glv As View
            glv = dblink.OpenView("GL0001")
            Dim searfil As String = ""
            If CBfindby.SelectedIndex = 1 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTID like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTID like " & Txtaccno.Text & "% "
                    End If
                End If

            ElseIf CBfindby.SelectedIndex = 2 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTFMTTD like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTFMTTD like " & Txtaccno.Text & "% "

                    End If
                End If

            ElseIf CBfindby.SelectedIndex = 3 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTDESC like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTDESC like " & Txtaccno.Text & "% "
                    End If
                End If
            ElseIf CBfindby.SelectedIndex = 4 Then
                searfil = " ACTIVESW = " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 5 Then
                searfil = " ACCTTYPE = " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 6 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ABRKID like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ABRKID like " & Txtaccno.Text & "% "
                    End If
                End If
            ElseIf CBfindby.SelectedIndex = 7 Then
                searfil = " CTRLACCTSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 8 Then
                searfil = " ALLOCSW=  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 9 Then
                searfil = " MCSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 10 Then
                searfil = " QTYSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 11 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " UOM like  %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " UOM like  " & Txtaccno.Text & "% "
                    End If
                End If
            End If


            glv.Browse(searfil, True)
            Dim glds As DataSet = New DataSet("GL")

            Dim glamf As DataTable = glds.Tables.Add("GLAMF")
            Dim unf As DataColumn = glamf.Columns.Add("ACCTID", Type.GetType("System.String"))
            Dim accno As DataColumn = glamf.Columns.Add("ACCTFMTTD", Type.GetType("System.String"))
            Dim accdesc As DataColumn = glamf.Columns.Add("ACCTDESC", Type.GetType("System.String"))
            Dim astatus As DataColumn = glamf.Columns.Add("ACTIVESW", Type.GetType("System.String"))
            Dim atype As DataColumn = glamf.Columns.Add("ACCTTYPE", Type.GetType("System.String"))
            Dim abRk As DataColumn = glamf.Columns.Add("ABRKID", Type.GetType("System.String"))
            Dim acontacc As DataColumn = glamf.Columns.Add("CTRLACCTSW", Type.GetType("System.String"))
            Dim allw As DataColumn = glamf.Columns.Add("ALLOCSW", Type.GetType("System.String"))
            Dim aMulti As DataColumn = glamf.Columns.Add("MCSW", Type.GetType("System.String"))
            Dim aqall As DataColumn = glamf.Columns.Add("QTYSW", Type.GetType("System.String"))
            Dim auom As DataColumn = glamf.Columns.Add("UOM", Type.GetType("System.String"))

            Dim row As DataRow
            row = glamf.NewRow()

            Do While glv.FilterFetch(False)

                Dim aid As String = glv.Fields.FieldByName("ACCTID").Value.ToString()
                Dim acct As String = glv.Fields.FieldByName("ACCTFMTTD").Value.ToString()
                Dim adesc As String = glv.Fields.FieldByName("ACCTDESC").Value.ToString()
                Dim cstat As String = glv.Fields.FieldByName("ACTIVESW").Value.ToString()
                Dim catype As String = glv.Fields.FieldByName("ACCTTYPE").Value.ToString()
                Dim cstco As String = glv.Fields.FieldByName("ABRKID").Value.ToString()
                Dim cconacc As String = glv.Fields.FieldByName("CTRLACCTSW").Value.ToString()
                Dim callw As String = glv.Fields.FieldByName("ALLOCSW").Value.ToString()
                Dim cmult As String = glv.Fields.FieldByName("MCSW").Value.ToString()
                Dim cqall As String = glv.Fields.FieldByName("QTYSW").Value.ToString()
                Dim cuom As String = glv.Fields.FieldByName("UOM").Value.ToString()
                Dim captstatus As String = ""
                Dim capttype As String = ""
                Dim captconacc As String = ""
                Dim captallcw As String = ""
                Dim captmult As String = ""
                Dim captqall As String = ""


                Select Case cstat
                    Case 0
                        captstatus = "Inactive"
                    Case 1
                        captstatus = "Active"
                End Select

                Select Case catype
                    Case "I"
                        capttype = "Income Statement"
                    Case "B"
                        capttype = "Balance Sheet"
                    Case "R"
                        capttype = "Retained Earnings"
                End Select

                Select Case cconacc
                    Case 0
                        captconacc = "No"
                    Case 1
                        captconacc = "Yes"
                End Select

                Select Case callw
                    Case 0
                        captallcw = "No Allocation"
                    Case 1
                        captallcw = "Allocated by Account Balance"
                    Case 2
                        captallcw = "Allocated by Account Quantity"
                End Select

                Select Case cmult
                    Case 0
                        captmult = "No"
                    Case 1
                        captmult = "Yes"
                End Select


                Select Case cqall
                    Case 0
                        captqall = "No"
                    Case 1
                        captqall = "Yes"
                End Select

                row("ACCTID") = aid
                row("ACCTFMTTD") = acct
                row("ACCTDESC") = adesc
                row("ACTIVESW") = captstatus
                row("ACCTTYPE") = capttype
                row("ABRKID") = cstco
                row("CTRLACCTSW") = captconacc
                row("ALLOCSW") = captallcw
                row("MCSW") = captmult
                row("QTYSW") = captqall
                row("UOM") = cuom
                glds.Tables(0).Rows.Add(row)
                row = glamf.NewRow()
            Loop

            Dim dt As DataTable = glds.Tables(0)

            i = DGtacc.CurrentCell.RowIndex
            j = DGtacc.CurrentCell.ColumnIndex

            consldtranslist.Txttoacct.Text = dt.Rows(i)(0)
            consldtranslist.Txtfrmacct.Text = dt.Rows(i)(0)
            consldtranslist.btfind.Enabled = True
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CBfindby_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBfindby.SelectedIndexChanged
        Try
            If CBfindby.SelectedIndex = 1 Then
                CBSearch.Visible = True
                CBSearch.SelectedIndex = 0
                Lblfl.Visible = True
                Txtaccno.Visible = True
                CBCaptions.Visible = False
            ElseIf CBfindby.SelectedIndex = 0 Then
                CBSearch.Visible = False
                Lblfl.Visible = False
                Txtaccno.Visible = False
                CBCaptions.Visible = False
            ElseIf CBfindby.SelectedIndex = 2 Then
                CBSearch.Visible = True
                CBSearch.SelectedIndex = 0
                Lblfl.Visible = True
                Txtaccno.Visible = True
                CBCaptions.Visible = False
            ElseIf CBfindby.SelectedIndex = 3 Then
                CBSearch.Visible = True
                CBSearch.SelectedIndex = 0
                Lblfl.Visible = True
                Txtaccno.Visible = True
                CBCaptions.Visible = False
            ElseIf CBfindby.SelectedIndex = 6 Then
                CBSearch.Visible = True
                CBSearch.SelectedIndex = 0
                Lblfl.Visible = True
                Txtaccno.Visible = True
                CBCaptions.Visible = False
            ElseIf CBfindby.SelectedIndex = 11 Then
                CBSearch.Visible = True
                CBSearch.SelectedIndex = 0
                Lblfl.Visible = True
                Txtaccno.Visible = True
                CBCaptions.Visible = False
            ElseIf CBfindby.SelectedIndex = 4 Then
                CBSearch.Visible = False
                Lblfl.Visible = True
                Txtaccno.Visible = False
                CBCaptions.Visible = True
                CBCaptions.SelectedIndex = 0
                CBCaptions.DisplayMember = "Text"
                CBCaptions.ValueMember = "Value"
                Dim tb As New DataTable
                tb.Columns.Add("Text", GetType(String))
                tb.Columns.Add("Value", GetType(Integer))
                tb.Rows.Add("Inactive", 0)
                tb.Rows.Add("Active", 1)
                CBCaptions.DataSource = tb
            ElseIf CBfindby.SelectedIndex = 5 Then
                CBSearch.Visible = False
                Lblfl.Visible = True
                Txtaccno.Visible = False
                CBCaptions.Visible = True
                CBCaptions.SelectedIndex = 0
                CBCaptions.DisplayMember = "Text"
                CBCaptions.ValueMember = "Value"
                Dim tb As New DataTable
                tb.Columns.Add("Text", GetType(String))
                tb.Columns.Add("Value", GetType(String))
                tb.Rows.Add("Income statement", "I")
                tb.Rows.Add("Balance Sheet", "B")
                tb.Rows.Add("retained Earnings", "R")
                CBCaptions.DataSource = tb
            ElseIf CBfindby.SelectedIndex = 7 Then
                CBSearch.Visible = False
                Lblfl.Visible = True
                Txtaccno.Visible = False
                CBCaptions.Visible = True
                CBCaptions.SelectedIndex = 0
                CBCaptions.DisplayMember = "Text"
                CBCaptions.ValueMember = "Value"
                Dim tb As New DataTable
                tb.Columns.Add("Text", GetType(String))
                tb.Columns.Add("Value", GetType(Integer))
                tb.Rows.Add("No", 0)
                tb.Rows.Add("Yes", 1)
                CBCaptions.DataSource = tb
            ElseIf CBfindby.SelectedIndex = 8 Then
                CBSearch.Visible = False
                Lblfl.Visible = True
                Txtaccno.Visible = False
                CBCaptions.Visible = True
                CBCaptions.SelectedIndex = 0
                CBCaptions.DisplayMember = "Text"
                CBCaptions.ValueMember = "Value"
                Dim tb As New DataTable
                tb.Columns.Add("Text", GetType(String))
                tb.Columns.Add("Value", GetType(Integer))
                tb.Rows.Add("No Allocations", 0)
                tb.Rows.Add("Allocated By Account Balance", 1)
                tb.Rows.Add("Allocated By Account Quantity", 2)
                CBCaptions.DataSource = tb
            ElseIf CBfindby.SelectedIndex = 9 Then
                CBSearch.Visible = False
                Lblfl.Visible = True
                Txtaccno.Visible = False
                CBCaptions.Visible = True
                CBCaptions.SelectedIndex = 0
                CBCaptions.DisplayMember = "Text"
                CBCaptions.ValueMember = "Value"
                Dim tb As New DataTable
                tb.Columns.Add("Text", GetType(String))
                tb.Columns.Add("Value", GetType(Integer))
                tb.Rows.Add("No", 0)
                tb.Rows.Add("Yes", 1)
                CBCaptions.DataSource = tb
            ElseIf CBfindby.SelectedIndex = 10 Then
                CBSearch.Visible = False
                Lblfl.Visible = True
                Txtaccno.Visible = False
                CBCaptions.Visible = True
                CBCaptions.SelectedIndex = 0
                CBCaptions.DisplayMember = "Text"
                CBCaptions.ValueMember = "Value"
                Dim tb As New DataTable
                tb.Columns.Add("Text", GetType(String))
                tb.Columns.Add("Value", GetType(Integer))
                tb.Rows.Add("No", 0)
                tb.Rows.Add("Yes", 1)
                CBCaptions.DataSource = tb
            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub CBCaptions_MouseLeave(sender As Object, e As EventArgs) Handles CBCaptions.MouseLeave
        Try

            Dim glv As View
            glv = dblink.OpenView("GL0001")
            Dim searfil As String = ""
            If CBfindby.SelectedIndex = 1 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTID like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTID like " & Txtaccno.Text & "% "
                    End If
                End If

            ElseIf CBfindby.SelectedIndex = 2 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTFMTTD like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTFMTTD like " & Txtaccno.Text & "% "

                    End If
                End If

            ElseIf CBfindby.SelectedIndex = 3 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTDESC like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTDESC like " & Txtaccno.Text & "% "
                    End If
                End If
            ElseIf CBfindby.SelectedIndex = 4 Then
                searfil = " ACTIVESW = " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 5 Then
                searfil = " ACCTTYPE = " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 6 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ABRKID like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ABRKID like " & Txtaccno.Text & "% "
                    End If
                End If
            ElseIf CBfindby.SelectedIndex = 7 Then
                searfil = " CTRLACCTSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 8 Then
                searfil = " ALLOCSW=  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 9 Then
                searfil = " MCSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 10 Then
                searfil = " QTYSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 11 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " UOM like  %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " UOM like  " & Txtaccno.Text & "% "
                    End If
                End If
            End If



            glv.Browse(searfil, True)
            Dim glds As DataSet = New DataSet("GL")

            Dim glamf As DataTable = glds.Tables.Add("GLAMF")
            Dim unf As DataColumn = glamf.Columns.Add("ACCTID", Type.GetType("System.String"))
            Dim accno As DataColumn = glamf.Columns.Add("ACCTFMTTD", Type.GetType("System.String"))
            Dim accdesc As DataColumn = glamf.Columns.Add("ACCTDESC", Type.GetType("System.String"))
            Dim astatus As DataColumn = glamf.Columns.Add("ACTIVESW", Type.GetType("System.String"))
            Dim atype As DataColumn = glamf.Columns.Add("ACCTTYPE", Type.GetType("System.String"))
            Dim abRk As DataColumn = glamf.Columns.Add("ABRKID", Type.GetType("System.String"))
            Dim acontacc As DataColumn = glamf.Columns.Add("CTRLACCTSW", Type.GetType("System.String"))
            Dim allw As DataColumn = glamf.Columns.Add("ALLOCSW", Type.GetType("System.String"))
            Dim aMulti As DataColumn = glamf.Columns.Add("MCSW", Type.GetType("System.String"))
            Dim aqall As DataColumn = glamf.Columns.Add("QTYSW", Type.GetType("System.String"))
            Dim auom As DataColumn = glamf.Columns.Add("UOM", Type.GetType("System.String"))

            Dim row As DataRow
            row = glamf.NewRow()

            Do While glv.FilterFetch(False)

                Dim aid As String = glv.Fields.FieldByName("ACCTID").Value.ToString()
                Dim acct As String = glv.Fields.FieldByName("ACCTFMTTD").Value.ToString()
                Dim adesc As String = glv.Fields.FieldByName("ACCTDESC").Value.ToString()
                Dim cstat As String = glv.Fields.FieldByName("ACTIVESW").Value.ToString()
                Dim catype As String = glv.Fields.FieldByName("ACCTTYPE").Value.ToString()
                Dim cstco As String = glv.Fields.FieldByName("ABRKID").Value.ToString()
                Dim cconacc As String = glv.Fields.FieldByName("CTRLACCTSW").Value.ToString()
                Dim callw As String = glv.Fields.FieldByName("ALLOCSW").Value.ToString()
                Dim cmult As String = glv.Fields.FieldByName("MCSW").Value.ToString()
                Dim cqall As String = glv.Fields.FieldByName("QTYSW").Value.ToString()
                Dim cuom As String = glv.Fields.FieldByName("UOM").Value.ToString()
                Dim captstatus As String = ""
                Dim capttype As String = ""
                Dim captconacc As String = ""
                Dim captallcw As String = ""
                Dim captmult As String = ""
                Dim captqall As String = ""


                Select Case cstat
                    Case 0
                        captstatus = "Inactive"
                    Case 1
                        captstatus = "Active"
                End Select

                Select Case catype
                    Case "I"
                        capttype = "Income Statement"
                    Case "B"
                        capttype = "Balance Sheet"
                    Case "R"
                        capttype = "Retained Earnings"
                End Select

                Select Case cconacc
                    Case 0
                        captconacc = "No"
                    Case 1
                        captconacc = "Yes"
                End Select

                Select Case callw
                    Case 0
                        captallcw = "No Allocation"
                    Case 1
                        captallcw = "Allocated by Account Balance"
                    Case 2
                        captallcw = "Allocated by Account Quantity"
                End Select

                Select Case cmult
                    Case 0
                        captmult = "No"
                    Case 1
                        captmult = "Yes"
                End Select


                Select Case cqall
                    Case 0
                        captqall = "No"
                    Case 1
                        captqall = "Yes"
                End Select

                row("ACCTID") = aid
                row("ACCTFMTTD") = acct
                row("ACCTDESC") = adesc
                row("ACTIVESW") = captstatus
                row("ACCTTYPE") = capttype
                row("ABRKID") = cstco
                row("CTRLACCTSW") = captconacc
                row("ALLOCSW") = captallcw
                row("MCSW") = captmult
                row("QTYSW") = captqall
                row("UOM") = cuom
                glds.Tables(0).Rows.Add(row)
                row = glamf.NewRow()
            Loop

            DGtacc.DataSource = glds.Tables(0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub Txtaccno_TextChanged(sender As Object, e As EventArgs) Handles Txtaccno.TextChanged
        Try

            Dim glv As View
            glv = dblink.OpenView("GL0001")
            Dim searfil As String = ""
            If CBfindby.SelectedIndex = 1 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTID like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTID like " & Txtaccno.Text & "% "
                    End If
                End If

            ElseIf CBfindby.SelectedIndex = 2 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTFMTTD like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTFMTTD like " & Txtaccno.Text & "% "

                    End If
                End If

            ElseIf CBfindby.SelectedIndex = 3 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTDESC like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTDESC like " & Txtaccno.Text & "% "
                    End If
                End If
            ElseIf CBfindby.SelectedIndex = 4 Then
                searfil = " ACTIVESW = " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 5 Then
                searfil = " ACCTTYPE = " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 6 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ABRKID like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ABRKID like " & Txtaccno.Text & "% "
                    End If
                End If
            ElseIf CBfindby.SelectedIndex = 7 Then
                searfil = " CTRLACCTSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 8 Then
                searfil = " ALLOCSW=  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 9 Then
                searfil = " MCSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 10 Then
                searfil = " QTYSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 11 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " UOM like  %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " UOM like  " & Txtaccno.Text & "% "
                    End If
                End If
            End If


            glv.Browse(searfil, True)
            Dim glds As DataSet = New DataSet("GL")
            Dim glamf As DataTable = glds.Tables.Add("GLAMF")
            Dim unf As DataColumn = glamf.Columns.Add("ACCTID", Type.GetType("System.String"))
            Dim accno As DataColumn = glamf.Columns.Add("ACCTFMTTD", Type.GetType("System.String"))
            Dim accdesc As DataColumn = glamf.Columns.Add("ACCTDESC", Type.GetType("System.String"))
            Dim astatus As DataColumn = glamf.Columns.Add("ACTIVESW", Type.GetType("System.String"))
            Dim atype As DataColumn = glamf.Columns.Add("ACCTTYPE", Type.GetType("System.String"))
            Dim abRk As DataColumn = glamf.Columns.Add("ABRKID", Type.GetType("System.String"))
            Dim acontacc As DataColumn = glamf.Columns.Add("CTRLACCTSW", Type.GetType("System.String"))
            Dim allw As DataColumn = glamf.Columns.Add("ALLOCSW", Type.GetType("System.String"))
            Dim aMulti As DataColumn = glamf.Columns.Add("MCSW", Type.GetType("System.String"))
            Dim aqall As DataColumn = glamf.Columns.Add("QTYSW", Type.GetType("System.String"))
            Dim auom As DataColumn = glamf.Columns.Add("UOM", Type.GetType("System.String"))

            Dim row As DataRow
            row = glamf.NewRow()

            Do While glv.FilterFetch(False)

                Dim aid As String = glv.Fields.FieldByName("ACCTID").Value.ToString()
                Dim acct As String = glv.Fields.FieldByName("ACCTFMTTD").Value.ToString()
                Dim adesc As String = glv.Fields.FieldByName("ACCTDESC").Value.ToString()
                Dim cstat As String = glv.Fields.FieldByName("ACTIVESW").Value.ToString()
                Dim catype As String = glv.Fields.FieldByName("ACCTTYPE").Value.ToString()
                Dim cstco As String = glv.Fields.FieldByName("ABRKID").Value.ToString()
                Dim cconacc As String = glv.Fields.FieldByName("CTRLACCTSW").Value.ToString()
                Dim callw As String = glv.Fields.FieldByName("ALLOCSW").Value.ToString()
                Dim cmult As String = glv.Fields.FieldByName("MCSW").Value.ToString()
                Dim cqall As String = glv.Fields.FieldByName("QTYSW").Value.ToString()
                Dim cuom As String = glv.Fields.FieldByName("UOM").Value.ToString()
                Dim captstatus As String = ""
                Dim capttype As String = ""
                Dim captconacc As String = ""
                Dim captallcw As String = ""
                Dim captmult As String = ""
                Dim captqall As String = ""


                Select Case cstat
                    Case 0
                        captstatus = "Inactive"
                    Case 1
                        captstatus = "Active"
                End Select

                Select Case catype
                    Case "I"
                        capttype = "Income Statement"
                    Case "B"
                        capttype = "Balance Sheet"
                    Case "R"
                        capttype = "Retained Earnings"
                End Select

                Select Case cconacc
                    Case 0
                        captconacc = "No"
                    Case 1
                        captconacc = "Yes"
                End Select

                Select Case callw
                    Case 0
                        captallcw = "No Allocation"
                    Case 1
                        captallcw = "Allocated by Account Balance"
                    Case 2
                        captallcw = "Allocated by Account Quantity"
                End Select

                Select Case cmult
                    Case 0
                        captmult = "No"
                    Case 1
                        captmult = "Yes"
                End Select


                Select Case cqall
                    Case 0
                        captqall = "No"
                    Case 1
                        captqall = "Yes"
                End Select

                row("ACCTID") = aid
                row("ACCTFMTTD") = acct
                row("ACCTDESC") = adesc
                row("ACTIVESW") = captstatus
                row("ACCTTYPE") = capttype
                row("ABRKID") = cstco
                row("CTRLACCTSW") = captconacc
                row("ALLOCSW") = captallcw
                row("MCSW") = captmult
                row("QTYSW") = captqall
                row("UOM") = cuom
                glds.Tables(0).Rows.Add(row)
                row = glamf.NewRow()
            Loop
            DGtacc.DataSource = glds.Tables(0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CBCaptions_MouseMove(sender As Object, e As MouseEventArgs) Handles CBCaptions.MouseMove
        Try

            Dim glv As View
            glv = dblink.OpenView("GL0001")
            Dim searfil As String = ""
            If CBfindby.SelectedIndex = 1 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTID like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTID like " & Txtaccno.Text & "% "
                    End If
                End If

            ElseIf CBfindby.SelectedIndex = 2 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTFMTTD like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTFMTTD like " & Txtaccno.Text & "% "

                    End If
                End If

            ElseIf CBfindby.SelectedIndex = 3 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTDESC like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ACCTDESC like " & Txtaccno.Text & "% "
                    End If
                End If
            ElseIf CBfindby.SelectedIndex = 4 Then
                searfil = " ACTIVESW = " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 5 Then
                searfil = " ACCTTYPE = " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 6 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ABRKID like %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " ABRKID like " & Txtaccno.Text & "% "
                    End If
                End If
            ElseIf CBfindby.SelectedIndex = 7 Then
                searfil = " CTRLACCTSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 8 Then
                searfil = " ALLOCSW=  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 9 Then
                searfil = " MCSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 10 Then
                searfil = " QTYSW =  " & CBCaptions.SelectedValue & " "
            ElseIf CBfindby.SelectedIndex = 11 Then
                If CBSearch.SelectedIndex = 1 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like %" & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " UOM like  %" & Txtaccno.Text & "% "
                    End If
                ElseIf CBSearch.SelectedIndex = 0 Then
                    If Txtaccno.Text = Nothing Then
                        searfil = " ACCTID like " & consldtranslist.Txttoacct.Text & "% "
                    Else
                        searfil = " UOM like  " & Txtaccno.Text & "% "
                    End If
                End If
            End If


            glv.Browse(searfil, True)
            Dim glds As DataSet = New DataSet("GL")

            Dim glamf As DataTable = glds.Tables.Add("GLAMF")
            Dim unf As DataColumn = glamf.Columns.Add("ACCTID", Type.GetType("System.String"))
            Dim accno As DataColumn = glamf.Columns.Add("ACCTFMTTD", Type.GetType("System.String"))
            Dim accdesc As DataColumn = glamf.Columns.Add("ACCTDESC", Type.GetType("System.String"))
            Dim astatus As DataColumn = glamf.Columns.Add("ACTIVESW", Type.GetType("System.String"))
            Dim atype As DataColumn = glamf.Columns.Add("ACCTTYPE", Type.GetType("System.String"))
            Dim abRk As DataColumn = glamf.Columns.Add("ABRKID", Type.GetType("System.String"))
            Dim acontacc As DataColumn = glamf.Columns.Add("CTRLACCTSW", Type.GetType("System.String"))
            Dim allw As DataColumn = glamf.Columns.Add("ALLOCSW", Type.GetType("System.String"))
            Dim aMulti As DataColumn = glamf.Columns.Add("MCSW", Type.GetType("System.String"))
            Dim aqall As DataColumn = glamf.Columns.Add("QTYSW", Type.GetType("System.String"))
            Dim auom As DataColumn = glamf.Columns.Add("UOM", Type.GetType("System.String"))

            Dim row As DataRow
            row = glamf.NewRow()

            Do While glv.FilterFetch(False)

                Dim aid As String = glv.Fields.FieldByName("ACCTID").Value.ToString()
                Dim acct As String = glv.Fields.FieldByName("ACCTFMTTD").Value.ToString()
                Dim adesc As String = glv.Fields.FieldByName("ACCTDESC").Value.ToString()
                Dim cstat As String = glv.Fields.FieldByName("ACTIVESW").Value.ToString()
                Dim catype As String = glv.Fields.FieldByName("ACCTTYPE").Value.ToString()
                Dim cstco As String = glv.Fields.FieldByName("ABRKID").Value.ToString()
                Dim cconacc As String = glv.Fields.FieldByName("CTRLACCTSW").Value.ToString()
                Dim callw As String = glv.Fields.FieldByName("ALLOCSW").Value.ToString()
                Dim cmult As String = glv.Fields.FieldByName("MCSW").Value.ToString()
                Dim cqall As String = glv.Fields.FieldByName("QTYSW").Value.ToString()
                Dim cuom As String = glv.Fields.FieldByName("UOM").Value.ToString()
                Dim captstatus As String = ""
                Dim capttype As String = ""
                Dim captconacc As String = ""
                Dim captallcw As String = ""
                Dim captmult As String = ""
                Dim captqall As String = ""


                Select Case cstat
                    Case 0
                        captstatus = "Inactive"
                    Case 1
                        captstatus = "Active"
                End Select

                Select Case catype
                    Case "I"
                        capttype = "Income Statement"
                    Case "B"
                        capttype = "Balance Sheet"
                    Case "R"
                        capttype = "Retained Earnings"
                End Select

                Select Case cconacc
                    Case 0
                        captconacc = "No"
                    Case 1
                        captconacc = "Yes"
                End Select

                Select Case callw
                    Case 0
                        captallcw = "No Allocation"
                    Case 1
                        captallcw = "Allocated by Account Balance"
                    Case 2
                        captallcw = "Allocated by Account Quantity"
                End Select

                Select Case cmult
                    Case 0
                        captmult = "No"
                    Case 1
                        captmult = "Yes"
                End Select


                Select Case cqall
                    Case 0
                        captqall = "No"
                    Case 1
                        captqall = "Yes"
                End Select

                row("ACCTID") = aid
                row("ACCTFMTTD") = acct
                row("ACCTDESC") = adesc
                row("ACTIVESW") = captstatus
                row("ACCTTYPE") = capttype
                row("ABRKID") = cstco
                row("CTRLACCTSW") = captconacc
                row("ALLOCSW") = captallcw
                row("MCSW") = captmult
                row("QTYSW") = captqall
                row("UOM") = cuom
                glds.Tables(0).Rows.Add(row)
                row = glamf.NewRow()
            Loop

            DGtacc.DataSource = glds.Tables(0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


End Class

