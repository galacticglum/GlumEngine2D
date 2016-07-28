#version 330

out vec4 out_Colour;

uniform vec4 uniformColour;

void main()
{
	out_Colour = uniformColour;
}