using static System.Math;
using Rasterizer.Types;
using Raylib_cs;
using static Rasterizer.Utils.MyMath;
using static Rasterizer.Utils.ImageWriter;



namespace Rasterizer.Renderer
{
    public static class Renderer
    {

        public static void Render(float2[] points, float3[] triangleColors, float3[,] image)
        {
            for (int i = 0; i < points.Length; i += 3)
            {
                float2 a = points[i];
                float2 b = points[i + 1];
                float2 c = points[i + 2];

                float minX = Min(Min(a.x, b.x), c.x);
                float minY = Min(Min(a.y, b.y), c.y);
                float maxX = Max(Max(a.x, b.x), c.x);
                float maxY = Max(Max(a.y, b.y), c.y);

                int bbStartX = Clamp((int)minX, 0, image.GetLength(0));
                int bbStartY = Clamp((int)minY, 0, image.GetLength(1));
                int bbEndX = Clamp((int)Ceiling(maxX), 0, image.GetLength(0));
                int bbEndY = Clamp((int)Ceiling(maxY), 0, image.GetLength(1));

                for (int y = bbStartY; y < bbEndY; y++)
                {
                    for (int x = bbStartX; x < bbEndX; x++)
                    {
                        if (!PointInTriangle(a, b, c, new float2(x, y))) continue;
                        image[x, y] = triangleColors[i / 3];
                    }
                }

            }
        }

        public static void Render(float2[] points, float3[] colors, float3[] image, int width, int height)
        {
            int numTriangles = points.Length / 3;

            float[] zBuffer = new float[width * height];
            for (int i = 0; i < zBuffer.Length; i++)
            {
                zBuffer[i] = -1;
            }

            Parallel.For(0, numTriangles, t =>
            {
                float2 a = points[t * 3];
                float2 b = points[t * 3 + 1];
                float2 c = points[t * 3 + 2];

                int minX = (int)Min(Min(a.x, b.x), c.x);
                int minY = (int)Min(Min(a.y, b.y), c.y);
                int maxX = (int)Max(Max(a.x, b.x), c.x);
                int maxY = (int)Max(Max(a.y, b.y), c.y);

                int bbStartX = Clamp(minX, 0, width);
                int bbStartY = Clamp(minY, 0, height);
                int bbEndX = Clamp(maxX, 0, width);
                int bbEndY = Clamp(maxY, 0, height);

                for (int y = bbStartY; y < bbEndY; y++)
                {
                    int rowStart = y * width;
                    for (int x = bbStartX; x < bbEndX; x++)
                    {
                        if (!PointInTriangle(a, b, c, new float2(x, y))) continue;

                        int idx = rowStart + x;

                        if (t >= zBuffer[idx])
                        {
                            zBuffer[idx] = t;
                            image[idx] = colors[t];
                        }
                    }
                }
            });
        }
    }


}