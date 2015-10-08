// Shader created with Shader Forge v1.20 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.20;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:8083,x:34619,y:32603,varname:node_8083,prsc:2|normal-2110-RGB,emission-3434-RGB,alpha-248-OUT,refract-3718-OUT;n:type:ShaderForge.SFN_Tex2d,id:8911,x:33257,y:33043,varname:node_8911,prsc:2,tex:bc7519b5d86184e32a91e5eb9cbd85f9,ntxv:0,isnm:False|UVIN-3485-UVOUT,TEX-7742-TEX;n:type:ShaderForge.SFN_Panner,id:3485,x:33039,y:32902,varname:node_3485,prsc:2,spu:1,spv:1|UVIN-8048-UVOUT,DIST-9428-OUT;n:type:ShaderForge.SFN_TexCoord,id:8048,x:32833,y:32902,varname:node_8048,prsc:2,uv:0;n:type:ShaderForge.SFN_Time,id:750,x:32476,y:33022,varname:node_750,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9428,x:32661,y:33022,varname:node_9428,prsc:2|A-750-T,B-3816-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3816,x:32476,y:33174,ptovrint:False,ptlb:Timing,ptin:_Timing,varname:node_3816,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Panner,id:5174,x:33054,y:33294,varname:node_5174,prsc:2,spu:-1,spv:1|UVIN-4516-UVOUT,DIST-9428-OUT;n:type:ShaderForge.SFN_TexCoord,id:4516,x:32848,y:33294,varname:node_4516,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:7536,x:33453,y:33119,varname:node_7536,prsc:2|A-8911-RGB,B-3384-RGB;n:type:ShaderForge.SFN_ComponentMask,id:2317,x:33621,y:33119,varname:node_2317,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-7536-OUT;n:type:ShaderForge.SFN_TexCoord,id:5753,x:33610,y:32951,varname:node_5753,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:8256,x:33793,y:33030,varname:node_8256,prsc:2|A-5753-UVOUT,B-2317-OUT;n:type:ShaderForge.SFN_Tex2d,id:3384,x:33257,y:33256,varname:node_3384,prsc:2,tex:bc7519b5d86184e32a91e5eb9cbd85f9,ntxv:0,isnm:False|UVIN-5174-UVOUT,TEX-7742-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:7742,x:33045,y:33086,ptovrint:False,ptlb:Noise Map,ptin:_NoiseMap,varname:node_7742,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bc7519b5d86184e32a91e5eb9cbd85f9,ntxv:0,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:2593,x:32460,y:32118,varname:node_2593,prsc:2,uv:0;n:type:ShaderForge.SFN_OneMinus,id:1075,x:32645,y:32199,varname:node_1075,prsc:2|IN-2593-U;n:type:ShaderForge.SFN_OneMinus,id:4741,x:32645,y:32349,varname:node_4741,prsc:2|IN-2593-V;n:type:ShaderForge.SFN_Multiply,id:5516,x:32820,y:32133,varname:node_5516,prsc:2|A-2593-U,B-1075-OUT;n:type:ShaderForge.SFN_Multiply,id:630,x:32820,y:32301,varname:node_630,prsc:2|A-2593-V,B-4741-OUT;n:type:ShaderForge.SFN_Multiply,id:3617,x:33014,y:32133,varname:node_3617,prsc:2|A-5516-OUT,B-630-OUT;n:type:ShaderForge.SFN_Multiply,id:399,x:33974,y:33017,varname:node_399,prsc:2|A-3695-OUT,B-8256-OUT;n:type:ShaderForge.SFN_Clamp01,id:3695,x:33535,y:32325,varname:node_3695,prsc:2|IN-4968-OUT;n:type:ShaderForge.SFN_Multiply,id:2350,x:34156,y:33017,varname:node_2350,prsc:2|A-399-OUT,B-8967-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8967,x:33974,y:33174,ptovrint:False,ptlb:Refraction Intensity,ptin:_RefractionIntensity,varname:node_8967,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Color,id:3434,x:34045,y:32582,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_3434,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.7931032,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:248,x:34193,y:32727,varname:node_248,prsc:2|A-3434-A,B-3695-OUT;n:type:ShaderForge.SFN_Tex2d,id:2110,x:34045,y:32386,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_2110,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:7a5d67865425544d19fd8829ad53fe71,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Multiply,id:3718,x:34433,y:32897,varname:node_3718,prsc:2|A-3166-OUT,B-2350-OUT;n:type:ShaderForge.SFN_ComponentMask,id:3166,x:34222,y:32386,varname:node_3166,prsc:2,cc1:2,cc2:-1,cc3:-1,cc4:-1|IN-2110-RGB;n:type:ShaderForge.SFN_Multiply,id:5746,x:33174,y:32484,varname:node_5746,prsc:2|A-3617-OUT,B-7668-OUT;n:type:ShaderForge.SFN_Vector1,id:7668,x:32985,y:32504,varname:node_7668,prsc:2,v1:17;n:type:ShaderForge.SFN_Power,id:4079,x:33379,y:32484,varname:node_4079,prsc:2|VAL-5746-OUT,EXP-356-OUT;n:type:ShaderForge.SFN_Vector1,id:356,x:33174,y:32614,varname:node_356,prsc:2,v1:6;n:type:ShaderForge.SFN_Power,id:6173,x:33379,y:32634,varname:node_6173,prsc:2|VAL-5746-OUT,EXP-7317-OUT;n:type:ShaderForge.SFN_Vector1,id:7317,x:33174,y:32682,varname:node_7317,prsc:2,v1:2;n:type:ShaderForge.SFN_Subtract,id:4968,x:33557,y:32559,varname:node_4968,prsc:2|A-6173-OUT,B-4079-OUT;proporder:3816-7742-8967-3434-2110;pass:END;sub:END;*/

Shader "Custom/SHADER_FX_RadialForce" {
    Properties {
        _Timing ("Timing", Float ) = 1
        _NoiseMap ("Noise Map", 2D) = "white" {}
        _RefractionIntensity ("Refraction Intensity", Float ) = 1
        _Color ("Color", Color) = (0,0.7931032,1,1)
        _Normal ("Normal", 2D) = "bump" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
        GrabPass{ }
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
            uniform sampler2D _GrabTexture;
            uniform float4 _TimeEditor;
            uniform float _Timing;
            uniform sampler2D _NoiseMap; uniform float4 _NoiseMap_ST;
            uniform float _RefractionIntensity;
            uniform float4 _Color;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float3 tangentDir : TEXCOORD2;
                float3 bitangentDir : TEXCOORD3;
                float4 screenPos : TEXCOORD4;
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float node_5746 = (((i.uv0.r*(1.0 - i.uv0.r))*(i.uv0.g*(1.0 - i.uv0.g)))*17.0);
                float node_3695 = saturate((pow(node_5746,2.0)-pow(node_5746,6.0)));
                float4 node_750 = _Time + _TimeEditor;
                float node_9428 = (node_750.g*_Timing);
                float2 node_3485 = (i.uv0+node_9428*float2(1,1));
                float4 node_8911 = tex2D(_NoiseMap,TRANSFORM_TEX(node_3485, _NoiseMap));
                float2 node_5174 = (i.uv0+node_9428*float2(-1,1));
                float4 node_3384 = tex2D(_NoiseMap,TRANSFORM_TEX(node_5174, _NoiseMap));
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (_Normal_var.rgb.b*((node_3695*(i.uv0*(node_8911.rgb*node_3384.rgb).r))*_RefractionIntensity));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
////// Lighting:
////// Emissive:
                float3 emissive = _Color.rgb;
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,(_Color.a*node_3695)),1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
