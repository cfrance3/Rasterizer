using Rasterizer.Types;
using Rasterizer.Utils;

namespace Rasterizer.Test
{
    class Test
    {
        public static void CreateTestImage()
        {
            const int width = 65;
            const int height = 65;
            const int mid = width / 2;
            float3[,] image = new float3[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double dist_x = x - mid;
                    double dist_y = y - mid;
                    double dist = Math.Sqrt(Math.Pow(dist_x, 2) + Math.Pow(dist_y, 2));
                    float r = (float)(dist / width);
                    float g = y / (height - 1f);
                    float b = x / (width - 1f);
                    image[x, y] = new float3(r, g, b);
                }
            }

            ImageWriter.WriteImageToFile(image, "test.png");
        }

    }
}
