namespace test

module Global =
    let KeyPushed (key : asd.Keys) : bool =
        if asd.Engine.Keyboard.GetKeyState key = asd.KeyState.Push then true
        else false
    
    let KeyHold (key : asd.Keys) : bool =
        if asd.Engine.Keyboard.GetKeyState key = asd.KeyState.Hold then true
        else false
    
    let KeyRelease (key : asd.Keys) : bool =
        if asd.Engine.Keyboard.GetKeyState key = asd.KeyState.Release then true
        else false
    
    let KeyFree (key : asd.Keys) : bool =
        if asd.Engine.Keyboard.GetKeyState key = asd.KeyState.Free then true
        else false