﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Road
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
        Me.components = New System.ComponentModel.Container()
        Me.FPSLabel = New System.Windows.Forms.Label()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.StopButton = New System.Windows.Forms.Button()
        Me.AnimationTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ThinkTimer = New System.Windows.Forms.Timer(Me.components)
        Me.PanScrollBar = New System.Windows.Forms.HScrollBar()
        Me.RefLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LanesUpDown = New System.Windows.Forms.NumericUpDown()
        CType(Me.LanesUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FPSLabel
        '
        Me.FPSLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FPSLabel.AutoSize = True
        Me.FPSLabel.Location = New System.Drawing.Point(1233, 13)
        Me.FPSLabel.Name = "FPSLabel"
        Me.FPSLabel.Size = New System.Drawing.Size(27, 13)
        Me.FPSLabel.TabIndex = 0
        Me.FPSLabel.Text = "FPS"
        '
        'StartButton
        '
        Me.StartButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StartButton.Location = New System.Drawing.Point(13, 226)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 1
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'StopButton
        '
        Me.StopButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StopButton.Location = New System.Drawing.Point(95, 226)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(75, 23)
        Me.StopButton.TabIndex = 2
        Me.StopButton.Text = "Stop"
        Me.StopButton.UseVisualStyleBackColor = True
        '
        'AnimationTimer
        '
        '
        'PanScrollBar
        '
        Me.PanScrollBar.Location = New System.Drawing.Point(319, 229)
        Me.PanScrollBar.Name = "PanScrollBar"
        Me.PanScrollBar.Size = New System.Drawing.Size(956, 18)
        Me.PanScrollBar.SmallChange = 10
        Me.PanScrollBar.TabIndex = 3
        '
        'RefLabel
        '
        Me.RefLabel.AutoSize = True
        Me.RefLabel.Location = New System.Drawing.Point(177, 235)
        Me.RefLabel.Name = "RefLabel"
        Me.RefLabel.Size = New System.Drawing.Size(39, 13)
        Me.RefLabel.TabIndex = 4
        Me.RefLabel.Text = "Label1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(223, 234)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Lanes"
        '
        'LanesUpDown
        '
        Me.LanesUpDown.Location = New System.Drawing.Point(266, 229)
        Me.LanesUpDown.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.LanesUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.LanesUpDown.Name = "LanesUpDown"
        Me.LanesUpDown.Size = New System.Drawing.Size(35, 20)
        Me.LanesUpDown.TabIndex = 6
        Me.LanesUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Road
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 261)
        Me.Controls.Add(Me.LanesUpDown)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RefLabel)
        Me.Controls.Add(Me.PanScrollBar)
        Me.Controls.Add(Me.StopButton)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.FPSLabel)
        Me.Name = "Road"
        Me.Text = "Cars and Trucks"
        CType(Me.LanesUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FPSLabel As Label
    Friend WithEvents StartButton As Button
    Friend WithEvents StopButton As Button
    Friend WithEvents AnimationTimer As Timer
    Friend WithEvents ThinkTimer As Timer
    Friend WithEvents PanScrollBar As HScrollBar
    Friend WithEvents RefLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LanesUpDown As NumericUpDown
End Class
