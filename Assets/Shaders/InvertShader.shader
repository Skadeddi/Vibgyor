Shader "CustomEffects/Invert"
{
    HLSLINCLUDE
    
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        // The Blit.hlsl file provides the vertex shader (Vert),
        // the input structure (Attributes), and the output structure (Varyings)
        #include "Packages/com.unity.render-pipelines.core/Runtime/Utilities/Blit.hlsl"

    
        float4 InvertColor (Varyings input) : SV_Target
        {
            float3 color = SAMPLE_TEXTURE2D(_BlitTexture, sampler_LinearClamp, input.texcoord).rgb;
            return float4(0.5 - color.r, 0.5 - color.g, 0.5 - color.b, 1);
        }

        float4 SimpleBlit (Varyings input) : SV_Target
        {
            float3 color = SAMPLE_TEXTURE2D(_BlitTexture, sampler_LinearClamp, input.texcoord).rgb;
            return float4(color.rgb, 1);
        }
    
    ENDHLSL
    
    SubShader
    {
        Tags { "RenderType"="Opaque" "RenderPipeline" = "UniversalPipeline"}
        LOD 100
        ZTest Always ZWrite Off Cull Off
        Pass
        {
            Name "InvertColor"

            HLSLPROGRAM
            
            #pragma vertex Vert
            #pragma fragment InvertColor
            
            ENDHLSL
        }
        
        Pass
        {
            Name "SimpleBlit"

            HLSLPROGRAM
            
            #pragma vertex Vert
            #pragma fragment SimpleBlit
            
            ENDHLSL
        }
    }
}