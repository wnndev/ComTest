Imports System.ComponentModel
Imports System.IO.Ports
Imports System.IO
Public Class com
    Dim WithEvents RS232 As SerialPort
    Dim comstate As Boolean
    Dim loadstate As Boolean
    Dim time_4bytes As Integer

    Private Sub Com_Load(sender As Object, e As EventArgs) Handles Me.Load
        MinimumSize = New Size(424, 302)
        MaximumSize = New Size(424, 30200)
        comstate = False
        loadstate = False
        ComboBox_rate.Items.Add("600")
        ComboBox_rate.Items.Add("1200")
        ComboBox_rate.Items.Add("2400")
        ComboBox_rate.Items.Add("4800")
        ComboBox_rate.Items.Add("9600")
        ComboBox_rate.Items.Add("14400")
        ComboBox_rate.Items.Add("19200")
        ComboBox_rate.Items.Add("28800")
        ComboBox_rate.Items.Add("38400")
        ComboBox_rate.Items.Add("57600")
        ComboBox_rate.Items.Add("115200")
        ComboBox_rate.Items.Add("230400")
        ComboBox_rate.Items.Add("460800")

        ComboBox_stopbits.Items.Add("1")
        ComboBox_stopbits.Items.Add("2")

        ComboBox_databits.Items.Add("5")
        ComboBox_databits.Items.Add("6")
        ComboBox_databits.Items.Add("7")
        ComboBox_databits.Items.Add("8")

        ComboBox_parity.Items.Add("无")
        ComboBox_parity.Items.Add("偶校验")
        ComboBox_parity.Items.Add("奇校验")
        ComboBox_parity.Items.Add("1校验")
        ComboBox_parity.Items.Add("0校验")
        ComboBox_rate.Text = ComboBox_rate.Items(4)
        ComboBox_stopbits.Text = ComboBox_stopbits.Items(0)
        ComboBox_databits.Text = ComboBox_databits.Items(3)
        ComboBox_parity.Text = ComboBox_parity.Items(0)
        ComRefresh()
        loadset()
        Timer_refresh.Start()
        loadstate = True
    End Sub
    Private Sub ComRefresh()
        Dim ports As String() = SerialPort.GetPortNames()
        Dim oldport As String
        Dim opstay As Boolean = False
        oldport = ComboBox_com.Text
        ComboBox_com.Items.Clear()
        For i = 0 To ports.Length - 1
            'ComboBox_com.Items.Add(ports(i)) '向combobox中添加项
            If oldport = ports(i) Then
                opstay = True
            End If
            Try
                SerialPort.PortName = ports(i)
                SerialPort.Open()
                SerialPort.Close()
                ComboBox_com.Items.Add(ports(i))
            Catch
                ComboBox_com.Items.Add(ports(i) & " (占用)")
            End Try
        Next
        ComboBox_com.Text = oldport
        If ports.Length > 0 And ComboBox_com.Text = "" Or opstay = False Then
            For i = 0 To ports.Length - 1
                If InStr(ComboBox_com.Items(i), "占用"） = 0 Then
                    ComboBox_com.Text = ports(i)
                    Return
                End If
            Next
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer_refresh.Tick
        If Not ComboBox_com.Focused And comstate = False Then
            ComRefresh()
        End If
        If SerialPort.IsOpen Then
            Button_send.Enabled = True
            Label_comstate.Text = "串口已打开"
            comstate = True
            Button_open.Text = "关闭串口"
        Else
            Button_send.Enabled = False
            Label_comstate.Text = "串口已关闭"
            comstate = False
            Button_open.Text = "打开串口"
            Timer_autosend.Enabled = False
            Button_autosend.Text = "打开自动发送"
            Button_autosend.Enabled = False

        End If
    End Sub

    Private Sub Button_refreshcom_Click(sender As Object, e As EventArgs)
        ComRefresh()
    End Sub

    Private Sub ComboBox_com_Enter(sender As Object, e As EventArgs) Handles ComboBox_com.Enter

    End Sub

    Private Sub Button_open_Click(sender As Object, e As EventArgs) Handles Button_open.Click
        If comstate = False Then
            If ComboBox_com.Text = "" Or ComboBox_com.Text = "" Then
                MsgBox("未设置参数！", MsgBoxStyle.Critical)
                Return
            End If
            SerialSet()
            SerialPort.PortName = ComboBox_com.Text
            If Not SerialPort.IsOpen Then
                Try
                    SerialPort.Open()
                Catch ex As Exception
                    MsgBox("通讯端口打开错误或已被占用！", MsgBoxStyle.Critical)
                    Return
                End Try
                Button_send.Enabled = True
                Button_autosend.Enabled = True
                SerialPort.ReceivedBytesThreshold = 1        '设置引发事件的门限值  
                Label_comstate.Text = "串口已打开"
                comstate = True
                Button_open.Text = "关闭串口"

            Else
                MsgBox("通讯端口打开错误或已被占用！", MsgBoxStyle.Critical)
            End If
        Else
            SerialPort.Close()
            comstate = False
            Button_open.Text = "打开串口"
            Label_comstate.Text = "串口已关闭"
            Button_send.Enabled = False
            Timer_autosend.Enabled = False
            Button_autosend.Enabled = False
            Button_autosend.Text = "打开自动发送"
        End If
    End Sub
    Private Sub SerialSet()
        Dim t As Double
        SerialPort.BaudRate = Val(ComboBox_rate.Text)
        t = 40000.0 / Val(ComboBox_rate.Text)
        time_4bytes = t + 1
        Timer_autoenter.Interval = time_4bytes
        SerialPort.DataBits = Convert.ToInt32(ComboBox_databits.Text)
        Select Case ComboBox_parity.Text
            Case ComboBox_parity.Items(0)
                SerialPort.Parity = Parity.None
            Case ComboBox_parity.Items(1)
                SerialPort.Parity = Parity.Even
            Case ComboBox_parity.Items(2)
                SerialPort.Parity = Parity.Odd
            Case ComboBox_parity.Items(3)
                SerialPort.Parity = Parity.Mark
            Case ComboBox_parity.Items(4)
                SerialPort.Parity = Parity.Space
        End Select

        Select Case ComboBox_stopbits.Text
            Case ComboBox_stopbits.Items(0)
                SerialPort.StopBits = StopBits.One
            Case ComboBox_stopbits.Items(1)
                SerialPort.StopBits = StopBits.Two
        End Select
    End Sub

    Private Sub ComboBox_rate_TextChanged(sender As Object, e As EventArgs) Handles ComboBox_rate.TextChanged
        If loadstate Then
            SerialSet()
        End If
    End Sub
    Private Sub ComboBox_databits_TextChanged(sender As Object, e As EventArgs) Handles ComboBox_databits.TextChanged
        If loadstate Then
            SerialSet()
        End If
    End Sub
    Private Sub ComboBox_parity_TextChanged(sender As Object, e As EventArgs) Handles ComboBox_parity.TextChanged
        If loadstate Then
            SerialSet()
        End If
    End Sub
    Private Sub ComboBox_stopbits_TextChanged(sender As Object, e As EventArgs) Handles ComboBox_stopbits.TextChanged
        If loadstate Then
            SerialSet()
        End If
    End Sub
    Private Sub SerialSend()
        Dim databyte() As Byte
        Dim str1() As String
        Dim str2 As String
        Dim str3 As String
        Dim cnt As Integer

        If InStr(TextBox_send.Text, " ") Then '判断是否有空格
            str1 = Split(TextBox_send.Text)
            str2 = Join(str1, "")
        Else
            str2 = TextBox_send.Text
        End If

        Try
            If CheckBox_sendhex.Checked Then
                If str2.Length Mod 2 = 0 Then
                    ReDim databyte(str2.Length / 2) '重新定义数组
                    For i = 0 To str2.Length / 2 - 1
                        databyte(i) = Convert.ToByte(Mid(str2, 2 * i + 1, 2), 16) '两个字符转换为一个16进制字节
                        'databyte(i) = Val(Mid(str2, 2 * i + 1, 2))
                    Next
                    SerialPort.Write(databyte, 0, databyte.Length - 1)
                Else
                    str3 = Mid(str2, 1, (str2.Length - 1)) & "0" & Mid(str2, str2.Length)
                    ReDim databyte(str3.Length / 2)
                    For i = 0 To str3.Length / 2 - 1
                        databyte(i) = Convert.ToByte(Mid(str3, 2 * i + 1, 2), 16)
                    Next
                    SerialPort.Write(databyte, 0, databyte.Length - 1)
                End If
                cnt = Convert.ToInt32(Label_sendcnt.Text)
                Label_sendcnt.Text = Val(cnt + databyte.Length - 1)

            Else
                SerialPort.Write(TextBox_send.Text)
                cnt = Convert.ToInt32(Label_sendcnt.Text)
                Label_sendcnt.Text = Val(cnt + TextBox_send.Text.Length)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button_send_Click(sender As Object, e As EventArgs) Handles Button_send.Click
        SerialSend()
    End Sub

    Private Sub TextBox_rev_TextChanged(sender As Object, e As EventArgs) Handles TextBox_rev.TextChanged

    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort.DataReceived
        Me.Invoke(New EventHandler(AddressOf SerialPort1_DataRec))
    End Sub
    Private Sub SerialPort1_DataRec()
        Dim strIncoming As Integer
        Dim str1() As String
        Dim str2() As String
        Dim bytes() As Byte
        Dim i As Integer
        Dim cnt As Integer
        Dim cnt1 As Integer
        Timer_autoenter.Enabled = False
        Timer_autoenter.Interval = time_4bytes


        Try
            'Threading.Thread.Sleep(10) '添加的延时
            cnt = SerialPort.BytesToRead
            cnt1 = Convert.ToInt32(Label_revcnt.Text)
            Label_revcnt.Text = Val(cnt + cnt1)
            If cnt > 0 Then

                ReDim bytes(cnt)
                'strIncoming = Convert.ToByte(SerialPort1.ReadByte())
                If CheckBox_revhex.Checked = True Then
                    'strIncoming = SerialPort1.ReadByte()
                    'bytes(0) = strIncoming
                    For i = 0 To cnt - 1
                        strIncoming = SerialPort.ReadByte() '读取缓冲区中的数据
                        bytes(i) = strIncoming
                    Next
                    ' SerialPort1.Write(sendbox.Text)'发送数据
                    'SerialPort1.DiscardInBuffer()
                    str1 = Split(BitConverter.ToString(bytes), "-")

                    ReDim str2(str1.Length - 1) '去除str1中最后的字符
                    For i = 0 To str1.Length - 2
                        str2(i) = str1(i)
                    Next
                    TextBox_rev.AppendText(Join(str2, " "))
                    'BitConverter.ToString(bytes)
                Else
                    For i = 1 To cnt
                        TextBox_rev.AppendText(Chr(SerialPort.ReadChar()))

                    Next
                End If
                TextBox_rev.ScrollToCaret()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Timer_autoenter.Enabled = True
    End Sub

    Private Sub Button_cleanrev_Click(sender As Object, e As EventArgs) Handles Button_cleanrev.Click
        TextBox_rev.Text = ""
    End Sub

    Private Sub Button_cleansend_Click(sender As Object, e As EventArgs) Handles Button_cleansend.Click
        TextBox_send.Text = ""
    End Sub

    Private Sub Label_revcnt_DoubleClick(sender As Object, e As EventArgs) Handles Label_revcnt.DoubleClick
        Label_revcnt.Text = "0"
    End Sub

    Private Sub Label_sendcnt_DoubleClick(sender As Object, e As EventArgs) Handles Label_sendcnt.DoubleClick
        Label_sendcnt.Text = "0"
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer_autoenter.Tick
        Timer_autoenter.Enabled = False
        If CheckBox_autoenter.Checked Then
            TextBox_rev.AppendText(vbCrLf)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_autoenter.CheckedChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button_autosend.Click
        If Timer_autosend.Enabled Then
            Timer_autosend.Enabled = False
            Button_autosend.Text = "打开自动发送"
        Else
            Timer_autosend.Enabled = True
            Button_autosend.Text = "关闭自动发送"
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer_autosend.Tick
        SerialSend()
    End Sub

    Private Sub TextBox_period_TextChanged(sender As Object, e As EventArgs) Handles TextBox_period.TextChanged
        If IsNumeric(TextBox_period.Text) Then
            If Val(TextBox_period.Text) > 0 Then
                Timer_autosend.Interval = Val(TextBox_period.Text)
            End If
        Else
                Timer_autosend.Interval = 1000
        End If
    End Sub

    Private Sub Com_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        saveset()
    End Sub
    Private Sub saveset()
        Dim SetFile As New IO.FileStream(".\set.ini", FileMode.OpenOrCreate, FileAccess.Write)
        Dim s As New StreamWriter(SetFile)
        s.WriteLine(ComboBox_com.Text)
        s.WriteLine(ComboBox_rate.Text)
        s.WriteLine(ComboBox_parity.Text)
        s.WriteLine(ComboBox_databits.Text)
        s.WriteLine(ComboBox_stopbits.Text)
        s.WriteLine(TextBox_period.Text)
        s.WriteLine(TextBox_send.Text)
        s.WriteLine(CheckBox_autoenter.CheckState)
        s.WriteLine(CheckBox_revhex.CheckState)
        s.WriteLine(CheckBox_sendhex.CheckState)
        s.Close()
    End Sub
    Private Sub loadset()
        Dim SetFile As IO.FileStream
        Dim s As StreamReader
        Try
            SetFile = New IO.FileStream(".\set.ini", FileMode.Open, FileAccess.Read)
            s = New StreamReader(SetFile)
            ComboBox_com.Text = s.ReadLine()
            ComboBox_rate.Text = s.ReadLine()
            ComboBox_parity.Text = s.ReadLine()
            ComboBox_databits.Text = s.ReadLine()
            ComboBox_stopbits.Text = s.ReadLine()
            TextBox_period.Text = s.ReadLine()
            TextBox_send.Text = s.ReadLine()
            CheckBox_autoenter.CheckState = s.ReadLine()
            CheckBox_revhex.CheckState = s.ReadLine()
            CheckBox_sendhex.CheckState = s.ReadLine()
            s.Close()
        Catch

        End Try
    End Sub

    Private Sub com_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Dim dh As Integer
        dh = Size.Height - 302
        If Me.Size.Width > 424 Then
            Me.Size = New Size(424, Size.Height)
        End If
        TextBox_rev.Size = New Size(335, 85 + dh)
        Button_cleansend.Location = New Point(Button_cleansend.Location.X, 201 + dh)
        CheckBox_sendhex.Location = New Point(CheckBox_sendhex.Location.X, 235 + dh)
        Label_send.Location = New Point(Label_send.Location.X, 186 + dh)
        Label_sendcnt.Location = New Point(Label_sendcnt.Location.X, 186 + dh)
        Label6.Location = New Point(Label6.Location.X, 186 + dh)
        TextBox_period.Location = New Point(TextBox_period.Location.X, 183 + dh)
        TextBox_send.Location = New Point(TextBox_send.Location.X, 201 + dh)
        Button_autosend.Location = New Point(Button_autosend.Location.X, 201 + dh)
        Button_send.Location = New Point(Button_send.Location.X, 225 + dh)
    End Sub
End Class


