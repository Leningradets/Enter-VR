Shader "Hologram"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _NoiseScale("Noise scale", Float) = 10
        _NoiseSpeed("Noise Speed", Float) = 0.5
        _NoiseStrenght("Noise Strenght", Float) = 0.8
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags {"Queue" = "Transparent" "RenderType"="Transparent" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows alpha

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
        };

        float _NoiseScale;
        float _NoiseSpeed;
        float _NoiseStrenght;
        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        float random(float value)
        {
            return frac(sin(value) * 2746313);
        }

        float Noise(float value, float scale)
        {
            value *= scale;
            float id = floor(value);
            float localValue = frac(value);

            float x0 = random(id);
            float x1 = random(id + 1);

            float4 smoothstep = localValue * localValue * (3 - 2 * localValue);

            return lerp(x0, x1, smoothstep);
        }


        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            float noise = lerp(1, Noise(IN.worldPos.y + _Time.y * _NoiseSpeed, _NoiseScale) - 0.5, _NoiseStrenght);
            o.Alpha = c.a * noise;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
