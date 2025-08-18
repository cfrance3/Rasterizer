using Rasterizer.Types;

public class Screen(int w, int h)
{
    public readonly int Width = w;
    public readonly int Height = h;
    public readonly float2 Size = new(w, h);
    public readonly float3[] ColorBuffer = new float3[w * h];

    public void Clear(float3 defaultColor)
    {
        for (int i = 0; i < Width * Height; i++)
        {
            ColorBuffer[i] = defaultColor;
        }
    }
}