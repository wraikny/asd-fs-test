namespace test

open Global

type Player() as this = 
    inherit asd.GeometryObject2D(
        Color = new asd.Color(255uy, 255uy, 255uy),
        Position = 0.5f * asd.Engine.WindowSize.To2DF()
    )

    let size = new asd.Vector2DF (50.0f, 50.0f)

    do
        this.Shape <- new asd.RectangleShape(
                DrawingArea = new asd.RectF(-size / 2.0f, size)
            )

    override this.OnUpdate () =
        let x = 
            if asd.Engine.Keyboard.GetKeyState asd.Keys.Right = asd.KeyState.Hold then
                1.0f
            elif asd.Engine.Keyboard.GetKeyState asd.Keys.Left = asd.KeyState.Hold then
                -1.0f
            else
                0.0f

        let y = 
            if asd.Engine.Keyboard.GetKeyState asd.Keys.Down = asd.KeyState.Hold then
                1.0f
            elif asd.Engine.Keyboard.GetKeyState asd.Keys.Up = asd.KeyState.Hold then
                -1.0f
            else
                0.0f

        this.Position <- this.Position + new asd.Vector2DF(x, y)