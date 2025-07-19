Shader "Custom/UnlitDisapp"
{
    Properties
    {
        
        [MainTexture] _BaseMap("Albedo", 2D) = "white" {}
        [HDR] _BaseColor("Color", Color) = (1,1,1,1)
        

        
        [Toggle(_ALPHATEST_ON)] _AlphaTestToggle("Alpha Clipping", Float) = 0
        _AlphaCutoff("AlphaCutoff", Range(0.0, 1.0)) = 0.5

        
        _ScrollTexU("ScrollTexU", Range(0.0, 1.0)) = 0
        _ScrollTexV("ScrollTexV", Range(0.0, 1.0)) = 0
        _ScrollTexZ("ScrollTexZ", Range(0.0, 1.0)) = 0
               
                
    }

    Subshader
    {
        Tags
        {
            "RenderType" = "Transparent"
            "RenderPipeline" = "UniversalPipeline"            
            "Queue" = "Transparent"
        }
        

        Pass
        {
            Name "UnlitDisapp"
            
            Blend SrcAlpha OneMinusSrcAlpha
            Blend OneMinusDstColor One
            ZWrite Off
            ZTest LEqual
            Cull Back


            HLSLPROGRAM

            #pragma target 2.0

            #pragma vertex UnlitPassVertex
            #pragma fragment UnlitPassFragment

            #pragma shader_feature_local_fragment _SURFACE_TYPE_TRANSPARENT
            #pragma shader_feature_local_fragment _ALPHATEST_ON
            #pragma shader_feature_local_fragment _ALPHAPREMULTIPLY_ON _ALPHAMODULATE_ON
            #pragma shader_feature_local _USEMASKTEXTURE 
            #pragma shader_feature_local_vertex _SCROLLTEXTURE           
            #pragma shader_feature_local_fragment _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A
            
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            
            CBUFFER_START(UnityPerMaterial)
            float4 _BaseMap_ST;
            float4 _BaseMap_TexelSize;
            float4 _BaseColor;                       
            float _AlphaCutoff;
            half _ScrollTexU;
            half _ScrollTexV;
            half _ScrollTexZ;

            
            CBUFFER_END

            TEXTURE2D(_BaseMap); SAMPLER(sampler_BaseMap);
            

            struct Attributes
            {
                float4 positionOS : POSITION;
                float4 uv : TEXCOORD0;
                float4 color : COLOR;
                  
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float4 uv : TEXCOORD0;
                float4 color : COLOR;
                
            };

            Varyings UnlitPassVertex(Attributes IN)
            {
                Varyings OUT;
                OUT.positionCS = TransformObjectToHClip(IN.positionOS);
                OUT.uv.xy = IN.uv.xy * _BaseMap_ST.xy + _BaseMap_ST.zw;
                OUT.uv.zw = IN.uv.zw;
                OUT.color = IN.color;
                
                return OUT;
            }

                          
            

            half4 UnlitPassFragment(Varyings IN) : SV_Target
            {
                half4 baseMapUV = IN.uv + _Time.y * float4(_ScrollTexU, _ScrollTexV, _ScrollTexZ, 0); 
                half4 baseMap = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, baseMapUV);
                half4 diffuse = baseMap * _BaseColor * IN.color;

                #ifdef _ALPHATEST_ON
                    clip(baseMap - _AlphaCutoff);
                #endif
              
                return diffuse;
            }

            ENDHLSL
        }

        
    }
    
    
}
