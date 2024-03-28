Imports System.Runtime.InteropServices
Imports acc = ACCPAC.Advantage

Public Class consldtrialbal
    Public frmcust As String
    Public Tocust As String
    Public fdate As String
    Public tdate As String
    Friend Property ERPSession As acc.Session
    Friend Property Company As ERPCompany
    Friend Property SessionDate As String
    Friend Property ObjectHandle As String
    Friend compid As String
    Private _oldVendNumb As String = ""
    <DllImport("a4wroto.dll", EntryPoint:="rotoSetObjectWindow", CharSet:=CharSet.Ansi)>
    Private Shared Sub rotoSetObjectWindow(
        <MarshalAs(UnmanagedType.I8)> ByVal objectHandle As Long,
        <MarshalAs(UnmanagedType.I8)> ByVal hWnd As Long)
    End Sub
    Public Sub New(ByVal ses As acc.Session, ByVal comp As ERPCompany, ByVal sesDate As String)
        InitializeComponent()
        'ObjectHandle = ""
        ERPSession = ses
        Company = comp
        compid = comp.ID

        SessionDate = sesDate

    End Sub
    Public Sub New(ByVal _objectHandle As String)
        InitializeComponent()
        ObjectHandle = _objectHandle
    End Sub



    Public Sub New()
        InitializeComponent()

    End Sub



    Private Sub custstatement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Not ObjectHandle Is Nothing Then
                SessionFromERP(Handle)

            End If
            If compid = "GENDAT" Then
                ChRAMDAT.Visible = True
                ChGENDAT.Visible = True
                ChJORDAT.Visible = True
                ChLEBDAT.Visible = True
                ChOCJDAT.Visible = True
                ChOCJDAT.Checked = False
                ChRAMDAT.Checked = False
                ChJORDAT.Checked = False
                ChLEBDAT.Checked = False
                ChGENDAT.Checked = False
            ElseIf compid = "RAMDAT" Then
                ChRAMDAT.Visible = True
                ChGENDAT.Visible = False
                ChJORDAT.Visible = False
                ChLEBDAT.Visible = False
                ChOCJDAT.Visible = False

                ChRAMDAT.Checked = True
            ElseIf compid = "JORDAT" Then
                ChRAMDAT.Visible = False
                ChGENDAT.Visible = False
                ChJORDAT.Visible = True
                ChLEBDAT.Visible = False
                ChOCJDAT.Visible = False

                ChJORDAT.Checked = True

            ElseIf compid = "GENDAT" Then
                ChRAMDAT.Visible = False
                ChGENDAT.Visible = True
                ChJORDAT.Visible = False
                ChLEBDAT.Visible = False
                ChOCJDAT.Visible = False

                ChGENDAT.Checked = True
            ElseIf compid = "LEBDAT" Then
                ChRAMDAT.Visible = False
                ChGENDAT.Visible = False
                ChJORDAT.Visible = False
                ChLEBDAT.Visible = True
                ChOCJDAT.Visible = False

                ChLEBDAT.Checked = True
            ElseIf compid = "OCJDAT" Then
                ChRAMDAT.Visible = False
                ChGENDAT.Visible = False
                ChJORDAT.Visible = False
                ChLEBDAT.Visible = False
                ChOCJDAT.Visible = True

                ChOCJDAT.Checked = True
            End If

            Me.Text = compid + " - " + "Consolidated Trial Balance"
            Txttoacct.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            Txttarea.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            Txttben.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            Txttemp.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            Txttgcod.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            '  Txttprog.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            Txttoff.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            ' Txttdnr.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            Txttdnew.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            '  Txttdon.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            ' Txttgrn.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            '  Txttdep1.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            '   Txttdep2.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            Txttdep3.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            '  Txttdep4.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            '  Txttdep5.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            '  Txttdep6.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            ' Txttdep7.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            ' Txttdep8.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            Txttproj.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            Txttprogs.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            Txttsubt.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            Txtttype.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            Txttcat.Text = "zzzzzzzzzzzzzzzzzzzzzz"
            rbinclprov.Checked = True
            If Date.Now.Month < 10 Then
                txtfrmprd.Text = "0" & Date.Now.Month
                txttoprd.Text = "0" & Date.Now.Month
            Else
                txtfrmprd.Text = Date.Now.Month
                txttoprd.Text = Date.Now.Month
            End If
            txtfrmyear.Text = Date.Now.Year
            txttoyear.Text = Date.Now.Year
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Close()
        End Try
    End Sub


    Private Sub CMD_OK_Click(sender As Object, e As EventArgs) Handles Bprint.Click

        Try

            Dim fmonthnew As String = 0

            If txtfrmprd.Text < 10 Then
                fmonthnew = "0" & Integer.Parse(txtfrmprd.Text)
            Else
                fmonthnew = txtfrmprd.Text
            End If
            Dim tmonthnew As String = 0
            If txtfrmprd.Text < 10 Then
                tmonthnew = "0" & Integer.Parse(txttoprd.Text)
            Else
                tmonthnew = txttoprd.Text
            End If


            fdate = Integer.Parse(txtfrmyear.Text) & "-" & fmonthnew
            tdate = Integer.Parse(txttoyear.Text) & "-" & tmonthnew
            Dim vfyper As Integer = Integer.Parse(txtfrmyear.Text) & fmonthnew
            Dim vtyper As Integer = Integer.Parse(txttoyear.Text) & tmonthnew
            Dim toacct As String = ""

            If Txttoacct.Text = Nothing Then
                toacct = "zzzzzzzzzzzzzzzzzzzzzz"
            Else
                toacct = Trim(Txttoacct.Text)
            End If
            Dim toarea As String = ""

            If Txttarea.Text = Nothing Then
                toarea = "zzzzzzzzzzzzzzzzzzzzzz"
            Else
                toarea = Trim(Txttarea.Text)
            End If

            Dim toben As String = ""
            If Txttben.Text = Nothing Then
                toben = "zzzzzzzzzzzzzzzzzzzzzz"
            Else
                toben = Trim(Txttben.Text)
            End If
            Dim toemp As String = ""
            If Txttemp.Text = Nothing Then
                toemp = "zzzzzzzzzzzzzzzzzzzzzz"
            Else
                toemp = Trim(Txttemp.Text)
            End If
            Dim togcod As String = ""
            If Txttgcod.Text = Nothing Then
                togcod = "zzzzzzzzzzzzzzzzzzzzzz"
            Else
                togcod = Trim(Txttgcod.Text)
            End If


            Dim toprog As String = "zzzzzzzzzzzzzzzzzzzzzz"
            'If Txttprog.Text = Nothing Then
            '    toprog = "zzzzzzzzzzzzzzzzzzzzzz"
            'Else
            '    toprog = Trim(Txttprog.Text)
            'End If


            Dim tooff As String = ""
            If Txttoff.Text = Nothing Then
                tooff = "zzzzzzzzzzzzzzzzzzzzzz"
            Else
                tooff = Trim(Txttoff.Text)
            End If

            Dim todonr As String = "zzzzzzzzzzzzzzzzzzzzzz"
            'If Txttdnr.Text = Nothing Then
            '    todonr = "zzzzzzzzzzzzzzzzzzzzzz"
            'Else
            '    todonr = Trim(Txttdnr.Text)
            'End If

            Dim todnew As String = ""
            If Txttdnew.Text = Nothing Then
                todnew = "zzzzzzzzzzzzzzzzzzzzzz"
            Else
                todnew = Trim(Txttdnew.Text)
            End If


            Dim todon As String = "zzzzzzzzzzzzzzzzzzzzzz"
            'If Txttdon.Text = Nothing Then
            '    todon = "zzzzzzzzzzzzzzzzzzzzzz"
            'Else
            '    todon = Trim(Txttdon.Text)
            'End If


            Dim togrn As String = "zzzzzzzzzzzzzzzzzzzzzz"
            'If Txttgrn.Text = Nothing Then
            '    togrn = "zzzzzzzzzzzzzzzzzzzzzz"
            'Else
            '    togrn = Trim(Txttgrn.Text)
            'End If


            Dim todep1 As String = "zzzzzzzzzzzzzzzzzzzzzz"
            'If Txttdep1.Text = Nothing Then
            '    todep1 = "zzzzzzzzzzzzzzzzzzzzzz"
            'Else
            '    todep1 = Trim(Txttdep1.Text)
            'End If

            Dim todep2 As String = "zzzzzzzzzzzzzzzzzzzzzz"
            'If Txttdep2.Text = Nothing Then
            '    todep2 = "zzzzzzzzzzzzzzzzzzzzzz"
            'Else
            '    todep2 = Trim(Txttdep2.Text)
            'End If

            Dim todep3 As String = ""
            If Txttdep3.Text = Nothing Then
                todep3 = "zzzzzzzzzzzzzzzzzzzzzz"
            Else
                todep3 = Trim(Txttdep3.Text)
            End If

            Dim todep4 As String = "zzzzzzzzzzzzzzzzzzzzzz"
            'If Txttdep4.Text = Nothing Then
            '    todep4 = "zzzzzzzzzzzzzzzzzzzzzz"
            'Else
            '    todep4 = Trim(Txttdep4.Text)
            'End If

            Dim todep5 As String = "zzzzzzzzzzzzzzzzzzzzzz"
            'If Txttdep5.Text = Nothing Then
            '    todep5 = "zzzzzzzzzzzzzzzzzzzzzz"
            'Else
            '    todep5 = Trim(Txttdep5.Text)
            'End If

            Dim todep6 As String = "zzzzzzzzzzzzzzzzzzzzzz"
            'If Txttdep6.Text = Nothing Then
            '    todep6 = "zzzzzzzzzzzzzzzzzzzzzz"
            'Else
            '    todep6 = Trim(Txttdep6.Text)
            'End If

            Dim todep7 As String = "zzzzzzzzzzzzzzzzzzzzzz"
            'If Txttdep7.Text = Nothing Then
            '    todep7 = "zzzzzzzzzzzzzzzzzzzzzz"
            'Else
            '    todep7 = Trim(Txttdep7.Text)
            'End If

            Dim todep8 As String = "zzzzzzzzzzzzzzzzzzzzzz"
            'If Txttdep8.Text = Nothing Then
            '    todep8 = "zzzzzzzzzzzzzzzzzzzzzz"
            'Else
            '    todep8 = Trim(Txttdep8.Text)
            'End If

            Dim toproj As String = "zzzzzzzzzzzzzzzzzzzzzz"
            'If Txttproj.Text = Nothing Then
            '    toproj = "zzzzzzzzzzzzzzzzzzzzzz"
            'Else
            '    toproj = Trim(Txttproj.Text)
            'End If

            Dim toprogs As String = ""
            If Txttprogs.Text = Nothing Then
                toprogs = "zzzzzzzzzzzzzzzzzzzzzz"
            Else
                toprogs = Trim(Txttprogs.Text)
            End If

            Dim totype As String = ""
            If Txtttype.Text = Nothing Then
                totype = "zzzzzzzzzzzzzzzzzzzzzz"
            Else
                totype = Trim(Txtttype.Text)
            End If

            Dim tosubtype As String = ""
            If Txttsubt.Text = Nothing Then
                tosubtype = "zzzzzzzzzzzzzzzzzzzzzz"
            Else
                tosubtype = Trim(Txttsubt.Text)
            End If

            Dim tocat As String = ""
            If Txttcat.Text = Nothing Then
                tocat = "zzzzzzzzzzzzzzzzzzzzzz"
            Else
                tocat = Trim(Txttcat.Text)
            End If

            If ChOCJDAT.Checked = True Or ChLEBDAT.Checked = True Or ChJORDAT.Checked = True Or ChGENDAT.Checked = True Or ChRAMDAT.Checked = True Then


                If Trim(Txtfrmacct.Text) <= Trim(Txttoacct.Text) Then
                    If vfyper <= vtyper Then

                        Dim f As Form = New crviewer(ObjectHandle, ERPSession, Trim(Txtfrmacct.Text), toacct, fdate, tdate, ChRAMDAT.Checked, ChGENDAT.Checked, ChJORDAT.Checked, ChOCJDAT.Checked, ChLEBDAT.Checked, Trim(Txtftype.Text), Trim(Txtfsubt.Text), Trim(Txtfcat.Text), Trim(Txtfarea.Text), Trim(Txtfben.Text), Trim(Txtfemp.Text), Trim(Txtfgcod.Text), Trim(""), Trim(Txtfoff.Text), Trim(""), Trim(Txtfdnew.Text), Trim(""), Trim(""), Trim(""), Trim(""), Trim(Txtfdep3.Text), Trim("") _
                        , Trim(""), Trim(""), Trim(""), Trim(""), Trim(Txtfproj.Text), Trim(Txtfprogs.Text) _
                        , totype, tosubtype, tocat, toarea, toben, toemp, togcod, toprog, tooff, todonr, todnew, todon, togrn, todep1, todep2, todep3, todep4 _
                        , todep5, todep6, todep7, todep8, toproj, toprogs, rbinclprov.Checked, rbnotinclprov.Checked)
                        f.Show()

                    Else
                        MessageBox.Show("From Year-Period  greater than To Year-Period")
                    End If
                Else
                    MessageBox.Show("From Account No greater than To Account No")
                End If
            Else

                MessageBox.Show("Choose Entity !")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub bffind_Click(sender As Object, e As EventArgs) Handles bffind.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If
        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("GLAMF", "Accounts", ram, gen, jor, ocj, leb, New String() {"ACCTID", "ACCTDESC"}, ERPSession, "", "")

            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then
                Txtfrmacct.Text = vfnd.Result.ToArray()(0)
                Txttoacct.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txtfrmacct, EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub btfind_Click(sender As Object, e As EventArgs) Handles btfind.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("GLAMF", "Accounts", ram, gen, jor, ocj, leb, New String() {"ACCTID", "ACCTDESC"}, ERPSession, "", "")

            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then
                Txttoacct.Text = vfnd.Result.ToArray()(0)

                fndEditBoxValidate(Txttoacct, EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub CMD_Exit_Click(sender As Object, e As EventArgs) Handles Bexit.Click
        Close()
    End Sub
    Private Sub fndEditBoxValidate(ByVal sender As Object, ByVal e As EventArgs)

        If Bexit.Focused Then Return
        Dim txb As TextBox = CType(sender, TextBox)
        If String.IsNullOrEmpty(txb.Text) Then Return
        Dim msg As String = ""
        Dim s As String() = New String() {}

        'Select Case txb.Name.Trim()
        '    Case "Txtfrmacct"

        '        If _oldVendNumb.Trim() <> txb.Text.Trim() Then
        '            msg = getValidationData("select ID=ACCTID,NAM=ACCTDESC from GLAMF where ACCTID='" & txb.Text & "'", s)

        '            If msg <> "" Then
        '                MessageBox.Show(Me, msg, "Consolidated Trans.List", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        '                Return
        '            End If

        '            If s.Length = 0 Then
        '                MessageBox.Show(Me, "Account """ & txb.Text & """ does not exists.", "Consolidated Trans.List", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                txb.Focus()
        '                txb.SelectAll()
        '                Return
        '            End If



        '        End If
        '        Txtfrmacct.Text = s(0)
        '    Case "Txttoacct"

        '        If _oldVendNumb.Trim() <> txb.Text.Trim() Then
        '            msg = getValidationData("select ID=ACCTID,NAM=ACCTDESC from GLAMF where ACCTID='" & txb.Text & "'", s)

        '            If msg <> "" Then
        '                MessageBox.Show(Me, msg, "Consolidated Trans.List", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        '                Return
        '            End If

        '            If s.Length = 0 Then
        '                MessageBox.Show(Me, "Account """ & txb.Text & """ does not exists.", "Consolidated Trans.List", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                txb.Focus()
        '                txb.SelectAll()
        '                Return
        '            End If


        '        End If


        '  Txttoacct.Text = s(0)
        ' End If
        ' End Select
    End Sub
    Private Function getValidationData(ByVal sql As String, <Out> ByRef data As String()) As String
        data = New String(2) {}
        Dim hasRecs As Boolean = False

        Try
            Dim lnk As acc.DBLink = ERPSession.OpenDBLink(acc.DBLinkType.Company, acc.DBLinkFlags.[ReadOnly])
            Dim opQry As acc.View = lnk.OpenView("CS0120")
            opQry.Cancel()
            opQry.Browse(sql, True)
            opQry.InternalSet(256)

            While opQry.Fetch(False)
                hasRecs = True
                data(0) = opQry.Fields.FieldByName("ID").Value.ToString().Trim()
                data(1) = opQry.Fields.FieldByName("NAM").Value.ToString().Trim()

            End While

            opQry.Dispose()
            lnk.Dispose()
            If Not hasRecs Then data = New String() {}
            Return ""
        Catch ex As Exception
            Dim erstr As String = ""
            Dim erlst As List(Of String) = New List(Of String)()
            Util.FillErrors(ex, ERPSession, erlst)

            For Each s As String In erlst
                erstr += s & vbCrLf
            Next

            Dim ms As String = "Sage 300 ERP Error: " & erstr
            Return ms
        End Try
    End Function

    Private Sub SessionFromERP(ByVal frmHwnd As IntPtr)
        Dim lhWnd As Long = Nothing

        Try
            If ERPSession Is Nothing Then ERPSession = New acc.Session()
            If ERPSession.IsOpened Then ERPSession.Dispose()
            ERPSession.Init(ObjectHandle, "XX", "XX0001", "67A")

            If Not Long.TryParse(ObjectHandle, lhWnd) Then
                MessageBox.Show("Invalid Sage 300 ERP object handle.", "Consolidated Trans.List Utility", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                ERPSession.Dispose()
                Return
            End If

            rotoSetObjectWindow(lhWnd, frmHwnd.ToInt64())
            Company = New ERPCompany(ERPSession.CompanyName, ERPSession.CompanyID)
            SessionDate = ERPSession.SessionDate.ToString()
        Catch ex As Exception
            Dim erstr As String = ""
            Dim erlst As List(Of String) = New List(Of String)()
            Util.FillErrors(ex, ERPSession, erlst)

            For Each s As String In erlst
                erstr += s & vbCrLf
            Next

            Dim ms As String = "Sage 300 ERP Error: " & erstr
            ERPSession.Dispose()
            MessageBox.Show(ms, "Consolidated Trans.List", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return
        End Try
    End Sub

    Private Sub ClearAll(ByVal Optional includeVend As Boolean = True)
        If includeVend Then
            Txtfrmacct.Clear()

        End If

        _oldVendNumb = ""

    End Sub



    Private Sub Butftype_Click(sender As Object, e As EventArgs) Handles Butftype.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else

            Dim vfnd As FromFinder = New FromFinder("OPTFDTYPE", "Type", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")

            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then
                Txtftype.Text = vfnd.Result.ToArray()(0)
                Txtttype.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txtftype, EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub Butttype_Click(sender As Object, e As EventArgs) Handles Butttype.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else Dim vfnd As FromFinder = New FromFinder("OPTFDTYPE", "Type", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")

            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then

                Txtttype.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txtttype, EventArgs.Empty)
            End If
        End If

    End Sub

    Private Sub Butfsubt_Click(sender As Object, e As EventArgs) Handles Butfsubt.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDSUBTYPE", "Sub.Type", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")

            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then
                Txtfsubt.Text = vfnd.Result.ToArray()(0)
                Txttsubt.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txtfsubt, EventArgs.Empty)
            End If
        End If

    End Sub

    Private Sub Buttsubt_Click(sender As Object, e As EventArgs) Handles Buttsubt.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDSUBTYPE", "Sub.Type", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")

            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then

                Txttsubt.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txttsubt, EventArgs.Empty)
            End If
        End If

    End Sub

    Private Sub Butfcat_Click(sender As Object, e As EventArgs) Handles Butfcat.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDCATEGORY", "Category", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")

            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then
                Txtfcat.Text = vfnd.Result.ToArray()(0)
                Txttcat.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txtfcat, EventArgs.Empty)
            End If
        End If

    End Sub

    Private Sub Buttcat_Click(sender As Object, e As EventArgs) Handles Buttcat.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDCATEGORY", "Category", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")

            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then

                Txttcat.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txttcat, EventArgs.Empty)
            End If
        End If

    End Sub

    Private Sub Butffarea_Click(sender As Object, e As EventArgs) Handles Butffarea.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDAREA", "AREA", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")

            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then
                Txtfarea.Text = vfnd.Result.ToArray()(0)
                Txttarea.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txtfarea, EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub Butftarea_Click(sender As Object, e As EventArgs) Handles Butftarea.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDAREA", "AREA", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then
                Txttarea.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txttarea, EventArgs.Empty)
            End If
        End If

    End Sub

    Private Sub Butffbenf_Click(sender As Object, e As EventArgs) Handles Butffbenf.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDBENF", "BENEFICIARY", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then
                Txtfben.Text = vfnd.Result.ToArray()(0)
                Txttben.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txtfben, EventArgs.Empty)
            End If
        End If

    End Sub

    Private Sub Butftbenf_Click(sender As Object, e As EventArgs) Handles Butftbenf.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDBENF", "BENEFICIARY", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then
                Txttben.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txttben, EventArgs.Empty)
            End If
        End If

    End Sub

    Private Sub Butffemp_Click(sender As Object, e As EventArgs) Handles Butffemp.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDEMP", "Employee", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then
                Txtfemp.Text = vfnd.Result.ToArray()(0)
                Txttemp.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txtfemp, EventArgs.Empty)
            End If
        End If

    End Sub

    Private Sub Butftemp_Click(sender As Object, e As EventArgs) Handles Butftemp.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDEMP", "Employee", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then
                Txttemp.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txttemp, EventArgs.Empty)
            End If
        End If

    End Sub

    Private Sub Butffgcode_Click(sender As Object, e As EventArgs) Handles Butffgcode.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDGCOD", "GL Code", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then
                Txtfgcod.Text = vfnd.Result.ToArray()(0)
                Txttgcod.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txtfgcod, EventArgs.Empty)
            End If
        End If

    End Sub

    Private Sub Butftgcode_Click(sender As Object, e As EventArgs) Handles Butftgcode.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDGCOD", "GL Code", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then
                Txttgcod.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txttgcod, EventArgs.Empty)
            End If
        End If

    End Sub

    'Private Sub Butffprog_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDPROG", "Program", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then
    '            Txtfprog.Text = vfnd.Result.ToArray()(0)
    '            Txttprog.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txtfprog, EventArgs.Empty)
    '        End If
    '    End If

    'End Sub

    'Private Sub Butftprog_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDPROG", "Program", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then
    '            Txttprog.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txtfprog, EventArgs.Empty)
    '        End If
    '    End If

    'End Sub

    Private Sub Butffoff_Click(sender As Object, e As EventArgs) Handles Butffoff.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDOFF", "OFFICE", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then
                Txtfoff.Text = vfnd.Result.ToArray()(0)
                Txttoff.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txtfoff, EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub Butftoff_Click(sender As Object, e As EventArgs) Handles Butftoff.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If


        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDOFF", "OFFICE", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then
                Txttoff.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txttoff, EventArgs.Empty)
            End If
        End If

    End Sub

    'Private Sub Butffdonr_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDDNR", "DONOR", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then
    '            Txtfdnr.Text = vfnd.Result.ToArray()(0)
    '            Txttdnr.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txtfdnr, EventArgs.Empty)
    '        End If

    '    End If

    'End Sub

    'Private Sub Butftdonr_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDDNR", "DONOR", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then
    '            Txttdnr.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txttdnr, EventArgs.Empty)
    '        End If
    '    End If

    'End Sub

    Private Sub Butffdnew_Click(sender As Object, e As EventArgs) Handles Butffdnew.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDDNRNEW", "DONORNEW", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then
                Txtfdnew.Text = vfnd.Result.ToArray()(0)
                Txttdnew.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txtfdnew, EventArgs.Empty)
            End If
        End If

    End Sub

    Private Sub Butftdnew_Click(sender As Object, e As EventArgs) Handles Butftdnew.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDDNRNEW", "DONORNEW", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then
                Txttdnew.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txttdnew, EventArgs.Empty)
            End If
        End If

    End Sub

    'Private Sub Butffdon_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDDON", "DONATION", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then
    '            Txtfdon.Text = vfnd.Result.ToArray()(0)
    '            Txttdon.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txtfdon, EventArgs.Empty)
    '        End If
    '    End If

    'End Sub

    'Private Sub Butftdon_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDDON", "DONATION", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then
    '            Txttdon.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txttdon, EventArgs.Empty)
    '        End If
    '    End If

    'End Sub

    'Private Sub Butffgrn_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDGRN", "Grant", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then
    '            Txtfgrn.Text = vfnd.Result.ToArray()(0)
    '            Txttgrn.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txtfgrn, EventArgs.Empty)
    '        End If
    '    End If
    'End Sub

    'Private Sub Butftgrn_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDGRN", "Grant", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then
    '            Txttgrn.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txttgrn, EventArgs.Empty)
    '        End If
    '    End If

    'End Sub

    'Private Sub Butffdep1_Click(sender As Object, e As EventArgs)

    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDDEP1", "Dept 1", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then
    '            Txtfdep1.Text = vfnd.Result.ToArray()(0)
    '            Txttdep1.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txtfdep1, EventArgs.Empty)
    '        End If
    '    End If

    'End Sub

    'Private Sub Butftdep1_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDDEP1", "Dept 1", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then
    '            Txttdep1.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txttdep1, EventArgs.Empty)
    '        End If
    '    End If

    'End Sub

    'Private Sub Butffdep2_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDDEP2", "Dept 2", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then
    '            Txtfdep2.Text = vfnd.Result.ToArray()(0)
    '            Txttdep2.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txtfdep2, EventArgs.Empty)
    '        End If
    '    End If

    'End Sub

    'Private Sub Butftdep2_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDDEP2", "Dept 2", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then

    '            Txttdep2.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txttdep2, EventArgs.Empty)
    '        End If
    '    End If

    'End Sub

    Private Sub Butffdep3_Click(sender As Object, e As EventArgs) Handles Butffdep3.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDDEP3", "Dept 3", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then
                Txtfdep3.Text = vfnd.Result.ToArray()(0)
                Txttdep3.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txtfdep3, EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub Butftdep3_Click(sender As Object, e As EventArgs) Handles Butftdep3.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDDEP3", "Dept 3", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then

                Txttdep3.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txttdep3, EventArgs.Empty)
            End If
        End If

    End Sub

    'Private Sub Butffdep4_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDDEP4", "Dept 4", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then
    '            Txtfdep4.Text = vfnd.Result.ToArray()(0)
    '            Txttdep4.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txtfdep4, EventArgs.Empty)
    '        End If
    '    End If

    'End Sub

    'Private Sub Butftdep4_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDDEP4", "Dept 4", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then
    '            Txttdep4.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txttdep4, EventArgs.Empty)
    '        End If
    '    End If

    'End Sub

    'Private Sub Butffdep5_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDDEP5", "Dept 5", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then
    '            Txtfdep5.Text = vfnd.Result.ToArray()(0)
    '            Txttdep5.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txtfdep5, EventArgs.Empty)
    '        End If
    '    End If

    'End Sub

    'Private Sub Butftdep5_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDDEP5", "Dept 5", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then

    '            Txttdep5.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txttdep5, EventArgs.Empty)
    '        End If
    '    End If

    'End Sub

    'Private Sub Butffdep6_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDDEP6", "Dept 6", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then
    '            Txtfdep6.Text = vfnd.Result.ToArray()(0)
    '            Txttdep6.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txtfdep6, EventArgs.Empty)
    '        End If
    '    End If

    'End Sub

    'Private Sub Butftdep6_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDDEP6", "Dept 6", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then

    '            Txttdep6.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txttdep6, EventArgs.Empty)
    '        End If
    '    End If

    'End Sub

    'Private Sub Butffdep7_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDDEP7", "Dept 7", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then
    '            Txtfdep7.Text = vfnd.Result.ToArray()(0)
    '            Txttdep7.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txtfdep7, EventArgs.Empty)
    '        End If
    '    End If

    'End Sub

    'Private Sub Butftdep7_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDDEP7", "Dept 7", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then

    '            Txttdep7.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txttdep7, EventArgs.Empty)
    '        End If
    '    End If

    'End Sub

    'Private Sub Butffdep8_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDDEP8", "Dept 8", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then
    '            Txtfdep8.Text = vfnd.Result.ToArray()(0)
    '            Txttdep8.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txtfdep8, EventArgs.Empty)
    '        End If
    '    End If

    'End Sub

    'Private Sub Butftdep8_Click(sender As Object, e As EventArgs)
    '    Dim ram As String = ""
    '    If ChRAMDAT.Checked = True Then
    '        ram = "RAMDAT.dbo."
    '    End If
    '    Dim gen As String = ""
    '    If ChGENDAT.Checked = True Then
    '        gen = "GENDAT.dbo."
    '    End If
    '    Dim jor As String = ""
    '    If ChJORDAT.Checked = True Then
    '        jor = "JORDAT.dbo."
    '    End If
    '    Dim ocj As String = ""
    '    If ChOCJDAT.Checked = True Then
    '        ocj = "OCJDAT.dbo."
    '    End If
    '    Dim leb As String = ""
    '    If ChLEBDAT.Checked = True Then
    '        leb = "LEBDAT.dbo."
    '    End If

    '    If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
    '        MessageBox.Show("Choose At least one entity!")

    '    Else
    '        Dim vfnd As FromFinder = New FromFinder("OPTFDDEP8", "Dept 8", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
    '        Dim r As DialogResult = vfnd.ShowDialog(Me)
    '        If r = DialogResult.OK Then

    '            Txttdep8.Text = vfnd.Result.ToArray()(0)
    '            fndEditBoxValidate(Txttdep8, EventArgs.Empty)
    '        End If
    '    End If

    'End Sub

    Private Sub Butffproj_Click(sender As Object, e As EventArgs) Handles Butffproj.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDPROJ", "PROJECT", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then
                Txtfproj.Text = vfnd.Result.ToArray()(0)
                Txttproj.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txtfproj, EventArgs.Empty)
            End If
        End If

    End Sub

    Private Sub Butftproj_Click(sender As Object, e As EventArgs) Handles Butftproj.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDPROJ", "PROJECT", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then

                Txttproj.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txttproj, EventArgs.Empty)
            End If
        End If

    End Sub

    Private Sub Butffprogs_Click(sender As Object, e As EventArgs) Handles Butffprogs.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDPROGS", "PROGRAMS", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then
                Txtfprogs.Text = vfnd.Result.ToArray()(0)
                Txttprogs.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txtfprogs, EventArgs.Empty)
            End If
        End If

    End Sub

    Private Sub Butftprogs_Click(sender As Object, e As EventArgs) Handles Butftprogs.Click
        Dim ram As String = ""
        If ChRAMDAT.Checked = True Then
            ram = "RAMDAT.dbo."
        End If
        Dim gen As String = ""
        If ChGENDAT.Checked = True Then
            gen = "GENDAT.dbo."
        End If
        Dim jor As String = ""
        If ChJORDAT.Checked = True Then
            jor = "JORDAT.dbo."
        End If
        Dim ocj As String = ""
        If ChOCJDAT.Checked = True Then
            ocj = "OCJDAT.dbo."
        End If
        Dim leb As String = ""
        If ChLEBDAT.Checked = True Then
            leb = "LEBDAT.dbo."
        End If

        If ram = "" And jor = "" And gen = "" And ocj = "" And leb = "" Then
            MessageBox.Show("Choose At least one entity!")

        Else
            Dim vfnd As FromFinder = New FromFinder("OPTFDPROGS", "PROGRAMS", ram, gen, jor, ocj, leb, New String() {"VALUE", "VDESC"}, ERPSession, "", "")
            Dim r As DialogResult = vfnd.ShowDialog(Me)
            If r = DialogResult.OK Then

                Txttprogs.Text = vfnd.Result.ToArray()(0)
                fndEditBoxValidate(Txttprogs, EventArgs.Empty)
            End If
        End If

    End Sub

    Private Sub txtfrmyear_TextChanged(sender As Object, e As EventArgs) Handles txtfrmyear.TextChanged
        If (System.Text.RegularExpressions.Regex.IsMatch(txtfrmyear.Text, "[^0-9]")) Then
            MessageBox.Show("Please enter only numbers.")
            txtfrmyear.Text = txtfrmyear.Text.Remove(txtfrmyear.Text.Length - 1)
        End If
        If txtfrmyear.Text.Length > 4 Then
            txtfrmyear.Text = txtfrmyear.Text.Remove(txtfrmyear.Text.Length - 1)
        End If
    End Sub

    Private Sub txttoyear_TextChanged(sender As Object, e As EventArgs) Handles txttoyear.TextChanged
        If (System.Text.RegularExpressions.Regex.IsMatch(txttoyear.Text, "[^0-9]")) Then
            MessageBox.Show("Please enter only numbers.")
            txttoyear.Text = txttoyear.Text.Remove(txttoyear.Text.Length - 1)
        End If
        If txttoyear.Text.Length > 4 Then
            txttoyear.Text = txttoyear.Text.Remove(txttoyear.Text.Length - 1)
        End If
    End Sub

    Private Sub txtfrmprd_TextChanged(sender As Object, e As EventArgs) Handles txtfrmprd.TextChanged
        If (System.Text.RegularExpressions.Regex.IsMatch(txtfrmprd.Text, "[^0-9]")) Then
            MessageBox.Show("Please enter only numbers.")
            txtfrmprd.Text = txtfrmprd.Text.Remove(txtfrmprd.Text.Length - 1)
        End If
        If txtfrmprd.Text.Length > 2 Then
            txtfrmprd.Text = txtfrmprd.Text.Remove(txtfrmprd.Text.Length - 1)
        End If
    End Sub

    Private Sub txttoprd_TextChanged(sender As Object, e As EventArgs) Handles txttoprd.TextChanged
        If (System.Text.RegularExpressions.Regex.IsMatch(txttoprd.Text, "[^0-9]")) Then
            MessageBox.Show("Please enter only numbers.")
            txttoprd.Text = txttoprd.Text.Remove(txttoprd.Text.Length - 1)
        End If
        If txttoprd.Text.Length > 2 Then
            txttoprd.Text = txttoprd.Text.Remove(txttoprd.Text.Length - 1)
        End If
    End Sub


End Class
