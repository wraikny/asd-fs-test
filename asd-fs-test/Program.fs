namespace test

open Global

module Program = 
    [<EntryPoint>]
    let main(argv) = 
        asd.Engine.Initialize ("test", 640, 480, new asd.EngineOption())
            |> ignore
        
        let scene = new asd.Scene()

        asd.Engine.ChangeScene(scene)

        let rec loop () =
            if KeyPush asd.Keys.Escape then ()
            elif asd.Engine.DoEvents() then
                asd.Engine.Update()
                loop ()
        loop ()
        
        asd.Engine.Terminate()
        0