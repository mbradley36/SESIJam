// Shader created with Shader Forge v1.20 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.20;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:8083,x:33799,y:32614,varname:node_8083,prsc:2|emission-8180-OUT,alpha-7571-OUT;n:type:ShaderForge.SFN_Color,id:4281,x:32149,y:32793,ptovrint:False,ptlb:Shield Color,ptin:_ShieldColor,varname:node_4281,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.05649871,c2:0.4062947,c3:0.6985294,c4:1;n:type:ShaderForge.SFN_Tex2d,id:8911,x:32149,y:32581,varname:node_8911,prsc:2,tex:1280047b813da44c2a5bc76e23b075a5,ntxv:0,isnm:False|TEX-6974-TEX;n:type:ShaderForge.SFN_Multiply,id:5550,x:32361,y:32670,varname:node_5550,prsc:2|A-8911-R,B-4281-RGB;n:type:ShaderForge.SFN_Multiply,id:5940,x:32361,y:32846,varname:node_5940,prsc:2|A-8911-R,B-4281-A;n:type:ShaderForge.SFN_Sin,id:472,x:32180,y:32368,varname:node_472,prsc:2|IN-999-OUT;n:type:ShaderForge.SFN_Time,id:6898,x:31801,y:32368,varname:node_6898,prsc:2;n:type:ShaderForge.SFN_Multiply,id:999,x:31990,y:32368,varname:node_999,prsc:2|A-6898-T,B-9474-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9474,x:31801,y:32527,ptovrint:False,ptlb:Glow Speed,ptin:_GlowSpeed,varname:node_9474,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:5988,x:32529,y:32543,varname:node_5988,prsc:2|A-3122-OUT,B-5550-OUT;n:type:ShaderForge.SFN_RemapRange,id:3122,x:32364,y:32360,varname:node_3122,prsc:2,frmn:-1,frmx:1,tomn:0.5,tomx:2|IN-472-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:6974,x:31953,y:32581,ptovrint:False,ptlb:Shield Texture,ptin:_ShieldTexture,varname:node_6974,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1280047b813da44c2a5bc76e23b075a5,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2536,x:32361,y:33070,varname:node_2536,prsc:2,tex:1280047b813da44c2a5bc76e23b075a5,ntxv:0,isnm:False|UVIN-5643-UVOUT,TEX-6974-TEX;n:type:ShaderForge.SFN_Panner,id:5643,x:32180,y:33101,varname:node_5643,prsc:2,spu:0,spv:1|DIST-8032-OUT;n:type:ShaderForge.SFN_Time,id:8144,x:31809,y:33101,varname:node_8144,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:7516,x:31821,y:33275,ptovrint:False,ptlb:Pan Speed,ptin:_PanSpeed,varname:node_7516,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Multiply,id:8032,x:32011,y:33101,varname:node_8032,prsc:2|A-8144-T,B-7516-OUT;n:type:ShaderForge.SFN_Fresnel,id:8608,x:32694,y:32424,varname:node_8608,prsc:2|EXP-1846-OUT;n:type:ShaderForge.SFN_Multiply,id:8180,x:32881,y:32640,varname:node_8180,prsc:2|A-8608-OUT,B-5988-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1846,x:32529,y:32446,ptovrint:False,ptlb:Fresnel Falloff,ptin:_FresnelFalloff,varname:node_1846,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:2045,x:32533,y:33070,varname:node_2045,prsc:2|A-2536-R,B-2536-G;n:type:ShaderForge.SFN_Fresnel,id:7571,x:32909,y:32969,varname:node_7571,prsc:2|EXP-1846-OUT;n:type:ShaderForge.SFN_Multiply,id:9152,x:33150,y:32821,varname:node_9152,prsc:2|A-5940-OUT,B-7571-OUT;n:type:ShaderForge.SFN_OneMinus,id:6142,x:33352,y:32821,varname:node_6142,prsc:2|IN-9152-OUT;n:type:ShaderForge.SFN_DepthBlend,id:5113,x:33332,y:33048,varname:node_5113,prsc:2|DIST-7550-OUT;n:type:ShaderForge.SFN_Multiply,id:1146,x:33586,y:32915,varname:node_1146,prsc:2|A-7571-OUT,B-5113-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7550,x:33150,y:33082,ptovrint:False,ptlb:Fade Distance,ptin:_FadeDistance,varname:node_7550,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_SceneDepth,id:5877,x:33252,y:33171,varname:node_5877,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3687,x:33513,y:33068,varname:node_3687,prsc:2|A-5113-OUT,B-5877-OUT;proporder:4281-9474-6974-7516-1846-7550;pass:END;sub:END;*/

Shader "Custom/SHADER_FX_Shield" {
    Properties {
        _ShieldColor ("Shield Color", Color) = (0.05649871,0.4062947,0.6985294,1)
        _GlowSpeed ("Glow Speed", Float ) = 1
        _ShieldTexture ("Shield Texture", 2D) = "white" {}
        _PanSpeed ("Pan Speed", Float ) = 0.1
        _FresnelFalloff ("Fresnel Falloff", Float ) = 2
        _FadeDistance ("Fade Distance", Float ) = 1
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
            uniform float _GlowSpeed;
            uniform sampler2D _ShieldTexture; uniform float4 _ShieldTexture_ST;
            uniform float _FresnelFalloff;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 node_6898 = _Time + _TimeEditor;
                float4 node_8911 = tex2D(_ShieldTexture,TRANSFORM_TEX(i.uv0, _ShieldTexture));
                float3 node_5988 = ((sin((node_6898.g*_GlowSpeed))*0.75+1.25)*(node_8911.r*_ShieldColor.rgb));
                float3 node_8180 = (pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelFalloff)*node_5988);
                float3 emissive = node_8180;
                float3 finalColor = emissive;
                float node_7571 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelFalloff);
                fixed4 finalRGBA = fixed4(finalColor,node_7571);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
