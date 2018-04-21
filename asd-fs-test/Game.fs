namespace test

type Game() =
    inherit asd.Scene()

    let player = new Player ()
    let layer = new asd.Layer2D ()

    override this.OnRegistered () =
        this.AddLayer layer
        layer.AddObject player
    