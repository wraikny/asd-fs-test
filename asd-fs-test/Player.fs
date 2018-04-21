namespace test

open Global

type Player() as this = 
    inherit asd.GeometryObject2D()

    let speed = 4.0f
    let size = new asd.Vector2DF (50.0f, 50.0f)

    do
        this.Shape <-
            let da = new asd.RectF(-size / 2.0f, size)
            new asd.RectangleShape(DrawingArea=da)
        this.Color <- new asd.Color(255uy, 255uy, 255uy)
        this.Position <- 0.5f * asd.Engine.WindowSize.To2DF()

    override this.OnUpdate () =
        this.Move ()
        this.ClampPos ()

    member private this.UpdatePos (dx, dy) =
        this.Position <- new asd.Vector2DF(dx, dy) + this.Position

    member private this.ClampPos () =
        let p = this.Position
        let w = asd.Engine.WindowSize.To2DF()
        let d = size / 2.0f

        let x = asd.MathHelper.Clamp(p.X, w.X - d.X, d.X)
        let y = asd.MathHelper.Clamp(p.Y, w.Y - d.Y, d.Y)

        this.Position <- new asd.Vector2DF(x, y)

    member this.Move () =
        let xy = 
            let b2f b = if b then 1.0f else 0.0f
            let sp f l = (b2f(KeyHold f) - b2f(KeyHold l)) * speed

            (sp asd.Keys.Right asd.Keys.Left), (sp asd.Keys.Down asd.Keys.Up)
        
        this.UpdatePos xy