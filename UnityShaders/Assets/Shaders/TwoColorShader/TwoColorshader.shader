Shader "Unlit/TwoColorshader"
{
    Properties
    {
        //_MainTex ("Texture", 2D) = "white" {}
		_DefaultColor ("Default Color", color) = (0, 0, 1, 1)
		_SecondColor ("Second Color", color) = (1, 0, 0, 1)
		// shaders dont support bool -> false = 0, true = 1
		_IsSecondColorOn ("Is Second Color On", float) = 0
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

			float4 _DefaultColor;
			float4	_SecondColor;
			float _IsSecondColorOn;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				if (_IsSecondColorOn == 1) {
					return _SecondColor;
				}
				else {
					return _DefaultColor;
				}
                // sample the texture
                //fixed4 col = tex2D(_MainTex, i.uv);
                //return col;
            }
            ENDCG
        }
    }
}
