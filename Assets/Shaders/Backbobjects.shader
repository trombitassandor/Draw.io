Shader "Custom/Backobjects"
{
	Subshader
	{
		Pass
		{
			Stencil
			{
				Ref 1
				Comp Equal
			}
		}
	}
}