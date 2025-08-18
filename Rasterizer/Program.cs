using System;
using Raylib_cs;
using Rasterizer.Test;

class Program
{
    static void Main()
    {
        // Test.CreateTestImage();

        Screen screen = new(800, 800);
        Engine.Run(screen);

    }
}
