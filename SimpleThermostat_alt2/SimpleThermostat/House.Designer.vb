<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class House
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AmbientUpDown = New System.Windows.Forms.NumericUpDown()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.SetPointLabel = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TimeUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.AirButton = New System.Windows.Forms.RadioButton()
        Me.HeatButton = New System.Windows.Forms.RadioButton()
        CType(Me.AmbientUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ambient"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(79, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Set Point"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(152, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Status"
        '
        'AmbientUpDown
        '
        Me.AmbientUpDown.Location = New System.Drawing.Point(12, 29)
        Me.AmbientUpDown.Name = "AmbientUpDown"
        Me.AmbientUpDown.Size = New System.Drawing.Size(46, 20)
        Me.AmbientUpDown.TabIndex = 3
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.BackColor = System.Drawing.Color.White
        Me.StatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.StatusLabel.Location = New System.Drawing.Point(146, 31)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(58, 15)
        Me.StatusLabel.TabIndex = 5
        Me.StatusLabel.Text = "Undefined"
        '
        'SetPointLabel
        '
        Me.SetPointLabel.AutoSize = True
        Me.SetPointLabel.BackColor = System.Drawing.Color.White
        Me.SetPointLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SetPointLabel.Location = New System.Drawing.Point(82, 31)
        Me.SetPointLabel.Name = "SetPointLabel"
        Me.SetPointLabel.Size = New System.Drawing.Size(45, 15)
        Me.SetPointLabel.TabIndex = 6
        Me.SetPointLabel.Text = "Not Set"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Time"
        '
        'TimeUpDown
        '
        Me.TimeUpDown.Location = New System.Drawing.Point(12, 73)
        Me.TimeUpDown.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.TimeUpDown.Name = "TimeUpDown"
        Me.TimeUpDown.Size = New System.Drawing.Size(46, 20)
        Me.TimeUpDown.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Mode"
        '
        'AirButton
        '
        Me.AirButton.AutoSize = True
        Me.AirButton.Location = New System.Drawing.Point(12, 132)
        Me.AirButton.Name = "AirButton"
        Me.AirButton.Size = New System.Drawing.Size(37, 17)
        Me.AirButton.TabIndex = 10
        Me.AirButton.Text = "Air"
        Me.AirButton.UseVisualStyleBackColor = True
        '
        'HeatButton
        '
        Me.HeatButton.AutoSize = True
        Me.HeatButton.Checked = True
        Me.HeatButton.Location = New System.Drawing.Point(12, 156)
        Me.HeatButton.Name = "HeatButton"
        Me.HeatButton.Size = New System.Drawing.Size(48, 17)
        Me.HeatButton.TabIndex = 11
        Me.HeatButton.TabStop = True
        Me.HeatButton.Text = "Heat"
        Me.HeatButton.UseVisualStyleBackColor = True
        '
        'House
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 240)
        Me.Controls.Add(Me.HeatButton)
        Me.Controls.Add(Me.AirButton)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TimeUpDown)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.SetPointLabel)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.AmbientUpDown)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "House"
        Me.Text = "House Simulator"
        CType(Me.AmbientUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents AmbientUpDown As NumericUpDown
    Friend WithEvents StatusLabel As Label
    Friend WithEvents SetPointLabel As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TimeUpDown As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents AirButton As RadioButton
    Friend WithEvents HeatButton As RadioButton
End Class
