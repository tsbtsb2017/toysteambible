<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class TSB_Generator
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents cmdUpload As System.Windows.Forms.Button
	Public WithEvents cmdShow2 As System.Windows.Forms.Button
	Public WithEvents cmdShow As System.Windows.Forms.Button
	Public WithEvents cmdBuildManufacturerPage As System.Windows.Forms.Button
	Public WithEvents cmdLoad As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdUpload = New System.Windows.Forms.Button
        Me.cmdShow2 = New System.Windows.Forms.Button
        Me.cmdShow = New System.Windows.Forms.Button
        Me.cmdBuildManufacturerPage = New System.Windows.Forms.Button
        Me.cmdLoad = New System.Windows.Forms.Button
        Me.lblUp1 = New System.Windows.Forms.Label
        Me.lblUp2 = New System.Windows.Forms.Label
        Me.cmdValidate = New System.Windows.Forms.Button
        Me.lblValidation = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdUpload
        '
        Me.cmdUpload.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUpload.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUpload.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUpload.Location = New System.Drawing.Point(8, 152)
        Me.cmdUpload.Name = "cmdUpload"
        Me.cmdUpload.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUpload.Size = New System.Drawing.Size(125, 29)
        Me.cmdUpload.TabIndex = 4
        Me.cmdUpload.Text = "Upload"
        Me.cmdUpload.UseVisualStyleBackColor = False
        '
        'cmdShow2
        '
        Me.cmdShow2.BackColor = System.Drawing.SystemColors.Control
        Me.cmdShow2.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdShow2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdShow2.Location = New System.Drawing.Point(8, 116)
        Me.cmdShow2.Name = "cmdShow2"
        Me.cmdShow2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdShow2.Size = New System.Drawing.Size(125, 29)
        Me.cmdShow2.TabIndex = 3
        Me.cmdShow2.Text = "Show Website (Web)"
        Me.cmdShow2.UseVisualStyleBackColor = False
        '
        'cmdShow
        '
        Me.cmdShow.BackColor = System.Drawing.SystemColors.Control
        Me.cmdShow.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdShow.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdShow.Location = New System.Drawing.Point(8, 80)
        Me.cmdShow.Name = "cmdShow"
        Me.cmdShow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdShow.Size = New System.Drawing.Size(125, 29)
        Me.cmdShow.TabIndex = 2
        Me.cmdShow.Text = "Show Website (Local)"
        Me.cmdShow.UseVisualStyleBackColor = False
        '
        'cmdBuildManufacturerPage
        '
        Me.cmdBuildManufacturerPage.BackColor = System.Drawing.SystemColors.Control
        Me.cmdBuildManufacturerPage.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdBuildManufacturerPage.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdBuildManufacturerPage.Location = New System.Drawing.Point(8, 44)
        Me.cmdBuildManufacturerPage.Name = "cmdBuildManufacturerPage"
        Me.cmdBuildManufacturerPage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdBuildManufacturerPage.Size = New System.Drawing.Size(125, 29)
        Me.cmdBuildManufacturerPage.TabIndex = 1
        Me.cmdBuildManufacturerPage.Text = "Build Pages"
        Me.cmdBuildManufacturerPage.UseVisualStyleBackColor = False
        '
        'cmdLoad
        '
        Me.cmdLoad.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLoad.Location = New System.Drawing.Point(8, 8)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLoad.Size = New System.Drawing.Size(125, 29)
        Me.cmdLoad.TabIndex = 0
        Me.cmdLoad.Text = "Load Database"
        Me.cmdLoad.UseVisualStyleBackColor = False
        '
        'lblUp1
        '
        Me.lblUp1.AutoSize = True
        Me.lblUp1.Location = New System.Drawing.Point(12, 184)
        Me.lblUp1.Name = "lblUp1"
        Me.lblUp1.Size = New System.Drawing.Size(93, 13)
        Me.lblUp1.TabIndex = 6
        Me.lblUp1.Text = "Pages Processed:"
        '
        'lblUp2
        '
        Me.lblUp2.AutoSize = True
        Me.lblUp2.Location = New System.Drawing.Point(12, 203)
        Me.lblUp2.Name = "lblUp2"
        Me.lblUp2.Size = New System.Drawing.Size(84, 13)
        Me.lblUp2.TabIndex = 7
        Me.lblUp2.Text = "Pages Updated:"
        '
        'cmdValidate
        '
        Me.cmdValidate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdValidate.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdValidate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdValidate.Location = New System.Drawing.Point(156, 8)
        Me.cmdValidate.Name = "cmdValidate"
        Me.cmdValidate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdValidate.Size = New System.Drawing.Size(125, 29)
        Me.cmdValidate.TabIndex = 8
        Me.cmdValidate.Text = "Validate"
        Me.cmdValidate.UseVisualStyleBackColor = False
        '
        'lblValidation
        '
        Me.lblValidation.Location = New System.Drawing.Point(153, 52)
        Me.lblValidation.Name = "lblValidation"
        Me.lblValidation.Size = New System.Drawing.Size(128, 129)
        Me.lblValidation.TabIndex = 9
        Me.lblValidation.Text = "Validation Result:"
        '
        'TSB_Generator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(291, 227)
        Me.Controls.Add(Me.lblValidation)
        Me.Controls.Add(Me.cmdValidate)
        Me.Controls.Add(Me.lblUp2)
        Me.Controls.Add(Me.lblUp1)
        Me.Controls.Add(Me.cmdUpload)
        Me.Controls.Add(Me.cmdShow2)
        Me.Controls.Add(Me.cmdShow)
        Me.Controls.Add(Me.cmdBuildManufacturerPage)
        Me.Controls.Add(Me.cmdLoad)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TSB_Generator"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "TSB"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblUp1 As System.Windows.Forms.Label
    Friend WithEvents lblUp2 As System.Windows.Forms.Label
    Public WithEvents cmdValidate As System.Windows.Forms.Button
    Friend WithEvents lblValidation As System.Windows.Forms.Label
#End Region 
End Class