using System.Numerics;
using Raylib_cs;

namespace Squatch.Game.Core;

public class Lib
{
    public static Vector2 CreateVector2(float x, float y)
    {
        return new Vector2(x , y);
    }

    public static Path CreatePath(params Vector2[] points)
    {
        return new Path {Points = points};
    }

    public static void DrawPath(params Vector2[] points)
    {
        for(var i = 1; i < points.Length; i++)
        {
            Raylib.DrawLineEx(points[i - 1], points[i], 10, Color.Black);
        }
    }
}