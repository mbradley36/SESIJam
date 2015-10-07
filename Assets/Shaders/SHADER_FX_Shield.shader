// Shader created with Shader Forge v1.20 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.20;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:8083,x:32793,y:32498,varname:node_8083,prsc:2|emission-5988-OUT,alpha-5940-OUT;n:type:ShaderForge.SFN_Color,id:4281,x:32149,y:32782,ptovrint:False,ptlb:Shield Color,ptin:_ShieldColor,varname:node_4281,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.05649871,c2:0.4062947,c3:0.6985294,c4:1;n:type:ShaderForge.SFN_Tex2d,id:8911,x:32149,y:32581,ptovrint:False,ptlb:Shield Texture,ptin:_ShieldTexture,varname:node_8911,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:5550,x:32361,y:32670,varname:node_5550,prsc:2|A-8911-RGB,B-4281-RGB;n:type:ShaderForge.SFN_Multiply,id:5940,x:32361,y:32846,varname:node_5940,prsc:2|A-8911-RGB,B-4281-A;n:type:ShaderForge.SFN_Sin,id:472,x:32180,y:32368,varname:node_472,prsc:2|IN-999-OUT;n:type:ShaderForge.SFN_Time,id:6898,x:31801,y:32368,varname:node_6898,prsc:2;n:type:ShaderForge.SFN_Multiply,id:999,x:31990,y:32368,varname:node_999,prsc:2|A-6898-T,B-9474-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9474,x:31801,y:32527,ptovrint:False,ptlb:Glow Speed,ptin:_GlowSpeed,varname:node_9474,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:5988,x:32529,y:32543,varname:node_5988,prsc:2|A-3122-OUT,B-5550-OUT;n:type:ShaderForge.SFN_RemapRange,id:3122,x:32364,y:32360,varname:node_3122,prsc:2,frmn:-1,frmx:1,tomn:0.75,tomx:1.25|IN-472-OUT;proporder:4281-8911-9474;pass:END;sub:END;*/

Shader "Custom/SHADER_FX_Shield" {
    Properties {
        _ShieldColor ("Shield Color", Color) = (0.05649871,0.4062947,0.6985294,1)
        _ShieldTexture ("Shield Texture", 2D) = "white" {}
        _GlowSpeed ("Glow Speed", Float ) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _ShieldColor;
            uniform sampler2D _ShieldTexture; uniform float4 _ShieldTexture_ST;
            uniform float _GlowSpeed;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
////// Lighting:
////// Emissive:
                float4 node_6898 = _Time + _TimeEditor;
                float4 _ShieldTexture_var = tex2D(_ShieldTexture,TRANSFORM_TEX(i.uv0, _ShieldTexture));
                float3 emissive = ((sin((node_6898.g*_GlowSpeed))*0.25+1.0)*(_ShieldTexture_var.rgb*_ShieldColor.rgb));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,(_ShieldTexture_var.rgb*_ShieldColor.a));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
