#version 330

in vec3 vertexPosition;
out vec4 colour;

void main()
{
	colour = vec4(clamp(vertexPosition, 0.0, 1.0), 1.0);
}