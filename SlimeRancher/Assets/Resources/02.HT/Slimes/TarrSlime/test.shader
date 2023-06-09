Shader "Custom/VideoAlpha" {
   Properties {
      _MainTex ("Base (RGB)", 2D) = "white" {}
      _AlphaOffsetX ("alpha offset x", float) = 0.5
      _AlphaOffsetY ("alpha offset y", float) = 0
      _Cutoff ("Cutoff", Range (0,1)) = .5
   }
   SubShader {
   AlphaTest Less [_Cutoff]
         CGPROGRAM
         #pragma surface surf Lambert
   
         sampler2D _MainTex;
         float _AlphaOffsetX;
         float _AlphaOffsetY;
   
         struct Input {
            float2 uv_MainTex;
         };
   
         void surf (Input IN, inout SurfaceOutput o) {
            half4 c = tex2D (_MainTex, IN.uv_MainTex);
            IN.uv_MainTex.x += _AlphaOffsetX;
            IN.uv_MainTex.y += _AlphaOffsetY;
            half4 d = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = (d.r*-1)+1;
         }
         ENDCG
     
   }
   FallBack "Diffuse"
}