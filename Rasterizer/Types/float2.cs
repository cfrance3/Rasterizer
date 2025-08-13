namespace Rasterizer.Types
{
    public struct float2(float x, float y)
    {
        public float x = x;
        public float y = y;

        public static float2 operator *(float2 a, float scalar) => new(a.x * scalar, a.y * scalar);
        public static float2 operator *(float scalar, float2 a) => a * scalar;
        public static float2 operator -(float2 a, float2 b) => new(a.x - b.x, a.y - b.y);


        public static float Dot(float2 a, float2 b) => a.x * b.x + a.y * b.y;

        public static float2 Perpendicular(float2 vec) => new(vec.y, -vec.x);

        //Returns true if p is to the right of the vector ab
        public static bool PointOnRightSideOfLine(float2 a, float2 b, float2 p)
        {
            float2 ap = p - a;
            float2 ab_Perp = Perpendicular(b - a);
            return Dot(ap, ab_Perp) > 0;
        }

        public static bool PointInTriangle(float2 a, float2 b, float2 c, float2 p)
        {
            bool AB = PointOnRightSideOfLine(a, b, p);
            bool BC = PointOnRightSideOfLine(b, c, p);
            bool CA = PointOnRightSideOfLine(c, a, p);

            return AB == BC && BC == CA;

        }

    }

}