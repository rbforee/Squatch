using Raylib_cs;
using System.Numerics;
using Squatch.Game.Core;

namespace Squatch.Game.GameObjects;

public class ShipGameObject : BaseGameObject
{
    public Vector2 v1 {get;set;} = new Vector2(32,1);
    public Vector2 v2 {get;set;} = new Vector2(1,64);
    public Vector2 v3 {get;set;} = new Vector2(64,64);
    
    public float MaxVelocity {get;set;} = 100.0f;
    public float VelocityX {get;set;} = 0.0f;
    public float VelocityY {get;set;} = 0.0f;
    public float Acceleration {get;set;} = 50.0f;

    public override void Draw()
    {
        var tv1 = new Vector2(v1.X + X, v1.Y + Y);
        var tv2 = new Vector2(v2.X + X, v2.Y + Y);
        var tv3 = new Vector2(v3.X + X, v3.Y + Y);

        Raylib.DrawTriangle(tv1, tv2, tv3, Color.SkyBlue);

        Height = 64; Width = 64;
    }


    //
    //
    //
    public override void Update()
    {


        Raylib.DrawText($"Ship => coord {X}:{Y} {this.VelocityX.ToString("0.00")}:{this.VelocityY.ToString("0.00")}", 0, 0, 14, Color.White);


        bool IsMoveKeyPressed = false;

        //
        // update / down
        //
        if (Raylib.IsKeyDown(KeyboardKey.Up))
        {
            VelocityY += (Acceleration * -1) * Raylib.GetFrameTime();

            VelocityY = Math.Clamp(VelocityY, MaxVelocity * -1, MaxVelocity);    
            
            Y = Y + VelocityY;

            IsMoveKeyPressed = true;
        }
        else
        {
            if (Raylib.IsKeyDown(KeyboardKey.Down))
            {
                VelocityY += Acceleration * Raylib.GetFrameTime();

                VelocityY = Math.Clamp(VelocityY, MaxVelocity * -1, MaxVelocity);    
                
                Y = Y + VelocityY;

                IsMoveKeyPressed = true;
            }            
        }


        //
        // left / right
        //
        if (Raylib.IsKeyDown(KeyboardKey.Left))
        {

            VelocityX += (Acceleration * -1) * Raylib.GetFrameTime();

            VelocityX = Math.Clamp(VelocityX, MaxVelocity * -1, MaxVelocity);    
            
            X = X + VelocityX;

            IsMoveKeyPressed = true;
        }
        else
        {
            if (Raylib.IsKeyDown(KeyboardKey.Right))
            {
                VelocityX += Acceleration * Raylib.GetFrameTime();

                VelocityX = Math.Clamp(VelocityX, MaxVelocity * -1, MaxVelocity);    
                
                X = X + VelocityX;

                IsMoveKeyPressed = true;
            }
        }

        if (Raylib.IsKeyPressed(KeyboardKey.Space))
        {
            Lib.AddGameObject
            (
                new BulletGameObject
                { 
                    X = v1.X + X, 
                    Y = v1.Y + Y
                }
            );
        }

        //
        // decellerate X
        //
        if (!IsMoveKeyPressed && VelocityX != 0)
        {
            var i = 0f;
 
            if (VelocityX > 0) i = -1;
 
            if (VelocityX < 0) i = 1;

            
            if (Math.Abs(VelocityX) < Acceleration * Raylib.GetFrameTime() )
            {
                VelocityX = 0;
            }
            else
            {
                VelocityX = VelocityX + (Acceleration * i * Raylib.GetFrameTime());
            }

            X = X + VelocityX;                        
        }

        //
        // decellerate Y
        //
        if (!IsMoveKeyPressed && VelocityY != 0)
        {
            var i = 0f;
 
            if (VelocityY > 0) i = -1;
 
            if (VelocityY < 0) i = 1;

            VelocityY = VelocityY + (Acceleration * i * Raylib.GetFrameTime());

             
            if (Math.Abs(VelocityY) < Acceleration)
            {
                VelocityY = 0;
            }
           
            Y = Y + VelocityY;
        }


        // clamp the value to the screen height and width
        X = Lib.Clamp(X, 0, GameConfiguration.ScreenWidth - Width);
        Y = Lib.Clamp(Y, 0, GameConfiguration.ScreenHeight);

    }
}