Public Class CustomControls



    Class ScrollControl
        Public S As Slider
        Public L As SliderLabel
        Sub New(xin As Integer, yin As Integer, def As Integer, msg As String)
            S = New Slider(xin, yin, def)
            L = New SliderLabel(S, msg)
        End Sub
    End Class

    Public Class SliderLabel

        Inherits Label
        Sub New(S As Slider, msg As String)
            Me.Text = msg
            Me.Top = S.Top + 8
            Me.ForeColor = Color.White
            Me.Left = S.Left - Me.Width + 30

            Form1.Controls.Add(Me)
        End Sub
    End Class

    Public Class Slider
        Inherits TrackBar
        Private Const WM_SETFOCUS As Integer = &H7
        Public Sub New(x As Integer, y As Integer, def As Integer)
            Me.Value = def
            Me.Left = x
            Me.Top = y
            Form1.Controls.Add(Me)
        End Sub
        Protected Overrides Sub WndProc(ByRef m As Message)
            If m.Msg = WM_SETFOCUS Then
                Return
            End If

            MyBase.WndProc(m)
        End Sub
    End Class

End Class
