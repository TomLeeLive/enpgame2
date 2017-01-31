﻿Shader "DemoGame/AutoFade" 
{ 
	SubShader
	{ 
		Pass
		{ 
			Blend SrcAlpha OneMinusSrcAlpha 
			ZWrite Off 
			Cull Off 
			Fog{ Mode Off } 
			BindChannels{ Bind "Color",color }
		} 
	} 
}
