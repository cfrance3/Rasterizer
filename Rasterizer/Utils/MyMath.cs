using Rasterizer.Types;

namespace Rasterizer.Utils
{
    public static class MyMath
    {
        //Returns true if p is to the right of the vector ab, false otherwise
        public static bool PointOnRightSideOfLine(float2 a, float2 b, float2 p)
        {
            float2 ap = p - a;
            float2 ab_Perp = float2.Perpendicular(b - a);
            return float2.Dot(ap, ab_Perp) > 0;
        }

        //Returns true if p in on the same side(left or right) of vectors AB, BC, and CA, false otherwise
        public static bool PointInTriangle(float2 a, float2 b, float2 c, float2 p)
        {
            bool AB = PointOnRightSideOfLine(a, b, p);
            bool BC = PointOnRightSideOfLine(b, c, p);
            bool CA = PointOnRightSideOfLine(c, a, p);

            return AB == BC && BC == CA;

        }
    }
}