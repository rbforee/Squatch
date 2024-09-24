using Squatch.Game.Core;
using Raylib_cs;

namespace Squatch.Game.GameObjects;

public class CoinGameObject : BaseGameObject
{
    
    public override void Init()
    {

    }


    public override void Draw()
    {

        var v1 = Lib.AddPoints(Position, new Point(30,30)); 

        Raylib.DrawCircleV(v1.ToVector2(), 30, Color.Orange);
    }
    
    public override void Update()
    {
        Position.Y -= 1500 * Lib.GetDelta(); 
    }
}