namespace Rasterizer.Types
{
    public struct float3(float x, float y, float z)
    {
        public float x = x;
        public float y = y;
        public float z = z;

        public float r { get => x; set => x = value; }
        public float g { get => y; set => y = value; }
        public float b { get => z; set => z = value; }
    }

}