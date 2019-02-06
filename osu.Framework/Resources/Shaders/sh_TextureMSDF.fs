#ifdef GL_ES
	precision mediump float;
#endif

#include "sh_Utils.h"

#define DISTANCE_RANGE 2.0

varying vec4 v_Colour;
varying vec2 v_TexCoord;

uniform sampler2D m_Sampler;
uniform float m_PixelScale;

void main(void)
{
	vec4 msdf = texture2D(m_Sampler, v_TexCoord, -0.9);
	vec2 msdfUnit = DISTANCE_RANGE / vec2(512, 512);
	float sigDist = median(msdf.r, msdf.g, msdf.b) - 0.5;
	sigDist *= dot(msdfUnit, 0.5 / fwidth(v_TexCoord * m_PixelScale));
	float opacity = clamp(sigDist + 0.5, 0.0, 1.0);
	gl_FragColor = toSRGB(vec4(v_Colour.rgb, v_Colour.a * opacity));
}
