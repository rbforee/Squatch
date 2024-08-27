using Raylib_cs;
using System.Numerics;

namespace Squatch.Game.GameObjects;

public class EnemyGameObject : BaseGameObject
{
    public override void Draw()
    {
        var v1 = new Vector2(X + 10, Y + 10);
        var v2 = new Vector2(X + 50, Y + 50);

        Raylib.DrawRectangleV(v1, v2, Color.White);
        
    }
}
