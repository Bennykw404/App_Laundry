<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cucian
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
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.thnhari = New System.Windows.Forms.ComboBox()
        Me.blnhari = New System.Windows.Forms.ComboBox()
        Me.tglhari = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmbket = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtfaktur = New System.Windows.Forms.TextBox()
        Me.rdkons = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtkons = New System.Windows.Forms.TextBox()
        Me.rdfaktur = New System.Windows.Forms.RadioButton()
        Me.dgcucian = New System.Windows.Forms.DataGridView()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.pnlControl = New System.Windows.Forms.Panel()
        Me.btnMinimize = New System.Windows.Forms.Button()
        Me.btnMaximize = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btcetak = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgcucian, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTop.SuspendLayout()
        Me.pnlControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(644, 438)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(167, 40)
        Me.Button3.TabIndex = 80
        Me.Button3.Text = "Tampilkan Semua Data"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(15, 399)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(624, 103)
        Me.TabControl1.TabIndex = 79
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.thnhari)
        Me.TabPage1.Controls.Add(Me.blnhari)
        Me.TabPage1.Controls.Add(Me.tglhari)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(616, 74)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Filter Harian"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(491, 21)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 28)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Filter"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'thnhari
        '
        Me.thnhari.FormattingEnabled = True
        Me.thnhari.Location = New System.Drawing.Point(381, 23)
        Me.thnhari.Margin = New System.Windows.Forms.Padding(4)
        Me.thnhari.Name = "thnhari"
        Me.thnhari.Size = New System.Drawing.Size(67, 24)
        Me.thnhari.TabIndex = 11
        '
        'blnhari
        '
        Me.blnhari.FormattingEnabled = True
        Me.blnhari.Items.AddRange(New Object() {"Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember"})
        Me.blnhari.Location = New System.Drawing.Point(197, 23)
        Me.blnhari.Margin = New System.Windows.Forms.Padding(4)
        Me.blnhari.Name = "blnhari"
        Me.blnhari.Size = New System.Drawing.Size(104, 24)
        Me.blnhari.TabIndex = 4
        '
        'tglhari
        '
        Me.tglhari.FormattingEnabled = True
        Me.tglhari.Location = New System.Drawing.Point(77, 23)
        Me.tglhari.Margin = New System.Windows.Forms.Padding(4)
        Me.tglhari.Name = "tglhari"
        Me.tglhari.Size = New System.Drawing.Size(45, 24)
        Me.tglhari.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(323, 27)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 17)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Tahun"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(144, 27)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Bulan"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 27)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tanggal"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Controls.Add(Me.cmbket)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Size = New System.Drawing.Size(616, 74)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Filter Keterangan"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(349, 21)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 28)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "Filter"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cmbket
        '
        Me.cmbket.FormattingEnabled = True
        Me.cmbket.Items.AddRange(New Object() {"Lunas", "Belum Lunas"})
        Me.cmbket.Location = New System.Drawing.Point(103, 23)
        Me.cmbket.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbket.Name = "cmbket"
        Me.cmbket.Size = New System.Drawing.Size(104, 24)
        Me.cmbket.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 27)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 17)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Keterangan"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Panel1.Controls.Add(Me.txtfaktur)
        Me.Panel1.Controls.Add(Me.rdkons)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtkons)
        Me.Panel1.Controls.Add(Me.rdfaktur)
        Me.Panel1.Location = New System.Drawing.Point(14, 47)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(922, 31)
        Me.Panel1.TabIndex = 78
        '
        'txtfaktur
        '
        Me.txtfaktur.Enabled = False
        Me.txtfaktur.Location = New System.Drawing.Point(463, 4)
        Me.txtfaktur.Margin = New System.Windows.Forms.Padding(4)
        Me.txtfaktur.Name = "txtfaktur"
        Me.txtfaktur.Size = New System.Drawing.Size(132, 22)
        Me.txtfaktur.TabIndex = 4
        '
        'rdkons
        '
        Me.rdkons.AutoSize = True
        Me.rdkons.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.rdkons.Location = New System.Drawing.Point(381, 5)
        Me.rdkons.Margin = New System.Windows.Forms.Padding(4)
        Me.rdkons.Name = "rdkons"
        Me.rdkons.Size = New System.Drawing.Size(69, 21)
        Me.rdkons.TabIndex = 1
        Me.rdkons.Text = "Faktur"
        Me.rdkons.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Cari :"
        '
        'txtkons
        '
        Me.txtkons.Location = New System.Drawing.Point(203, 2)
        Me.txtkons.Margin = New System.Windows.Forms.Padding(4)
        Me.txtkons.Name = "txtkons"
        Me.txtkons.Size = New System.Drawing.Size(132, 22)
        Me.txtkons.TabIndex = 0
        '
        'rdfaktur
        '
        Me.rdfaktur.AutoSize = True
        Me.rdfaktur.Checked = True
        Me.rdfaktur.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.rdfaktur.Location = New System.Drawing.Point(95, 4)
        Me.rdfaktur.Margin = New System.Windows.Forms.Padding(4)
        Me.rdfaktur.Name = "rdfaktur"
        Me.rdfaktur.Size = New System.Drawing.Size(96, 21)
        Me.rdfaktur.TabIndex = 8
        Me.rdfaktur.TabStop = True
        Me.rdfaktur.Text = "Konsumen"
        Me.rdfaktur.UseVisualStyleBackColor = True
        '
        'dgcucian
        '
        Me.dgcucian.AllowUserToAddRows = False
        Me.dgcucian.AllowUserToDeleteRows = False
        Me.dgcucian.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgcucian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgcucian.Location = New System.Drawing.Point(15, 81)
        Me.dgcucian.Margin = New System.Windows.Forms.Padding(4)
        Me.dgcucian.Name = "dgcucian"
        Me.dgcucian.ReadOnly = True
        Me.dgcucian.RowHeadersWidth = 51
        Me.dgcucian.Size = New System.Drawing.Size(922, 310)
        Me.dgcucian.TabIndex = 76
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.Silver
        Me.pnlTop.Controls.Add(Me.pnlControl)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(950, 41)
        Me.pnlTop.TabIndex = 77
        '
        'pnlControl
        '
        Me.pnlControl.AutoSize = True
        Me.pnlControl.Controls.Add(Me.btnMinimize)
        Me.pnlControl.Controls.Add(Me.btnMaximize)
        Me.pnlControl.Controls.Add(Me.btnClose)
        Me.pnlControl.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlControl.Location = New System.Drawing.Point(837, 0)
        Me.pnlControl.Name = "pnlControl"
        Me.pnlControl.Size = New System.Drawing.Size(113, 41)
        Me.pnlControl.TabIndex = 0
        '
        'btnMinimize
        '
        Me.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnMinimize.FlatAppearance.BorderSize = 0
        Me.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMinimize.Image = Global.App_Laundry.My.Resources.Resources.minimize15px
        Me.btnMinimize.Location = New System.Drawing.Point(44, 12)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(18, 18)
        Me.btnMinimize.TabIndex = 0
        Me.btnMinimize.UseVisualStyleBackColor = True
        '
        'btnMaximize
        '
        Me.btnMaximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnMaximize.FlatAppearance.BorderSize = 0
        Me.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMaximize.Image = Global.App_Laundry.My.Resources.Resources.maximize15px
        Me.btnMaximize.Location = New System.Drawing.Point(68, 12)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(18, 18)
        Me.btnMaximize.TabIndex = 0
        Me.btnMaximize.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = Global.App_Laundry.My.Resources.Resources.close15px
        Me.btnClose.Location = New System.Drawing.Point(92, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(18, 18)
        Me.btnClose.TabIndex = 0
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btcetak
        '
        Me.btcetak.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btcetak.Location = New System.Drawing.Point(818, 438)
        Me.btcetak.Name = "btcetak"
        Me.btcetak.Size = New System.Drawing.Size(127, 40)
        Me.btcetak.TabIndex = 1
        Me.btcetak.Text = "Cetak"
        Me.btcetak.UseVisualStyleBackColor = True
        '
        'cucian
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(950, 500)
        Me.Controls.Add(Me.btcetak)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgcucian)
        Me.Controls.Add(Me.pnlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "cucian"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "cucian"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgcucian, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlControl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button3 As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Button1 As Button
    Friend WithEvents thnhari As ComboBox
    Friend WithEvents blnhari As ComboBox
    Friend WithEvents tglhari As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Button2 As Button
    Friend WithEvents cmbket As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtfaktur As TextBox
    Friend WithEvents rdkons As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents txtkons As TextBox
    Friend WithEvents rdfaktur As RadioButton
    Friend WithEvents dgcucian As DataGridView
    Friend WithEvents pnlTop As Panel
    Friend WithEvents btcetak As Button
    Friend WithEvents pnlControl As Panel
    Friend WithEvents btnMinimize As Button
    Friend WithEvents btnMaximize As Button
    Friend WithEvents btnClose As Button
End Class
