Public Class VectorGraphics

    Public Canvas As Bitmap
    Public W, H As Integer

    Const NodeSize As Integer = 15

    Sub New(Width As Integer, Height As Integer)
        W = Width
        H = Height
        Canvas = New Bitmap(W, H)
    End Sub
    Public Function GetCanvas(ShapeList As List(Of Shape)) As Bitmap

        For Each Shape In ShapeList

            Dim Nodes() As Vector = Shape.CurrentState()

            Select Case Shape.Type

                Case ShapeType.Cuboid
                    For i = 0 To 3
                        Connect(i, (i + 1) Mod 4, Nodes, Shape.Centre, Pens.White)
                        Connect(i + 4, ((i + 1) Mod 4) + 4, Nodes, Shape.Centre, Pens.White)
                        Connect(i, i + 4, Nodes, Shape.Centre, Pens.White)
                    Next
                Case ShapeType.BasedPrism
                    For i = 0 To 3
                        Connect(0, i + 1, Nodes, Shape.Centre, Pens.White)
                    Next
                    Connect(1, 2, Nodes, Shape.Centre, Pens.White)
                    Connect(2, 4, Nodes, Shape.Centre, Pens.White)
                    Connect(1, 3, Nodes, Shape.Centre, Pens.White)
                    Connect(4, 3, Nodes, Shape.Centre, Pens.White)

            End Select

            DrawCorners(Nodes, Shape.Centre)

        Next

        Dim Copy As Bitmap = Canvas
        Canvas = New Bitmap(W, H)
        Return Copy
    End Function

    Private Sub DrawCorners(NodeList() As Vector, ShapeCentre As Vector)

        For Each V As Vector In NodeList
            Using g As Graphics = Graphics.FromImage(Canvas)
                g.FillEllipse(Brushes.White,
                              CSng(ShapeCentre.x + V.x - (NodeSize / 2)),  'work with centre
                              CSng(ShapeCentre.y + V.y - (NodeSize / 2)),
                              NodeSize, NodeSize)
            End Using
        Next

    End Sub

    Private Sub Connect(i As Integer,
                        j As Integer,
                        pr() As Vector,
                        ShapeCentre As Vector,
                        P As Pen)

        Dim a As Vector = pr(i)
        Dim b As Vector = pr(j)
        Using g As Graphics = Graphics.FromImage(Canvas)
            g.DrawLine(P,
                       (a.x + ShapeCentre.x),
                        a.y + ShapeCentre.y,
                        b.x + ShapeCentre.x,
                        b.y + ShapeCentre.y)
        End Using
    End Sub

End Class
