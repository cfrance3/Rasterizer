using System.Drawing;
using Rasterizer.Types;
using Rasterizer.Utils;


namespace Rasterizer.Test
{
    class Test
    {
        public static void CreateTestImage()
        {
            const int width = 128;
            const int height = 128;

            float2 point_a = new float2(10, 10);
            float2 point_b = new float2(10, 10);
            float2 point_c = new float2(10, 10);

            float3[,] image = new float3[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float2 point_p = new float2(x, y);
                    Color c = float2.PointInTriangle(point_a, point_b, point_c, point_p) == true ? Color.Blue : Color.Black;

                    image[x, y] = new float3(c.R, c.G, c.B);
                }
            }

            ImageWriter.WriteImageToFile(image, "test.png");
        }

    }
}
