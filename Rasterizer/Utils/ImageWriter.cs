using System;
using Raylib_cs;
using Rasterizer.Types;
using System.Runtime.CompilerServices;

namespace Rasterizer.Utils
{
    public static class ImageWriter
    {
        public static void WriteImageToFile(float3[,] image, string filename)
        {
            int width = image.GetLength(0);
            int height = image.GetLength(1);

            Image img = Raylib.GenImageColor(width, height, Color.Black);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float3 pixel = image[x, y];
                    Color c = new Color(
                        (byte)(Math.Clamp(pixel.r, 0f, 1f) * 255),
                        (byte)(Math.Clamp(pixel.g, 0f, 1f) * 255),
                        (byte)(Math.Clamp(pixel.b, 0f, 1f) * 255),
                        (byte)255
                    );
                    Raylib.ImageDrawPixel(ref img, x, y, c);
                }
            }

            Raylib.ExportImage(img, filename);
            Raylib.UnloadImage(img);
        }

        public static Color[] ImageToRaylibColors(float3[] image, int width, int height)
        {

            Color[] pixels = new Color[width * height];
            int index = 0;

            for (int y = 0; y < height; y++)
            {
                int rowStart = y * width;
                for (int x = 0; x < width; x++)
                {
                    float3 pixel = image[rowStart + x];
                    pixels[index] = new Color(
                        (byte)(Math.Clamp(pixel.r, 0f, 1f) * 255),
                        (byte)(Math.Clamp(pixel.g, 0f, 1f) * 255),
                        (byte)(Math.Clamp(pixel.b, 0f, 1f) * 255),
                        (byte)255
                    );

                    index++;
                }
            }
            return pixels;
        }

    }
}

