Shader "EnterVR"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _ShadeColor("ShadeColor", Color) = (0,0,0,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdbase
            
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD0;
            };

            float4 _Color;
            float4 _ShadeColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                float3 normal = i.normal;
                float3 lightDir = _WorldSpaceLightPos0.xyz;
                float shade = (dot(normal, lightDir) + 1) * 0.5;
                return  lerp(_ShadeColor, _Color, shade);
            }
            ENDCG
        }
    }
}
