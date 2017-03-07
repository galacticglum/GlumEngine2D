#version 330

layout(location = 0) in vec3 position;
layout(location = 1) in vec2 textureCoordinate;

out vec2 uvCoordinate;
out vec4 vertexPosition;
uniform mat4 transformationMatrix;

void main()
{
	uvCoordinate = textureCoordinate;
	vertexPosition = vec4(position, 1.0) * transformationMatrix;
	gl_Position =  vertexPosition;
}