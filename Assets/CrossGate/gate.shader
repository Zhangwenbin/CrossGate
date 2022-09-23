Shader "Unlit/gate"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
         _AddColor ("Add Color", Color) = (1,1,1,1)
        _GateWidth ("gate width", Range(0,0.25)) = 0
        
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
       
        Pass
        {
         
            zwrite off 
            Blend srcalpha oneminussrcalpha 
//              Stencil
//             {
//                 Ref 119
//                 Comp Always
//                 Pass Replace
//             } 
         
            CGPROGRAM
            
       
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            half4 _AddColor;
            half _GateWidth;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv)+_AddColor;
                col.a=step(pow(i.uv.x-0.5f,2)+pow(i.uv.y-0.5f,2),_GateWidth);
                
                return col;
            }
            ENDCG
        }
    }
}
