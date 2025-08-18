using Rasterizer.Types;
using Raylib_cs;
using static Rasterizer.Renderer.Renderer;
using static Rasterizer.Utils.ImageWriter;

public static class Engine
{
    public static void Run(Screen screen)
    {

        Raylib.SetTraceLogLevel(TraceLogLevel.Error);
        Raylib.InitWindow(screen.Width, screen.Height, "Triangle Test");
        Raylib.SetTargetFPS(60);

        int numTriangles = 30;
        Random rand = new Random();

        float2[] points = new float2[numTriangles * 3];
        float2[] velocity = new float2[numTriangles * 3];
        float3[] colors = new float3[numTriangles];

        float3[] image = new float3[screen.Width * screen.Height];
        float3[] blankImage = new float3[screen.Width * screen.Height];


        Texture2D texture = Raylib.LoadTextureFromImage(
            Raylib.GenImageColor(screen.Width, screen.Height, Color.Black)
            );

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = new float2(rand.Next(screen.Width), rand.Next(screen.Height));
        }

        for (int i = 0; i < numTriangles; i++)
        {
            colors[i] = new float3(rand.NextSingle(), rand.NextSingle(), rand.NextSingle());
            velocity[i * 3] = new float2(rand.Next(-150, 150), rand.Next(-150, 150));
            velocity[(i * 3) + 1] = velocity[i];
            velocity[(i * 3) + 2] = velocity[i];
        }

        while (!Raylib.WindowShouldClose())
        {

            float dt = Raylib.GetFrameTime();
            Array.Copy(blankImage, image, blankImage.Length);

            for (int i = 0; i < points.Length; i++)
            {
                points[i].x += velocity[i].x * dt;
                points[i].y += velocity[i].y * dt;

                if (points[i].x < 0 || points[i].x > screen.Width) velocity[i].x *= -1;
                if (points[i].y < 0 || points[i].y > screen.Height) velocity[i].y *= -1;

            }


            Render(points, colors, image, screen.Width, screen.Height);

            Color[] pixels = ImageToRaylibColors(image, screen.Width, screen.Height);
            Raylib.UpdateTexture(texture, pixels);

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);
            Raylib.DrawTexture(texture, 0, 0, Color.White);
            Raylib.EndDrawing();
        }

    }
}