using Squatch.Game.Core;
using Raylib_cs;
using System.Numerics;

namespace Squatch.Game.GameObjects;

public class CircleGameObject : BaseGameObject
{
    public Color Color {get;set;}

    public override void Draw()
    {
        Raylib.DrawCircleV(this.Position.ToVector2(), this.Size.Y / 2, Color);
    }

    public override void Update()
    {
        foreach (var behavior in Behaviors)
        {
            behavior.Update(this);
        }       
    }
}