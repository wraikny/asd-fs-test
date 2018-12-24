namespace test

type Game() =
    inherit asd.Scene()

    let player = new Player ()
    let layer = new asd.Layer2D ()
    let mutable hoge = 0

    member this.Hoge
        with get() = hoge
        and set(value) = hoge <- value

    override this.OnRegistered () =
        this.AddLayer layer
        layer.AddObject player

        layer.AddObject {
            new asd.GeometryObject2D(
                Shape = new asd.RectangleShape(
                        DrawingArea = 
                            let size = new asd.Vector2DF (50.0f, 50.0f) in
                            new asd.RectF(-size / 2.0f, size)
                    )
            ) with
                member x.OnAdded() =
                    printfn "Hello World"
                member x.OnUpdate() =
                    x.Position <- asd.Engine.Mouse.Position

            interface System.IDisposable with 
                member x.Dispose() = printfn "Dispose"
        }
