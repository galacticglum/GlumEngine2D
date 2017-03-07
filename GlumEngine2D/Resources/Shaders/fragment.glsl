#version 330

in vec2 uvCoordinate;
in vec4 vertexPosition;
out vec4 out_Colour;

uniform vec4 ambientColour;
uniform vec4 lightColour;
uniform vec2 lightPosition;

uniform sampler2D textureSampler;

vec4 calculateLight()
{
	float lightDistance = length(distance(vertexPosition.xy, lightPosition));
	float radius = .5;

	if(lightDistance > radius)
	{
		return vec4(0, 0, 0, 0);
	}
	
	return lightColour * (1 - lightDistance / radius) * 10;
}

void main()
{
	vec4 textureColour = texture2D(textureSampler, uvCoordinate.xy);
	vec4 colour = vec4(1, 1, 1, 1); // replace with sprite tint

	if (textureColour != vec4(0, 0, 0, 1))
	{
		colour *= textureColour;
	}

	out_Colour = colour * (calculateLight() * ambientColour);
}