﻿namespace test

[<Class>]
type PostEffectTest() =
    inherit asd.PostEffect()

    let shader2d_dx_ps = @"
Texture2D g_texture : register( t0 );
SamplerState g_sampler : register( s0 );

struct PS_Input
{
    float4 SV_Position : SV_POSITION;
    float4 Position : POSITION;
    float2 UV : UV;
    float4 Color : COLOR;
};

float4 main( const PS_Input Input ) : SV_Target
{
    // float4 color = g_texture.Sample(g_sampler, Input.UV);
    return float4( Input.Position.xy, 0.0, 1.0);
}

"

    let shader2d_gl_ps = @"
uniform sampler2D g_texture;

in vec4 inPosition;
in vec2 inUV;
in vec4 inColor;

out vec4 outOutput;

void main()
{
    vec4 color = texture(g_texture, inUV.xy);
    outOutput = vec4( inPosition.xy - (inUV.xy * 2.0 + vec2(1.0, 1.0)), 0.0, 1.0 );
}
"

    let shader =
        let code =
            asd.Engine.Graphics.GraphicsDeviceType |> function
            | asd.GraphicsDeviceType.DirectX11 ->
                shader2d_dx_ps
            | asd.GraphicsDeviceType.OpenGL ->
                shader2d_gl_ps
            | _ -> ""
        
        asd.Engine.Graphics.CreateShader2D(code)

    let material2d =
        asd.Engine.Graphics.CreateMaterial2D(shader)

    override this.OnDraw(dst, src) =
        material2d.SetTexture2D("g_texture", src)
        this.DrawOnTexture2DWithMaterial(dst, material2d)