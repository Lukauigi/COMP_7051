Shader "Custom/FirstSurfaceShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        [HDR] _Emission ("Emission", color) = (0, 0, 0)

        _Amplitude ("Wave Size", Range(0, 1)) = 0.4
        _Frequency ("Wave Frequency", Range(0, 1)) = 2
        _AnimationSpeed ("Animation Speed", Range(0, 5)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue" = "Geometry" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        // Tells unity where to find the surface shader function
        #pragma surface surf Standard fullforwardshadows vertex:vert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        float _Amplitude;
        float _Frequency;
        float _AnimationSpeed;
        half _Glossiness;
        half _Metallic;
        half3 _Emission;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
            o.Emission = _Emission;
        }

        void vert(inout appdata_full data) {
            float4 modifiedPos = data.vertex;
            modifiedPos.y += sin(data.vertex.x * _Frequency + _Time.y * _AnimationSpeed) * _Amplitude;
            data.vertex = modifiedPos;
        }

        ENDCG
    }
    FallBack "Diffuse"
}
