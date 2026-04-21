Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Atalasoft.Imaging.ImageProcessing

Namespace CompositeCommandDemo
	''' <summary>
	''' Summary description for EditCommand.
	''' </summary>
	Public Class EditCommand
		Inherits System.Windows.Forms.Form
		Private propertyGrid1 As System.Windows.Forms.PropertyGrid
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New(ByVal command As ImageCommand)
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			'
			' TODO: Add any constructor code after InitializeComponent call
			'

			propertyGrid1.SelectedObject = command
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
			Me.propertyGrid1 = New System.Windows.Forms.PropertyGrid()
			Me.SuspendLayout()
			' 
			' propertyGrid1
			' 
			Me.propertyGrid1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.propertyGrid1.CommandsVisibleIfAvailable = True
			Me.propertyGrid1.LargeButtons = False
			Me.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar
			Me.propertyGrid1.Location = New System.Drawing.Point(0, 0)
			Me.propertyGrid1.Name = "propertyGrid1"
			Me.propertyGrid1.Size = New System.Drawing.Size(384, 272)
			Me.propertyGrid1.TabIndex = 0
			Me.propertyGrid1.Text = "propertyGrid1"
			Me.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window
			Me.propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText
			' 
			' EditCommand
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(384, 266)
			Me.Controls.Add(Me.propertyGrid1)
			Me.Name = "EditCommand"
			Me.Text = "Edit Command"
			Me.ResumeLayout(False)

		End Sub
		#End Region
	End Class
End Namespace
