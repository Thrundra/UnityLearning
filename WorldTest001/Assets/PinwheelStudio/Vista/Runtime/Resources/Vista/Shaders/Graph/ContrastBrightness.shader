Shader "Hidden/Vista/Graph/ContrastBrightness"
{
	SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 100
		ColorMask R

		Pass
		{
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			#include "../Includes/Math.hlsl"

			struct appdata
			{
				float4 vertex: POSITION;
				float2 uv: TEXCOORD0;
			};

			struct v2f
			{
				float2 uv: TEXCOORD0;
				float4 vertex: SV_POSITION;
				float4 localPos: TEXCOORD1;
			};

			sampler2D _MainTex;
			float _Contrast;
			float _Brightness;

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.localPos = v.vertex;
				return o;
			}

			float frag(v2f input): SV_Target
			{
				float value = tex2D(_MainTex, input.localPos).r;

				float rangeWidth = _Contrast + 1;
				float rangeOffset = 0.5 + _Brightness * 0.5;
				float rangeMin = rangeOffset -rangeWidth * 0.5;
				float rangeMax = rangeOffset +rangeWidth * 0.5;
				
				value = lerp(rangeMin, rangeMax, value);

				return value;
			}
			ENDCG

		}
	}
}
