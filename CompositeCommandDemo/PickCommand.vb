Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace CompositeCommandDemo
	''' <summary>
	''' Summary description for PickCommand.
	''' </summary>
	Public Class PickCommand
		Inherits System.Windows.Forms.Form
		Private WithEvents OK As System.Windows.Forms.Button
		Private cancel As System.Windows.Forms.Button
		Private WithEvents listBox1 As System.Windows.Forms.ListBox
		Private _types As Type()
		Private selectedType_Renamed As Type = Nothing
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New(ByVal types As Type())
			_types = types
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			listBox1.Items.AddRange(_types)
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.OK = New System.Windows.Forms.Button()
			Me.cancel = New System.Windows.Forms.Button()
			Me.listBox1 = New System.Windows.Forms.ListBox()
			Me.SuspendLayout()
			' 
			' OK
			' 
			Me.OK.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.OK.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.OK.Enabled = False
			Me.OK.Location = New System.Drawing.Point(308, 520)
			Me.OK.Name = "OK"
			Me.OK.TabIndex = 0
			Me.OK.Text = "OK"
'			Me.OK.Click += New System.EventHandler(Me.OK_Click);
			' 
			' cancel
			' 
			Me.cancel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.cancel.Location = New System.Drawing.Point(204, 520)
			Me.cancel.Name = "cancel"
			Me.cancel.TabIndex = 1
			Me.cancel.Text = "Cancel"
			' 
			' listBox1
			' 
			Me.listBox1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.listBox1.Location = New System.Drawing.Point(0, 0)
			Me.listBox1.Name = "listBox1"
			Me.listBox1.Size = New System.Drawing.Size(396, 498)
			Me.listBox1.TabIndex = 2
'			Me.listBox1.DoubleClick += New System.EventHandler(Me.listBox1_DoubleClick);
'			Me.listBox1.SelectedIndexChanged += New System.EventHandler(Me.listBox1_SelectedIndexChanged);
			' 
			' PickCommand
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.CancelButton = Me.cancel
			Me.ClientSize = New System.Drawing.Size(392, 558)
			Me.Controls.Add(Me.listBox1)
			Me.Controls.Add(Me.cancel)
			Me.Controls.Add(Me.OK)
			Me.MaximizeBox = False
			Me.Name = "PickCommand"
			Me.Text = "Select Image Command"
			Me.TopMost = True
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub listBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles listBox1.SelectedIndexChanged
			OK.Enabled = listBox1.SelectedIndex <> -1
			If listBox1.SelectedIndex = -1 Then
				selectedType_Renamed = Nothing
			Else
				selectedType_Renamed = _types(listBox1.SelectedIndex)
			End If
		End Sub

		Private Sub OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OK.Click

		End Sub

		Private Sub listBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles listBox1.DoubleClick
			If listBox1.SelectedIndex <> -1 Then
				selectedType_Renamed = _types(listBox1.SelectedIndex)
				Me.DialogResult = System.Windows.Forms.DialogResult.OK
				Me.Close()
			End If
		End Sub

		Public ReadOnly Property SelectedType() As Type
			Get
				Return selectedType_Renamed
			End Get
		End Property
	End Class
End Namespace
