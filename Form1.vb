Public Class Form1

    Dim ShapeList As New List(Of Shape)

    Dim WithEvents Time As New Timer

    Dim Window As New PictureBox

    Dim g As VectorGraphics

    '-------CUSTOM CONTROLS---------

    Dim RX, RY, RZ As CustomControls.ScrollControl


    '-------------------------------

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AllInits()

        ShapeList.Add(TestShape1())
        ShapeList.Add(TestShape2())

    End Sub

    Function TestShape1() As Shape

        Dim AShapeVert() As Vector

        ReDim AShapeVert(7)
        AShapeVert(0) = New Vector(-40, -40, -40)
        AShapeVert(1) = New Vector(40, -40, -40)
        AShapeVert(2) = New Vector(40, 40, -40)
        AShapeVert(3) = New Vector(-40, 40, -40)
        AShapeVert(4) = New Vector(-40, -40, 40)
        AShapeVert(5) = New Vector(40, -40, 40)
        AShapeVert(6) = New Vector(40, 40, 40)
        AShapeVert(7) = New Vector(-40, 40, 40)

        Return New Shape(ShapeType.Cuboid,
                         New Vector(Window.Width - 100, Window.Height - 100, 0), 'MAKE Z VALUE EFFECT
                         AShapeVert)
    End Function

    Function TestShape2() As Shape

        Dim AShapeVert() As Vector

        ReDim AShapeVert(4)
        AShapeVert(0) = New Vector(0, -40, 0)
        AShapeVert(1) = New Vector(-40, 40, -40)
        AShapeVert(2) = New Vector(40, 40, -40)
        AShapeVert(3) = New Vector(-40, 40, 40)
        AShapeVert(4) = New Vector(40, 40, 40)

        Return New Shape(ShapeType.BasedPrism,
                         New Vector(100, 100, 0), 'MAKE Z VALUE EFFECT
                         AShapeVert)

    End Function
    Private Sub Time_Tick(sender As Object, e As EventArgs) Handles Time.Tick

        UpdateWindow()
        UpdateShapes()

    End Sub

    Sub UpdateWindow()
        Window.Image = g.GetCanvas(ShapeList)
    End Sub

    Sub UpdateShapes()
        For Each S In ShapeList
            RotateShape(S)
            UpdateShapeAngle(S)
        Next
    End Sub
    Function RotateShape(S As Shape)
        For Each V In S.CurrentState
            S.Rotate(V)
        Next
        Return S
    End Function

    Function UpdateShapeAngle(S As Shape)
        S.anglex += RX.S.Value / 100
        S.angley += RY.S.Value / 100
        S.anglez += RZ.S.Value / 100
        Return S
    End Function

    '--------------INITS----------------
    Sub AllInits()

        FormInit()
        WindowInit()
        GraphicsInit()
        CustomControlsInit()
        TimeInit()

    End Sub
    Sub FormInit()
        Me.MaximizeBox = False
        Me.Text = "3D Engine - S.C"
        Me.BackColor = Color.Black
        Me.Size = New Size(700, 400)
        Me.CenterToScreen()
    End Sub
    Sub WindowInit()
        Window.BorderStyle = BorderStyle.Fixed3D
        Window.Size = New Size(450, Me.ClientSize.Height)
        Window.Location = New Point(0, 0)
        Window.BackColor = Me.BackColor
        Me.Controls.Add(Window)
    End Sub
    Sub GraphicsInit()
        g = New VectorGraphics(Window.Width, Window.Height)
    End Sub
    Sub CustomControlsInit()
        RX = New CustomControls.ScrollControl(Me.ClientSize.Width - 120, 20, 0, "Rotate in X: ")
        RY = New CustomControls.ScrollControl(Me.ClientSize.Width - 120, 60, 0, "Rotate in Y: ")
        RZ = New CustomControls.ScrollControl(Me.ClientSize.Width - 120, 100, 0, "Rotate in Z: ")
        Window.Select()
    End Sub
    Sub TimeInit()
        Time.Interval = 40
        Time.Start()
    End Sub
    '---------------------------------

End Class
