Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Linq
Imports System.Xml.Linq
Imports System.Collections.Generic
Imports acc = ACCPAC.Advantage
Imports System.Runtime.InteropServices

Partial Class FromFinder
    Inherits Form

    Private ReadOnly _entity As String
    Private ReadOnly _keyfields As String()
    Private ReadOnly _ses As acc.Session
    Private ReadOnly _deffilter As String
    Private ReadOnly _multiselect As Boolean
    Private ReadOnly _iniFilter As String = ""
    Private cram As String
    Private cgen As String
    Private cjor As String
    Private cocj As String
    Private cleb As String

    Friend Property Result As DataItem
    Friend Property ResultSet As List(Of DataItem)
    Private Sub CMBDrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles cmbOperation.DrawItem, cmbFindBy.DrawItem
        e.DrawBackground()
        Dim br As Brush = Brushes.Black
        e.Graphics.DrawString((CType(sender, ComboBox)).Items(e.Index).ToString(), e.Font, br, e.Bounds, StringFormat.GenericDefault)
        e.DrawFocusRectangle()
    End Sub
    Friend Sub New(ByVal entity As String, ByVal capt As String, ByVal CHBXRAM As String, ByVal CHBXGEN As String, ByVal CHBXJOR As String, ByVal CHBXOCJ As String, ByVal CHBXLEB As String, ByVal keyFields As String(), ByVal ses As acc.Session, ByVal DefaultFilter As String, ByVal iniFilter As String, ByVal Optional multiSelect As Boolean = False)
        InitializeComponent()
        _deffilter = DefaultFilter
        _entity = entity
        _keyfields = keyFields
        _ses = ses
        cram = CHBXRAM
        cgen = CHBXGEN
        cjor = CHBXJOR
        cocj = CHBXOCJ
        cleb = CHBXLEB

        ' chkAutoSearch.Checked = Properties.Settings.[Default].FinderAutoSearch
        _multiselect = multiSelect
            _iniFilter = iniFilter
            Dim cols As ColumnHeader() = New ColumnHeader() {}
            Select Case _entity
                Case "GLAMF"

                    cols = New ColumnHeader() {New ColumnHeader() With {
                            .Text = "Account Number",
                            .Width = 200
                        }, New ColumnHeader() With {
                            .Text = "Decription",
                            .Width = 300
                        }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Account Number", "C", "ACCTID"), New LookupItem("Description", "C", "ACCTDESC")})
                    Exit Select
                Case "OPTFDTYPE"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDSUBTYPE"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDCATEGORY"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select

                Case "OPTFDAREA"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select

                Case "OPTFDBENF"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDEMP"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDGCOD"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDPROG"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDOFF"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDDNR"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDDNRNEW"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDDON"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDGRN"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDDEP1"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDDEP1"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDDEP2"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDDEP3"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDDEP4"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDDEP5"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDDEP6"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDDEP7"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDDEP8"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDPROJ"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                    Exit Select
                Case "OPTFDPROGS"
                    cols = New ColumnHeader() {New ColumnHeader() With {
                         .Text = "Value",
                         .Width = 300
                     }}
                    lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                    cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                Exit Select
                Exit Select
            Case "OPTFDPROGSCOMP"
                cols = New ColumnHeader() {New ColumnHeader() With {
                     .Text = "Value",
                     .Width = 300
                 }}
                lstData.Items.Add(New ListViewItem(New String() {" ", " "}))
                cmbFindBy.Items.AddRange(New LookupItem() {New LookupItem("Show All Records", "C", "ALL"), New LookupItem("Value", "C", "VALUE")})
                Exit Select
        End Select
            Text = capt
            lstData.Columns.AddRange(cols)
            lstData.MultiSelect = _multiselect
            cmbFindBy.SelectedIndex = 0
            'cmbFindBy.DrawToBitmap += New DrawItemEventHandler(AddressOf CMBDrawItem)
            cmbOperation.Visible = False

            If chkAutoSearch.Checked Then
                cmdFind.Enabled = False
                FillData(iniFilter, True)
            End If

    End Sub

    Private Sub TDecimalKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then e.Handled = True
    End Sub

    Private Sub TIntergerKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub FilterChanged(ByVal sender As Object, ByVal e As EventArgs)
        If chkAutoSearch.Checked Then FillData("")
    End Sub

    Private Sub FillData(ByVal iniFilter As String, ByVal Optional iniz As Boolean = False)
        lstData.Items.Clear()
        Dim dff As String = ""

        If String.IsNullOrEmpty(iniFilter) Then
            dff = If(String.IsNullOrEmpty(_deffilter), "", _deffilter)
        Else
            dff = If(String.IsNullOrEmpty(_deffilter), iniFilter, _deffilter & " and " & iniFilter)
        End If

        Dim fl As LookupItem = CType(cmbFindBy.SelectedItem, LookupItem)
        Dim fil As XElement = New XElement("entfind", New XElement("findby", fl.Field), New XElement("fldtyp", fl.ItemType), New XElement("operation", cmbOperation.Text), New XElement("filter", getFilter()), New XElement("deffilter", dff))
        Dim data As XElement = Nothing
        Dim msg As String = FindEx(_entity, fil, data, iniz)

        If msg.Length <> 0 Then
            MessageBox.Show(Me, msg, "Consolidated Trans.List", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return
        End If

        If data IsNot Nothing Then
            Dim recs = From rec In data.Elements("record") Select rec

            For Each rc In recs
                Dim ditm As DataItem = New DataItem(_keyfields, rc)
                Dim itm As ListViewItem = New ListViewItem(ditm.ToArray()) With {
                    .Tag = ditm
                }
                lstData.Items.Add(itm)
            Next
        End If
    End Sub
    Private Function getFilter() As String
        If crtPan.Controls.Count > 0 Then
            Dim c As Control = crtPan.Controls(0)

            If TypeOf c Is ComboBox Then

                If CStr(c.Tag) = "hash" Then
                    Return (CType((CType(c, ComboBox)).SelectedItem, KeyValuePair(Of String, String))).Key
                Else
                    Return (CType(c, ComboBox)).SelectedIndex.ToString()
                End If
            ElseIf TypeOf c Is DateTimePicker Then
                Return c.Text.Replace("-", "")
            Else
                Return c.Text
            End If
        Else
            Return ""
        End If
    End Function
    Private Sub SetResult()
        If Not _multiselect Then
            Result = If(lstData.SelectedItems.Count > 0, CType(lstData.SelectedItems(0).Tag, DataItem), New DataItem())
        Else

            If lstData.SelectedItems.Count > 0 Then
                ResultSet = New List(Of DataItem)()

                For Each itm As ListViewItem In lstData.SelectedItems
                    ResultSet.Add(CType(itm.Tag, DataItem))
                Next
            Else
                ResultSet = New List(Of DataItem)()
            End If
        End If
    End Sub
    Private Function FindEx(ByVal entity As String, ByVal filter As XElement, <Out> ByRef xmlData As XElement, ByVal Optional limit As Boolean = True) As String
        xmlData = Nothing
        Dim fields As String() = Nothing

        Try
            Dim wsql As String = ""
            Dim fld As String = filter.Elements("findby").ElementAt(0).Value.Trim()

            If fld.ToLower() = "all" OrElse fld = "" Then
                wsql = ""
            Else

                If filter.Elements("filter").ElementAt(0).Value.Trim() = "" Then
                    wsql = ""
                Else
                    wsql = " where " & fld
                    Dim ftyp As String = filter.Elements("fldtyp").ElementAt(0).Value.Trim()

                    If ftyp = "C" Then

                        If filter.Elements("operation").ElementAt(0).Value.Trim() = "Exact" Then
                            wsql += " = "
                        Else
                            wsql += " like "
                        End If

                        If filter.Elements("operation").ElementAt(0).Value.Trim() = "Contains" Then
                            wsql += "'%" & filter.Elements("filter").ElementAt(0).Value.Trim() & "%'"
                        ElseIf filter.Elements("operation").ElementAt(0).Value.Trim() = "Exact" Then
                            wsql += "'" & filter.Elements("filter").ElementAt(0).Value.Trim() & "'"
                        Else
                            wsql += "'" & filter.Elements("filter").ElementAt(0).Value.Trim() & "%'"
                        End If
                    ElseIf ftyp = "D" Then
                        wsql += " " & filter.Elements("operation").ElementAt(0).Value.Trim() & " " & filter.Elements("filter").ElementAt(0).Value.Trim().Replace("-", "")
                    Else
                        wsql += " " & filter.Elements("operation").ElementAt(0).Value.Trim() & " " & filter.Elements("filter").ElementAt(0).Value.Trim()
                    End If
                End If
            End If

            Dim dfl As String = If(filter.Elements("deffilter").Any(), filter.Elements("deffilter").ElementAt(0).Value.Trim(), "")
            Dim qlf As String = ""
            If dfl <> "" Then qlf = If(wsql = "", " where ", " and ")
            wsql += qlf & dfl

            Dim sql As String = Util.GetNativeSQL(entity, fields, cram, cgen, cjor, cocj, cleb, limit)

            If wsql <> "" Then

                If sql.IndexOf(" where ", StringComparison.CurrentCultureIgnoreCase) <> -1 Then
                    sql += wsql.Replace("where", "and")
                Else
                    sql += wsql
                End If
            End If

            Dim lnk As acc.DBLink = _ses.OpenDBLink(acc.DBLinkType.Company, acc.DBLinkFlags.[ReadOnly])
            Dim opQry As acc.View = lnk.OpenView("CS0120")
            opQry.Cancel()
            opQry.Browse(sql, True)
            opQry.InternalSet(256)

            While opQry.Fetch(False)
                If xmlData Is Nothing Then xmlData = New XElement("records")
                Dim rec As XElement = New XElement("record")

                For Each s As String In fields
                    Dim ss As String = s.Split(","c)(0)
                    If ss.IndexOf(".") <> -1 Then ss = ss.Split("."c)(1)
                    ss = ss.Replace("[", "").Replace("]", "")
                    Dim st As String = s.Split(","c)(1)
                    Dim v As String = opQry.Fields.FieldByName(ss).Value.ToString().Trim()
                    Dim tmp As XElement = Nothing

                    If st = "1" Then
                        tmp = New XElement(ss, If(v = "0", "No", "Yes"))
                    ElseIf st = "2" Then
                        tmp = New XElement(ss, If(v = "0", "Inactive", "Active"))
                    ElseIf st = "3" Then
                        tmp = New XElement(ss, If(v = "1", "Inactive", "Active"))
                    ElseIf st = "4" Then
                        tmp = New XElement(ss, If(v = "0", "Physical", "Logical"))
                    ElseIf st = "5" Then

                        Select Case v
                            Case "1"
                                tmp = New XElement(ss, "By Quantity")
                            Case "2"
                                tmp = New XElement(ss, "By Weight")
                            Case "3"
                                tmp = New XElement(ss, "By Cost")
                            Case "4"
                                tmp = New XElement(ss, "Equally")
                            Case "5"
                                tmp = New XElement(ss, "Manually")
                            Case Else
                                tmp = New XElement(ss, "Unknown")
                        End Select
                    ElseIf st = "6" Then

                        Select Case v
                            Case "1"
                                tmp = New XElement(ss, "Entered")
                            Case "2"
                                tmp = New XElement(ss, "Posted")
                            Case "3"
                                tmp = New XElement(ss, "Costed")
                            Case "20"
                                tmp = New XElement(ss, "Day-End Completed")
                            Case Else
                                tmp = New XElement(ss, "Unknown")
                        End Select
                    ElseIf st = "7" Then
                        tmp = New XElement(ss, If(v = "0", "Not Available", "Available"))
                    ElseIf st = "8" Then

                        Select Case v
                            Case "1"
                                tmp = New XElement(ss, "Incomplete/Not Included")
                            Case "2"
                                tmp = New XElement(ss, "Incomplete/Included")
                            Case "3"
                                tmp = New XElement(ss, "Complete/Not Included")
                            Case "4"
                                tmp = New XElement(ss, "Complete/Included")
                            Case "5"
                                tmp = New XElement(ss, "Complete/Day End")
                        End Select
                    ElseIf st = "@" Then
                        tmp = New XElement(ss, v.Substring(0, 4) & "-" & v.Substring(4, 2) & "-" & v.Substring(6, 2))
                    ElseIf st = "i" Then
                        tmp = New XElement(ss, If(Decimal.Parse(v) = 0D, "0", v))
                    Else
                        tmp = New XElement(ss, v)
                    End If

                    rec.Add(tmp)
                Next

                xmlData.Add(rec)
            End While

            opQry.Dispose()
            lnk.Dispose()
            Return ""
        Catch ex As Exception
            Dim erstr As String = ""
            Dim erlst As List(Of String) = New List(Of String)()
            Util.FillErrors(ex, _ses, erlst)

            For Each s As String In erlst
                erstr += s & vbCrLf
            Next

            Dim ms As String = "Sage 300 ERP Error: " & erstr
            Return ms
        End Try
    End Function
    Private Sub lstData_DoubleClick(sender As Object, e As EventArgs) Handles lstData.DoubleClick
        SetResult()
        DialogResult = DialogResult.OK
        Close()
    End Sub
    Private Sub lstData_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles lstData.DrawColumnHeader
        e.Graphics.FillRectangle(Brushes.DimGray, e.Bounds)
        e.Graphics.DrawRectangle(SystemPens.GradientInactiveCaption, New Rectangle(e.Bounds.X, 0, e.Bounds.Width, e.Bounds.Height))
        Dim text As String = lstData.Columns(e.ColumnIndex).Text
        Dim cFlag As TextFormatFlags = TextFormatFlags.Left Or TextFormatFlags.VerticalCenter
        TextRenderer.DrawText(e.Graphics, text, lstData.Font, e.Bounds, Color.White, cFlag)
    End Sub
    Private Sub lstData_DrawItem(sender As Object, e As DrawListViewItemEventArgs) Handles lstData.DrawItem
        e.DrawDefault = True

    End Sub

    Private Sub lstData_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles lstData.DrawSubItem
        e.DrawDefault = True
    End Sub

    Private Sub cmdFind_Click(sender As Object, e As EventArgs) Handles cmdFind.Click
        FillData("")
    End Sub

    Private Sub chkAutoSearch_Click(sender As Object, e As EventArgs) Handles chkAutoSearch.Click, chkAutoSearch.CheckedChanged
        ' Properties.Settings.[Default].FinderAutoSearch = chkAutoSearch.Checked

        If chkAutoSearch.Checked Then
            cmdFind.Enabled = False
            FillData("")
        Else
            cmdFind.Enabled = True
        End If
    End Sub

    Private Sub cmbFindBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFindBy.SelectedIndexChanged
        If cmbFindBy.SelectedIndex = 0 Then
            cmbOperation.Visible = False
            crtPan.Controls.Clear()
            If chkAutoSearch.Checked Then FillData(_iniFilter, True)
            Return
        End If

        ' cmbOperation.DrawItem -= New DrawItemEventHandler(AddressOf CMBDrawItem)
        ' cmbOperation.Items.Clear()
        cmbOperation.Enabled = True
        Dim itm As LookupItem = CType(cmbFindBy.SelectedItem, LookupItem)

        If itm.ItemType = "C" Then
            If cmbOperation.Items.Count = 0 Then
                cmbOperation.Items.AddRange(New LookupItem() {New LookupItem("Contains"), New LookupItem("Starts With")})
            End If
        ElseIf itm.ItemType = "L" Then
            If cmbOperation.Items.Count = 0 Then
                cmbOperation.Items.AddRange(New LookupItem() {New LookupItem("=")})
            End If

        Else
            If cmbOperation.Items.Count = 0 Then
                cmbOperation.Items.AddRange(New LookupItem() {New LookupItem("="), New LookupItem(">"), New LookupItem("<"), New LookupItem(">="), New LookupItem("<="), New LookupItem("!=")})
            End If
        End If

        cmbOperation.SelectedIndex = 0
        'cmbOperation.DrawItem += New DrawItemEventHandler(CMBDrawItem)
        cmbOperation.Visible = True
        cmbOperation.Invalidate()

        For Each c As Control In crtPan.Controls
            c.Dispose()
        Next

        crtPan.Controls.Clear()

        Select Case itm.ItemType
            Case "C"
                Dim txt As FilterTextBox = New FilterTextBox() With {
                .Size = crtPan.Size,
                .Name = "Filter",
                .DelayMs = 1000
            }
                crtPan.Controls.Add(txt)

                'txt.FilterChanged = New EventHandler(FilterChanged)
            Case "D"
                Dim dt As DateTimePicker = New DateTimePicker() With {
                .Size = crtPan.Size,
                .Name = "Filter",
                .Format = DateTimePickerFormat.Custom,
                .CustomFormat = "yyy-MM-dd"
            }
                crtPan.Controls.Add(dt)
                'dt.ValueChanged += New EventHandler(FilterChanged)
            Case "L"
                cmbOperation.Enabled = False
                Dim cmb As ComboBox = New ComboBox() With {
                .DrawMode = DrawMode.OwnerDrawFixed,
                .DropDownStyle = ComboBoxStyle.DropDownList,
                .Name = "Filter"
            }
                cmb.Items.AddRange(itm.Selection)
                cmb.SelectedIndex = 0
                'cmb.DrawItem += New DrawItemEventHandler(CMBDrawItem)
                crtPan.Controls.Add(cmb)
                'cmb.SelectedIndexChanged += New EventHandler(FilterChanged)
            Case "N"
                Dim dtxt As FilterTextBox = New FilterTextBox() With {
                .Size = crtPan.Size,
                .Name = "Filter",
                .DelayMs = 1000
            }
                '    dtxt.KeyPress += New KeyPressEventHandler(TDecimalKeyPress)
                crtPan.Controls.Add(dtxt)
            '    dtxt.FilterChanged += New EventHandler(FilterChanged)
            Case "I"
                Dim itxt As FilterTextBox = New FilterTextBox() With {
                .Size = crtPan.Size,
                .Name = "Filter",
                .DelayMs = 1000
            }
                '  itxt.KeyPress += New KeyPressEventHandler(TIntergerKeyPress)
                crtPan.Controls.Add(itxt)
            '    itxt.FilterChanged += New EventHandler(FilterChanged)
            Case "H"
                cmbOperation.Enabled = False
                Dim cmbh As ComboBox = New ComboBox() With {
                .DrawMode = DrawMode.OwnerDrawFixed,
                .DropDownStyle = ComboBoxStyle.DropDownList,
                .Name = "Filter",
                .Tag = "hash"
            }
                cmbh.DataSource = New BindingSource(itm.Hash, Nothing)
                cmbh.DisplayMember = "Value"
                cmbh.ValueMember = "Key"
                '    cmbh.DrawItem += New DrawItemEventHandler(CMBDrawItem)
                crtPan.Controls.Add(cmbh)
                '   cmbh.SelectedIndexChanged += New EventHandler(FilterChanged)
        End Select
    End Sub

    Private Sub FromFinder_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lstData.Height = dataPan.Height - 38
    End Sub



    Private Sub cmdSelect_Click(sender As Object, e As EventArgs) Handles cmdSelect.Click
        SetResult()
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub


End Class