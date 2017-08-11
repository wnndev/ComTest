<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class com
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(com))
        Me.TextBox_rev = New System.Windows.Forms.TextBox()
        Me.TextBox_send = New System.Windows.Forms.TextBox()
        Me.Button_send = New System.Windows.Forms.Button()
        Me.Label_rev = New System.Windows.Forms.Label()
        Me.Label_send = New System.Windows.Forms.Label()
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.Button_cleanrev = New System.Windows.Forms.Button()
        Me.Button_cleansend = New System.Windows.Forms.Button()
        Me.CheckBox_sendhex = New System.Windows.Forms.CheckBox()
        Me.CheckBox_revhex = New System.Windows.Forms.CheckBox()
        Me.ComboBox_com = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox_rate = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button_open = New System.Windows.Forms.Button()
        Me.Label_comstate = New System.Windows.Forms.Label()
        Me.Label_revcnt = New System.Windows.Forms.Label()
        Me.Label_sendcnt = New System.Windows.Forms.Label()
        Me.Timer_refresh = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox_databits = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox_stopbits = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox_parity = New System.Windows.Forms.ComboBox()
        Me.Timer_autoenter = New System.Windows.Forms.Timer(Me.components)
        Me.CheckBox_autoenter = New System.Windows.Forms.CheckBox()
        Me.Button_autosend = New System.Windows.Forms.Button()
        Me.Timer_autosend = New System.Windows.Forms.Timer(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox_period = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TextBox_rev
        '
        resources.ApplyResources(Me.TextBox_rev, "TextBox_rev")
        Me.TextBox_rev.Name = "TextBox_rev"
        '
        'TextBox_send
        '
        resources.ApplyResources(Me.TextBox_send, "TextBox_send")
        Me.TextBox_send.Name = "TextBox_send"
        '
        'Button_send
        '
        resources.ApplyResources(Me.Button_send, "Button_send")
        Me.Button_send.Name = "Button_send"
        Me.Button_send.UseVisualStyleBackColor = True
        '
        'Label_rev
        '
        resources.ApplyResources(Me.Label_rev, "Label_rev")
        Me.Label_rev.Name = "Label_rev"
        '
        'Label_send
        '
        resources.ApplyResources(Me.Label_send, "Label_send")
        Me.Label_send.Name = "Label_send"
        '
        'SerialPort
        '
        '
        'Button_cleanrev
        '
        resources.ApplyResources(Me.Button_cleanrev, "Button_cleanrev")
        Me.Button_cleanrev.Name = "Button_cleanrev"
        Me.Button_cleanrev.UseVisualStyleBackColor = True
        '
        'Button_cleansend
        '
        resources.ApplyResources(Me.Button_cleansend, "Button_cleansend")
        Me.Button_cleansend.Name = "Button_cleansend"
        Me.Button_cleansend.UseVisualStyleBackColor = True
        '
        'CheckBox_sendhex
        '
        resources.ApplyResources(Me.CheckBox_sendhex, "CheckBox_sendhex")
        Me.CheckBox_sendhex.Name = "CheckBox_sendhex"
        Me.CheckBox_sendhex.UseVisualStyleBackColor = True
        '
        'CheckBox_revhex
        '
        resources.ApplyResources(Me.CheckBox_revhex, "CheckBox_revhex")
        Me.CheckBox_revhex.Name = "CheckBox_revhex"
        Me.CheckBox_revhex.UseVisualStyleBackColor = True
        '
        'ComboBox_com
        '
        Me.ComboBox_com.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBox_com.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_com.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ComboBox_com.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBox_com, "ComboBox_com")
        Me.ComboBox_com.Name = "ComboBox_com"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'ComboBox_rate
        '
        Me.ComboBox_rate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_rate.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBox_rate, "ComboBox_rate")
        Me.ComboBox_rate.Name = "ComboBox_rate"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Button_open
        '
        resources.ApplyResources(Me.Button_open, "Button_open")
        Me.Button_open.Name = "Button_open"
        Me.Button_open.UseVisualStyleBackColor = True
        '
        'Label_comstate
        '
        resources.ApplyResources(Me.Label_comstate, "Label_comstate")
        Me.Label_comstate.Name = "Label_comstate"
        '
        'Label_revcnt
        '
        resources.ApplyResources(Me.Label_revcnt, "Label_revcnt")
        Me.Label_revcnt.Name = "Label_revcnt"
        '
        'Label_sendcnt
        '
        resources.ApplyResources(Me.Label_sendcnt, "Label_sendcnt")
        Me.Label_sendcnt.Name = "Label_sendcnt"
        '
        'Timer_refresh
        '
        Me.Timer_refresh.Interval = 500
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'ComboBox_databits
        '
        Me.ComboBox_databits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_databits.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBox_databits, "ComboBox_databits")
        Me.ComboBox_databits.Name = "ComboBox_databits"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'ComboBox_stopbits
        '
        Me.ComboBox_stopbits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_stopbits.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBox_stopbits, "ComboBox_stopbits")
        Me.ComboBox_stopbits.Name = "ComboBox_stopbits"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'ComboBox_parity
        '
        Me.ComboBox_parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_parity.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBox_parity, "ComboBox_parity")
        Me.ComboBox_parity.Name = "ComboBox_parity"
        '
        'Timer_autoenter
        '
        Me.Timer_autoenter.Interval = 500
        '
        'CheckBox_autoenter
        '
        resources.ApplyResources(Me.CheckBox_autoenter, "CheckBox_autoenter")
        Me.CheckBox_autoenter.Name = "CheckBox_autoenter"
        Me.CheckBox_autoenter.UseVisualStyleBackColor = True
        '
        'Button_autosend
        '
        resources.ApplyResources(Me.Button_autosend, "Button_autosend")
        Me.Button_autosend.Name = "Button_autosend"
        Me.Button_autosend.UseVisualStyleBackColor = True
        '
        'Timer_autosend
        '
        Me.Timer_autosend.Interval = 500
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'TextBox_period
        '
        resources.ApplyResources(Me.TextBox_period, "TextBox_period")
        Me.TextBox_period.Name = "TextBox_period"
        '
        'com
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TextBox_period)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button_autosend)
        Me.Controls.Add(Me.CheckBox_autoenter)
        Me.Controls.Add(Me.ComboBox_parity)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboBox_stopbits)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboBox_databits)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label_sendcnt)
        Me.Controls.Add(Me.Label_revcnt)
        Me.Controls.Add(Me.Label_comstate)
        Me.Controls.Add(Me.Button_open)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox_rate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox_com)
        Me.Controls.Add(Me.CheckBox_revhex)
        Me.Controls.Add(Me.CheckBox_sendhex)
        Me.Controls.Add(Me.Button_cleansend)
        Me.Controls.Add(Me.Label_send)
        Me.Controls.Add(Me.Label_rev)
        Me.Controls.Add(Me.Button_send)
        Me.Controls.Add(Me.Button_cleanrev)
        Me.Controls.Add(Me.TextBox_send)
        Me.Controls.Add(Me.TextBox_rev)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.MaximizeBox = False
        Me.Name = "com"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox_rev As TextBox
    Friend WithEvents TextBox_send As TextBox
    Friend WithEvents Button_send As Button
    Friend WithEvents Label_rev As Label
    Friend WithEvents Label_send As Label
    Friend WithEvents SerialPort As IO.Ports.SerialPort
    Friend WithEvents Button_cleanrev As Button
    Friend WithEvents Button_cleansend As Button
    Friend WithEvents CheckBox_sendhex As CheckBox
    Friend WithEvents CheckBox_revhex As CheckBox
    Friend WithEvents ComboBox_com As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox_rate As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button_open As Button
    Friend WithEvents Label_comstate As Label
    Friend WithEvents Label_revcnt As Label
    Friend WithEvents Label_sendcnt As Label
    Friend WithEvents Timer_refresh As Timer
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox_databits As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBox_stopbits As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBox_parity As ComboBox
    Friend WithEvents Timer_autoenter As Timer
    Friend WithEvents CheckBox_autoenter As CheckBox
    Friend WithEvents Button_autosend As Button
    Friend WithEvents Timer_autosend As Timer
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox_period As TextBox
End Class
