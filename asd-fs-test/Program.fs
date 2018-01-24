namespace test

module Program = 
    [<EntryPoint>]
    let main argv = 
        ignore (asd.Engine.Initialize ("test", 640, 480, new asd.EngineOption ()))

        let scene = new Game ()
        asd.Engine.ChangeScene scene

        let rec loop () =
            if Global.KeyPushed asd.Keys.Escape then ()
            elif asd.Engine.DoEvents () then
                asd.Engine.Update ()
                loop ()
        loop ()

        asd.Engine.Terminate ()
        0    