namespace test

type Scene() =
    inherit asd.Scene()
    let mutable i = 0
    let mutable s = "hello"
    override this.OnUpdated() =
        if asd.Engine.Tool.Begin "input" then
            asd.Engine.Tool.Text "hoge"

            let i_ = [|i|]
            if asd.Engine.Tool.InputInt("int", i_) then
                i <- i_.[0]

            asd.Engine.Tool.Text <| "i: " + string i

            let buf_size = 10
            let n = Seq.length s
            let s_ : sbyte [] =
                Array.append (s |> Seq.map sbyte |> Seq.toArray) [|0y|]

            if asd.Engine.Tool.InputText("text", s_, 2 * n + buf_size - 10) then
                let s_ = s_ |> Array.map byte
                s <- System.Text.Encoding.ASCII.GetString (s_, 0, s_ |> Seq.length)

            asd.Engine.Tool.Text <| "s: " + s

            asd.Engine.Tool.End()


module Program = 
    [<EntryPoint>]
    let main _ = 
        asd.Engine.Initialize("test", 640, 480, new asd.EngineOption())
            |> ignore

        // asd.Engine.OpenTool()

        // let scene = new Scene()

        let scene = new asd.Scene()
        let layer = new asd.Layer2D()
        scene.AddLayer(layer)
        layer.AddPostEffect(new PostEffectTest());

        asd.Engine.ChangeScene(scene)

        let rec loop () =
            if asd.Engine.DoEvents() then
                asd.Engine.Update()
                loop ()
        loop ()

        // asd.Engine.CloseTool()
        asd.Engine.Terminate()
        0

