namespace test

module Global =
    let KeyPush key =
        asd.Engine.Keyboard.GetKeyState key = asd.KeyState.Push
    
    let KeyHold key =
        asd.Engine.Keyboard.GetKeyState key = asd.KeyState.Hold
    
    let KeyRelease key =
        asd.Engine.Keyboard.GetKeyState key = asd.KeyState.Release
    
    let KeyFree key =
        asd.Engine.Keyboard.GetKeyState key = asd.KeyState.Free