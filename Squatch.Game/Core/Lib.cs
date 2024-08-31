using System.Numerics;
using Raylib_cs;

namespace Squatch.Game.Core;

public class Lib
{    

    //
    //
    //
    public static IGameObject AddGameObject(IGameObject gameObject)
    {        
        GameConfiguration.GameObjectList.Add(gameObject);
        return gameObject;
    }

    //
    //
    // 
    public static void RemoveGameObject(IGameObject i)
    {
        GameConfiguration.GameObjectList.Remove(i);
    }

    //
    //
    //
    public static Vector2 CreateVector2(float x, float y)
    {
        return new Vector2(x , y);
    }

    //
    //
    //
    public static Path CreatePath(params Vector2[] points)
    {
        return new Path {Points = points};
    }

    //
    //
    //
    public static void DrawPath(params Vector2[] points)
    {
        for(var i = 1; i < points.Length; i++)
        {
            Raylib.DrawLineEx(points[i - 1], points[i], 10, Color.Black);
        }
    }

    //
    // Clamp function
    //
    public static float Clamp(float value, float min, float max)
    {
        return Math.Clamp(value, min, max);
    }

    //
    //
    //
    public static bool CheckCollision(IGameObject g1, IGameObject g2)
    {
        return   
        // case 1
        (
            (
                (g1.X >= g2.X && g1.X <= g2.X + g2.Width)
                ||
                (g1.X + g1.Width >= g2.X && g1.X + g1.Width <= g2.X + g2.Width)
            )
            &&
            (
                (g1.Y >= g2.Y && g1.Y <= g2.Y + g2.Height)
                ||
                (g1.Y + g1.Height >= g2.Y && g1.X + g1.Height <= g2.Y + g2.Height)
            )
        )
        ||
        // case 2
        (
            (
                (g2.X >= g1.X && g2.X <= g1.X + g1.Width)
                ||
                (g2.X + g2.Width >= g1.X && g2.X + g2.Width <= g1.X + g1.Width)
            )
            &&
            (
                (g2.Y >= g1.Y && g2.Y <= g1.Y + g1.Height)
                ||
                (g2.Y + g2.Height >= g1.Y && g2.X + g2.Height <= g1.Y + g1.Height)
            )
        );
    }
}