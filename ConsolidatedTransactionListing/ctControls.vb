Imports System
Imports System.Windows.Forms
Imports System.Runtime.CompilerServices

'Namespace AutoReceipt
Module ExtensionMethods
        <Extension()>
        Function LOWORD(ByVal intPtr As IntPtr) As Int32
            Dim i As Int32 = intPtr.ToInt32()
            Return (i And &HFFFF)
        End Function

    <Extension()>
    Function HIWORD(ByVal intPtr As IntPtr) As Int32
        Dim i As Int32 = intPtr.ToInt32()
        Return ((i >> 16) And &HFFFF)
    End Function
End Module

    Class FilterTextBox
        Inherits TextBox

        Private _timer As Timer = New Timer()
        Public Event FilterChanged As EventHandler

        Public Property DelayMs As Integer
            Get
                Return _timer.Interval
            End Get
            Set(ByVal value As Integer)
                _timer.Interval = value
            End Set
        End Property

        Public Sub New()
            _timer.Interval = 1500
            AddHandler _timer.Tick, New EventHandler(AddressOf _timer_Tick)
        End Sub

        Private Sub _timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
            _timer.[Stop]()
            OnFilterCanged()
        End Sub

    Protected Overridable Sub OnFilterCanged()
        '   FilterChanged?.Invoke(Me, EventArgs.Empty)
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
            MyBase.OnTextChanged(e)
            _timer.[Stop]()
            _timer.Start()
        End Sub
    End Class

    Class ReadOnlyTextBox
        Inherits TextBox

        Public Property CorrespondingControl As Control

        Protected Overloads ReadOnly Property [ReadOnly] As Boolean
            Get
                Return MyBase.[ReadOnly]
            End Get
        End Property

        Public Sub New()
            MyBase.New()
            MyBase.[ReadOnly] = True
        End Sub

        Protected Overrides Sub OnGotFocus(ByVal e As EventArgs)
            If CorrespondingControl Is Nothing Then
                Me.Parent.Focus()
                Return
            End If

            If CorrespondingControl.CanFocus Then
                CorrespondingControl.Focus()
            Else
                Me.Parent.Focus()
            End If
        End Sub
    End Class

    Class LsvTextBox
        Inherits TextBox

        Private Const WM_PASTE As Integer = &H302
        Public Property NumericOnly As Boolean = False
        Public Property AcceptDecimals As Boolean = False
        Public Property NumberOfDecimals As Integer = 3
        Public Property PassTab As Boolean = True

        Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
            If keyData = Keys.Tab Then

                If PassTab Then
                    Return True
                Else
                    Return MyBase.ProcessCmdKey(msg, keyData)
                End If
            Else
                Return MyBase.ProcessCmdKey(msg, keyData)
            End If
        End Function

        Protected Overrides Sub WndProc(ByRef m As Message)
            Dim tmp As Decimal = Nothing

            If NumericOnly Then

                If m.Msg = WM_PASTE Then

                    If Clipboard.ContainsText(TextDataFormat.Text) Then
                        Dim ctxt As String = Clipboard.GetText(TextDataFormat.Text)
                        If Not Decimal.TryParse(ctxt, tmp) Then Return
                    End If
                End If
            End If

            MyBase.WndProc(m)
        End Sub

        Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
            Dim tmp As Decimal = Nothing

            If NumericOnly Then

                If e.Control AndAlso e.KeyCode = Keys.V Then

                    If Clipboard.ContainsText(TextDataFormat.Text) Then
                        Dim ctxt As String = Clipboard.GetText(TextDataFormat.Text)

                        If Not Decimal.TryParse(ctxt, tmp) Then
                            e.Handled = True
                            e.SuppressKeyPress = True
                            Return
                        End If
                    End If
                End If
            End If

            MyBase.OnKeyDown(e)
        End Sub

        Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
            If NumericOnly Then

                If AcceptDecimals Then
                    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso (e.KeyChar <> "."c) AndAlso e.KeyChar <> vbTab Then e.Handled = True
                    If (e.KeyChar = "."c) AndAlso (Text.IndexOf("."c) > -1) Then e.Handled = True

                    If Text.IndexOf("."c) > -1 Then
                        If Text.Split("."c)(1).Length >= NumberOfDecimals AndAlso e.KeyChar <> vbBack Then e.Handled = True
                    End If
                Else
                    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> vbTab Then e.Handled = True
                End If
            Else
                MyBase.OnKeyPress(e)
            End If
        End Sub
    End Class

    Class ListViewEx
        Inherits ListView

        Private Const WM_LBUTTONDBLCLK As Integer = &H203
        Private Const WM_RBUTTONDBLCLK As Integer = &H206
        Private Const WM_LBUTTONDOWN As Integer = &H201
        Private Const WM_HSCROLL As Integer = &H114
        Private Const WM_VSCROLL As Integer = &H115
        Private _mDblCkFired As Boolean
        Private _mClickFired As Boolean
        Public Event Scroll As ScrollEventHandler

        Protected Overrides Sub OnDoubleClick(ByVal e As EventArgs)
            MyBase.OnDoubleClick(e)
            _mDblCkFired = True
        End Sub

        Protected Overrides Sub OnClick(ByVal e As EventArgs)
            MyBase.OnClick(e)
            _mClickFired = True
        End Sub

    Protected Overridable Sub OnScroll(ByVal e As ScrollEventArgs)
        '    Scroll?.Invoke(Me, e)
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
            _mDblCkFired = False
            _mClickFired = False
            MyBase.WndProc(m)
            If (m.Msg = WM_LBUTTONDBLCLK OrElse m.Msg = WM_RBUTTONDBLCLK) AndAlso Not _mDblCkFired Then OnDoubleClick(EventArgs.Empty)
            If m.Msg = WM_LBUTTONDOWN AndAlso Not _mClickFired Then OnClick(EventArgs.Empty)
            If m.Msg = WM_HSCROLL OrElse m.Msg = WM_VSCROLL Then OnScroll(New ScrollEventArgs(CType((m.WParam.ToInt32() And &HFFFF), ScrollEventType), 0))
        End Sub
    End Class

    Public Class ctMenuRenderer
        Inherits ToolStripSystemRenderer

        Public Sub New()
        End Sub

        Protected Overrides Sub OnRenderToolStripBorder(ByVal e As ToolStripRenderEventArgs)
        End Sub
    End Class
'End Namespace
