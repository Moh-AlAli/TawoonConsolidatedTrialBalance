Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Xml.Linq
Imports ACCPAC.Advantage

Friend Class Program
    <STAThread>
    Shared Sub Main(ByVal args As String())
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        If args.Length = 0 Then
            Dim orgs As XElement = New XElement("orgs")
            Dim ses As Session = New Session()
            Try
                ses.Init("", "XX", "XX1000", "67A")
                Dim os As Organizations = ses.Organizations

                For Each o As Organization In os

                    If o.Type = OrganizationType.Company Then
                        Dim org As XElement = New XElement("org", New XElement("name", o.Name), New XElement("id", o.ID))
                        orgs.Add(org)
                    End If
                Next

                ses.Dispose()
                Dim lofrm As FrmLogin = New FrmLogin(orgs)
                Dim login As DialogResult = lofrm.ShowDialog()

                If login = DialogResult.OK Then
                    Dim frmm As consldtranslist = New consldtranslist(lofrm.ERPSession, lofrm.Company, lofrm.SesDate)
                    Application.Run(frmm)
                Else
                    Application.[Exit]()
                End If

            Catch ex As Exception
                Dim erstr As String = ""
                Dim erlst As List(Of String) = New List(Of String)()
                Util.FillErrors(ex, ses, erlst)

                For Each s As String In erlst
                    erstr += s & vbCrLf
                Next

                Dim ms As String = "Sage 300 ERP Error: " & erstr
                ses.Dispose()
                MessageBox.Show(ms, "Consolidated Trans.List", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Application.[Exit]()
            End Try
        Else
            Dim frm As consldtranslist = New consldtranslist(args(0))
            Application.Run(frm)
        End If
    End Sub
End Class


