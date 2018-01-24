namespace test

type Player = 
    inherit asd.GeometryObject2D

    val private speed : float32
    val private size : asd.Vector2DF

    member private this.UpdatePosition (dx, dy : float32) : unit =
        this.Position <- new asd.Vector2DF (this.Position.X + dx, this.Position.Y + dy)
    
    member private this.ClampPosition () =
        let pos = this.Position
        let win = asd.Engine.WindowSize.To2DF ()
        let x = asd.MathHelper.Clamp (pos.X, win.X - this.size.X / 2.0f, this.size.X / 2.0f)
        let y = asd.MathHelper.Clamp (pos.Y, win.Y - this.size.Y / 2.0f, this.size.Y / 2.0f)
        this.Position <- new asd.Vector2DF (x, y)
    
    member this.Move () : unit =
        if Global.KeyHold asd.Keys.Up then
            this.UpdatePosition (0.0f, -this.speed)
        
        if Global.KeyHold asd.Keys.Down then
            this.UpdatePosition (0.0f, this.speed)
        
        if Global.KeyHold asd.Keys.Right then
            this.UpdatePosition (this.speed, 0.0f)
        
        if Global.KeyHold asd.Keys.Left then
            this.UpdatePosition (-this.speed, 0.0f)
        
        this.ClampPosition ()
    
    override this.OnUpdate () =
        base.OnUpdate ()
        this.Move ()
    
    new () as this = { inherit asd.GeometryObject2D () 
                       speed = 5.0f 
                       size = new asd.Vector2DF (50.0f, 50.0f) } then
        let rect = new asd.RectangleShape ()
        rect.DrawingArea <- new asd.RectF (-this.size / 2.0f, this.size)
        this.Shape <- rect
        this.Color <- new asd.Color(255uy, 255uy, 255uy)
        this.Position <- (asd.Engine.WindowSize.To2DF ()) / 2.0f
