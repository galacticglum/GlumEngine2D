#version 330

in vec2 uvCoordinate;
out vec4 out_Colour;

uniform sampler2D textureSampler;

void main()
{
	vec4 colour = texture2D(textureSampler, uvCoordinate.xy);
	if (colour == vec4(0, 0, 0, 1))
	{
		out_Colour = vec4(1, 0, 0, 1);
	}
	else
	{
		out_Colour = colour;
	}
}