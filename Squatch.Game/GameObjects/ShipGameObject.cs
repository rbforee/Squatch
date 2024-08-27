using Raylib_cs;
using System.Numerics;

namespace Squatch.Game.GameObjects;

public class ShipGameObject : BaseGameObject
{
    public Vector2 v1 {get;set;} = new Vector2(32,1);
    public Vector2 v2 {get;set;} = new Vector2(1,64);
    public Vector2 v3 {get;set;} = new Vector2(64,64);
    public float Velocity {get;set;} = 100.0f;

    public override void Draw()
    {
        var tv1 = new Vector2(v1.X + X, v1.Y + Y);
        var tv2 = new Vector2(v2.X + X, v2.Y + Y);
        var tv3 = new Vector2(v3.X + X, v3.Y + Y);

        Raylib.DrawTriangle(tv1, tv2, tv3, Color.SkyBlue);
    }

    public override void Update()
    {
        if (Raylib.IsKeyDown(KeyboardKey.Left))
        {
            X = X - (Velocity * Raylib.GetFrameTime());
        }

        if (Raylib.IsKeyDown(KeyboardKey.Right))
        {
            X = X + (Velocity * Raylib.GetFrameTime());
        }

        if (Raylib.IsKeyPressed(KeyboardKey.Space))
        {
            GameConfiguration.GameObjectList.Add
            (
                new BulletGameObject
                { 
                    X = v1.X + X, 
                    Y = v1.Y + Y
                }
            );
        }

    }
}
