using Rasterizer.Types;
using static Rasterizer.Renderer.Renderer;


namespace Rasterizer.Test
{
    class Test
    {
        public static void CreateTestImage()
        {
            const int width = 128;
            const int height = 128;

            float3[,] image = new float3[width, height];

            int numTriangles = 3;
            float2[] points = new float2[numTriangles * 3];
            float3[] colors = new float3[numTriangles];

            Random rand = new Random();

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new float2(rand.NextSingle() * width, rand.NextSingle() * height);
            }

            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = new float3(rand.NextSingle(), rand.NextSingle(), rand.NextSingle());
            }

        }

    }
}
