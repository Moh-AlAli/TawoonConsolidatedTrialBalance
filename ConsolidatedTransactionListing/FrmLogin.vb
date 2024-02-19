Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports System.Xml.Linq
Imports ACCPAC.Advantage


Partial Friend Class FrmLogin
    Inherits Form
    Friend Property Company As ERPCompany

    Friend Property SesDate As String
    Friend Property ERPSession As Session
    Public compid As String
    Friend Sub New(ByVal Orgs As XElement)
        InitializeComponent()
        Dim comps = From org In Orgs.Elements("org") Select org
        For Each comp In comps
            Dim c As ERPCompany = New ERPCompany(comp.Elements("name").ElementAt(0).Value, comp.Elements("id").ElementAt(0).Value)
            cmbComp.Items.Add(c)
        Next
        cmbComp.SelectedIndex = 0
    End Sub
    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If txtUser.Text = "" Then
            MessageBox.Show(Me, "User ID has not been assignd." & vbCrLf & "Enter an existing user ID or ask your system administrator to add a new record for this user.", "Consolidated Trans.List", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If txtPwd.Text = "" Then
            MessageBox.Show(Me, "Password Can't be blank." & vbCrLf & "Enter an existing user ID and correct password.", "Consolidated Trans.List", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        Dim c As ERPCompany = CType(cmbComp.SelectedItem, ERPCompany)

        Try
            ERPSession = New Session()
            ERPSession.Init("", "XX", "XX1000", "67A")
            ERPSession.Open(txtUser.Text.ToUpper(), txtPwd.Text.ToUpper(), c.ID.ToUpper(), DateTime.Parse(dtSesDate.Text), 0)
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

        Company = c
        compid = c.ID.ToUpper()
        SesDate = dtSesDate.Text
        DialogResult = DialogResult.OK
        Close()

    End Sub


End Class

