namespace test

type Game =
    inherit asd.Scene

    val private layer : asd.Layer2D
    val private player : Player


    override this.OnRegistered () =
        base.OnRegistered ()
        this.AddLayer this.layer
        this.layer.AddObject this.player
    
    
    override this.OnUpdated () =
        base.OnUpdated ()
    
    
    new () = { inherit asd.Scene ()
               player = new Player ()
               layer = new asd.Layer2D () }