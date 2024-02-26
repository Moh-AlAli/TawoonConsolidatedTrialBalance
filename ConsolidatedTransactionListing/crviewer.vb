Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports acc = ACCPAC.Advantage
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox

Friend Class crviewer
    Private rdoc As New ReportDocument
    Private conrpt As New ConnectionInfo()
    Dim server As String = ""
    Dim uid As String = ""
    Dim pass As String = ""

    Private ccompid As String
    Private ccompname As String

    Private cfacct As String
    Private ctacct As String
    Private cfdate As String
    Private ctdate As String
    Private crbram As Boolean
    Private crbgen As Boolean
    Private crbjor As Boolean
    Private crbocj As Boolean
    Private crbleb As Boolean
    Private cftyp As String
    Private cttyp As String
    Private cfsubt As String
    Private ctsubt As String
    Private cfcat As String
    Private ctcat As String
    Private cfarea As String
    Private ctarea As String
    Private cfbenf As String
    Private ctbenf As String
    Private cfemp As String
    Private ctemp As String
    Private cfgcd As String
    Private ctgcd As String
    Private cfprog As String
    Private ctprog As String
    Private cfoff As String
    Private ctoff As String
    Private cfdnr As String
    Private ctdnr As String
    Private cfdnrnew As String
    Private ctdnrnew As String
    Private cfdon As String
    Private ctdon As String
    Private cfgrn As String
    Private ctgrn As String
    Private cfdep1 As String
    Private ctdep1 As String
    Private cfdep2 As String
    Private ctdep2 As String
    Private cfdep3 As String
    Private ctdep3 As String
    Private cfdep4 As String
    Private ctdep4 As String
    Private cfdep5 As String
    Private ctdep5 As String
    Private cfdep6 As String
    Private ctdep6 As String
    Private cfdep7 As String
    Private ctdep7 As String
    Private cfdep8 As String
    Private ctdep8 As String
    Private cfproj As String
    Private ctproj As String
    Private cfprogs As String
    Private ctprogs As String

    Friend Property ObjectHandle As String
    Friend Function createdes(ByVal key As String) As TripleDES
        Dim md5 As MD5 = New MD5CryptoServiceProvider()
        Dim des As TripleDES = New TripleDESCryptoServiceProvider()
        des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key))
        des.IV = New Byte(des.BlockSize \ 8 - 1) {}
        Return des
    End Function
    Friend Function Decryption(ByVal cyphertext As String, ByVal key As String) As String
        Dim b As Byte() = Convert.FromBase64String(cyphertext)
        Dim des As TripleDES = createdes(key)
        Dim ct As ICryptoTransform = des.CreateDecryptor()
        Dim output As Byte() = ct.TransformFinalBlock(b, 0, b.Length)
        Return Encoding.Unicode.GetString(output)
    End Function
    Friend Function Readconnectionstring() As String

        Dim secretkey As String = "Fhghqwjehqwlegtoit123mnk12%&4#"
        Dim path As String = ("txtcon\welfcon.txt")
        Dim sr As New StreamReader(path)

        server = sr.ReadLine()
        Dim db As String = sr.ReadLine()
        uid = sr.ReadLine()
        pass = sr.ReadLine()


        server = Decryption(server, secretkey)
        uid = Decryption(uid, secretkey)
        pass = Decryption(pass, secretkey)

        Dim cons As String = "" '"Data Source =(Local); DataBase =" & custstatement.compid & "; User Id =" & uid & "; Password =" & pass & ";"

        Return cons
    End Function
    Public Sub New(ByVal _objectHandle As String, ByVal _sess As acc.Session, ByVal facct As String, ByVal tacct As String, ByVal fdate As String, ByVal tdate As String, ByVal rbram As Boolean, ByVal rbgen As Boolean, ByVal rbjor As Boolean, ByVal rbocj As Boolean, ByVal rbleb As Boolean, ByVal opttype As String, ByVal optsubt As String, ByVal optcat As String, ByVal optarea As String, ByVal optbenf As String, ByVal optemp As String, ByVal optgcd As String, ByVal optprog As String, ByVal optoff As String, ByVal optdnr As String, ByVal optdnrnew As String, ByVal optdon As String, ByVal optgrn As String, ByVal optdept1 As String, ByVal optdept2 As String, ByVal optdept3 As String, ByVal optdept4 As String, ByVal optdept5 As String, ByVal optdept6 As String, ByVal optdept7 As String, ByVal optdept8 As String, ByVal optproj As String, ByVal optprogs As String _
        , ByVal topttype As String, ByVal toptsubt As String, ByVal toptcat As String, ByVal toptarea As String, ByVal toptbenf As String, ByVal toptemp As String, ByVal toptgcd As String, ByVal toptprog As String, ByVal toptoff As String, ByVal toptdnr As String, ByVal toptdnrnew As String, ByVal toptdon As String, ByVal toptgrn As String, ByVal toptdept1 As String, ByVal toptdept2 As String, ByVal toptdept3 As String, ByVal toptdept4 As String, ByVal toptdept5 As String, ByVal toptdept6 As String, ByVal toptdept7 As String, ByVal toptdept8 As String, ByVal toptproj As String, ByVal toptprogs As String)

        InitializeComponent()
        ObjectHandle = _objectHandle
        ccompid = _sess.CompanyID
        ccompname = _sess.CompanyName
        cfacct = facct
        ctacct = tacct
        cfdate = fdate
        ctdate = tdate

        crbram = rbram
        crbgen = rbgen
        crbjor = rbjor
        crbocj = rbocj
        crbleb = rbleb
        cftyp = opttype
        cfsubt = optsubt
        cfcat = optcat
        cfarea = optarea
        cfbenf = optbenf
        cfemp = optemp
        cfgcd = optgcd
        cfprog = optprog
        cfoff = optoff
        cfdnr = optdnr
        cfdnrnew = optdnrnew
        cfdon = optdon
        cfgrn = optgrn
        cfdep1 = optdept1
        cfdep2 = optdept2
        cfdep3 = optdept3
        cfdep4 = optdept4
        cfdep5 = optdept5
        cfdep6 = optdept6
        cfdep7 = optdept7
        cfdep8 = optdept8
        cfproj = optproj
        cfprogs = optprogs

        cttyp = topttype
        ctsubt = toptsubt
        ctcat = toptcat
        ctarea = toptarea
        ctbenf = toptbenf
        ctemp = toptemp
        ctgcd = toptgcd
        ctprog = toptprog
        ctoff = toptoff
        ctdnr = toptdnr
        ctdnrnew = toptdnrnew
        ctdon = toptdon
        ctgrn = toptgrn
        ctdep1 = toptdept1
        ctdep2 = toptdept2
        ctdep3 = toptdept3
        ctdep4 = toptdept4
        ctdep5 = toptdept5
        ctdep6 = toptdept6
        ctdep7 = toptdept7
        ctdep8 = toptdept8
        ctproj = toptproj
        ctprogs = toptprogs

    End Sub

    Public Sub New(ByVal _objectHandle As String)
        InitializeComponent()
        ObjectHandle = _objectHandle
    End Sub

    Private Sub crviewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim cwvr As New CrystalReportViewer
            cwvr.Dock = DockStyle.Fill
            cwvr.BorderStyle = BorderStyle.None
            cwvr.ExportReport()
            Me.Controls.Add(cwvr)




            rdoc.Load("reports\GLTRIALOPTPROV.rpt")


            Dim tabs As Tables = rdoc.Database.Tables
            Dim parv As New ParameterValues
            Dim dis As New ParameterDiscreteValue


            Readconnectionstring()
            For Each TAB As CrystalDecisions.CrystalReports.Engine.Table In tabs
                Dim tablog As TableLogOnInfo = TAB.LogOnInfo
                conrpt.ServerName = server
                conrpt.DatabaseName = ccompid
                conrpt.UserID = uid
                conrpt.Password = pass
                tablog.ConnectionInfo = conrpt
                TAB.ApplyLogOnInfo(tablog)
            Next




            Dim entity1 As String = ""
            Dim entity2 As String = ""
            Dim entity3 As String = ""
            Dim entity4 As String = ""
            Dim entity5 As String = ""
            If crbram = True Then
                entity1 = "RAMDAT"
            End If
            'If crbgen = True Then
            '    entity = entity + "GENDAT,"
            'End If
            If crbjor = True Then
                entity2 = "JORDAT"
            End If
            If crbocj = True Then
                entity3 = "OCJDAT"
            End If
            If crbleb = True Then
                entity4 = "LEBDAT"
            End If

            If crbgen = True Then
                entity5 = "GENDAT"
            End If
            ' entity = entity.Substring(0, entity.Length() - 1)
            rdoc.SetParameterValue("fromyp", cfdate)
            rdoc.SetParameterValue("toyp", ctdate)

            rdoc.SetParameterValue("fromacct", cfacct)
            rdoc.SetParameterValue("toacct", ctacct)

            rdoc.SetParameterValue("fromtyp", cftyp)
            rdoc.SetParameterValue("totyp", cttyp)

            rdoc.SetParameterValue("fromsubt", cfsubt)
            rdoc.SetParameterValue("tosubt", ctsubt)

            rdoc.SetParameterValue("fromcat", cfcat)
            rdoc.SetParameterValue("tocat", ctcat)

            rdoc.SetParameterValue("fromarea", cfarea)
            rdoc.SetParameterValue("toarea", ctarea)

            rdoc.SetParameterValue("frombenf", cfbenf)
            rdoc.SetParameterValue("tobenf", ctbenf)

            rdoc.SetParameterValue("fromemp", cfemp)
            rdoc.SetParameterValue("toemp", ctemp)

            rdoc.SetParameterValue("fromgcd", cfgcd)
            rdoc.SetParameterValue("togcd", ctgcd)

            rdoc.SetParameterValue("fromprog", cfprog)
            rdoc.SetParameterValue("toprog", ctprog)

            rdoc.SetParameterValue("fromoff", cfoff)
            rdoc.SetParameterValue("tooff", ctoff)

            rdoc.SetParameterValue("fromdnr", cfdnr)
            rdoc.SetParameterValue("todnr", ctdnr)

            rdoc.SetParameterValue("fromdnrnew", cfdnrnew)
            rdoc.SetParameterValue("todnrnew", ctdnrnew)

            rdoc.SetParameterValue("fromdon", cfdon)
            rdoc.SetParameterValue("todon", ctdon)

            rdoc.SetParameterValue("fromgrnt", cfgrn)
            rdoc.SetParameterValue("togrnt", ctgrn)

            rdoc.SetParameterValue("fromdept1", cfdep1)
            rdoc.SetParameterValue("todept1", ctdep1)

            rdoc.SetParameterValue("fromdept2", cfdep2)
            rdoc.SetParameterValue("todept2", ctdep2)

            rdoc.SetParameterValue("fromdept3", cfdep3)
            rdoc.SetParameterValue("todept3", ctdep3)

            rdoc.SetParameterValue("fromdept4", cfdep4)
            rdoc.SetParameterValue("todept4", ctdep4)

            rdoc.SetParameterValue("fromdept5", cfdep5)
            rdoc.SetParameterValue("todept5", ctdep5)

            rdoc.SetParameterValue("fromdept6", cfdep6)
            rdoc.SetParameterValue("todept6", ctdep6)

            rdoc.SetParameterValue("fromdept7", cfdep7)
            rdoc.SetParameterValue("todept7", ctdep7)

            rdoc.SetParameterValue("fromdept8", cfdep8)
            rdoc.SetParameterValue("todept8", ctdep8)

            rdoc.SetParameterValue("fromproj", cfproj)
            rdoc.SetParameterValue("toproj", ctproj)

            rdoc.SetParameterValue("fromprogs", cfprogs)
            rdoc.SetParameterValue("toprogs", ctprogs)

            rdoc.SetParameterValue("entity1", entity1)
            rdoc.SetParameterValue("entity2", entity2)
            rdoc.SetParameterValue("entity3", entity3)
            rdoc.SetParameterValue("entity4", entity4)
            rdoc.SetParameterValue("entity5", entity5)
            ' rdoc.SetParameterValue("CMPNAME", ccompname)
            cwvr.ReportSource = rdoc

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            If rdoc Is Nothing Then
                rdoc.Close()
                rdoc.Dispose()
            End If
        End Try
    End Sub


End Class



