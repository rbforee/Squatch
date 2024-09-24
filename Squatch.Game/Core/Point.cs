using System.Numerics;

namespace Squatch.Game.Core;

public class Point
{
    public Point (float x, float y)
    {
        this.X = x;
        this.Y = y;
    }
    
    public float X {get;set;}
    public float Y {get;set;}

    public Vector2 ToVector2()
    {
        return Lib.CreateVector2(this);
    }
}