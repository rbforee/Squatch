using Squatch.Game.Core;
using Raylib_cs;
using System.Numerics;

namespace Squatch.Game.GameObjects;

public class EnemyGameObject : BaseGameObject
{
    public override void Draw()
    {
        Raylib.DrawText("hell o world", 1, 1, 20, Color.White);
        var v1 = new Vector2 (10, 10); //Point(10,10).ToVector2();
        var v2 = new Vector2 (100,100); //Point(100,100).ToVector2();

        Raylib.DrawRectangleV
        (   new Point(10,10).ToVector2(), 
            new Point(64,64).ToVector2(),
            Color.White
        );        
    }
}