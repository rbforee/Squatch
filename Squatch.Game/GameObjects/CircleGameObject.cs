using Squatch.Game.Core;
using Raylib_cs;
using System.Numerics;

namespace Squatch.Game.GameObjects;

public class CircleGameObject : BaseGameObject
{
    public float Radius {get;set;}

    public Color Color {get;set;}

    public override void Draw()
    {
        Raylib.DrawCircleV(new Vector2(X, Y), Radius, Color);
    }

    public override void Update()
    {
        foreach (var behavior in Behaviors)
        {
            behavior.Update(this);
        }       
    }
}