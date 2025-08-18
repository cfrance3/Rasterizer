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



    }

}