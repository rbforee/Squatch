using Raylib_cs;
using System.Numerics;

namespace Squatch.Game.GameObjects;

public class BulletGameObject : BaseGameObject
{

    public override void Draw()
    {
        var v1 = new Vector2(X + 30 , Y + 30);

        Raylib.DrawCircleV(v1, 30, Color.Orange);
    }

    public override void Update()
    {
        Y -= 1500 * Raylib.GetFrameTime();
    }
}