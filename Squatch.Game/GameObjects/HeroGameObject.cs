using Raylib_cs;
using System.Numerics;
using Squatch.Game.Core;

namespace Squatch.Game.GameObjects;

public class HeroGameObject : BaseGameObject
{
    public Point v1 {get;set;} = new Point(32,1);
    public Point v2 {get;set;} = new Point(1,64);
    public Point v3 {get;set;} = new Point(64,64);
    
    public float MaxVelocity {get;set;} = 100.0f;
    public float VelocityX {get;set;} = 0.0f;
    public float VelocityY {get;set;} = 0.0f;
    public float Acceleration {get;set;} = 50.0f;

    public override void Draw()
    {
        var tv1 = new Vector2(v1.X + Position.X, v1.Y + Position.Y);
        var tv2 = new Vector2(v2.X + Position.X, v2.Y + Position.Y);
        var tv3 = new Vector2(v3.X + Position.X, v3.Y + Position.Y);

        Raylib.DrawTriangle(tv1, tv2, tv3, Color.SkyBlue);

        Size.X = 64; 
        Size.Y = 64;
    }


    //
    //
    //
    public override void Update()
    {
        
        Raylib.DrawText($"Ship => coord {Position.X}:{Position.Y} {this.VelocityX.ToString("0.00")}:{this.VelocityY.ToString("0.00")}", 0, 0, 14, Color.White);


        bool IsMoveKeyPressed = false;

        //
        // update / down
        //
        if (Raylib.IsKeyDown(KeyboardKey.Up))
        {
            VelocityY += (Acceleration * -1) * Raylib.GetFrameTime();

            VelocityY = Math.Clamp(VelocityY, MaxVelocity * -1, MaxVelocity);    
            
            Position.Y = Position.Y + VelocityY;

            IsMoveKeyPressed = true;
        }
        else
        {
            if (Raylib.IsKeyDown(KeyboardKey.Down))
            {
                VelocityY += Acceleration * Raylib.GetFrameTime();

                VelocityY = Math.Clamp(VelocityY, MaxVelocity * -1, MaxVelocity);    
                
                Position.Y = Position.Y + VelocityY;

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
            
            Position.X = Position.X + VelocityX;

            IsMoveKeyPressed = true;
        }
        else
        {
            if (Raylib.IsKeyDown(KeyboardKey.Right))
            {
                VelocityX += Acceleration * Raylib.GetFrameTime();

                VelocityX = Math.Clamp(VelocityX, MaxVelocity * -1, MaxVelocity);    
                
                Position.X = Position.X + VelocityX;

                IsMoveKeyPressed = true;
            }
        }

        if (Raylib.IsKeyPressed(KeyboardKey.Space))
        {
            Lib.AddGameObject
            (
                new BulletGameObject
                { 
                    Position = Lib.AddPoints(v1, Position) 
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

            Position.X = Position.X + VelocityX;                        
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
           
            Position.Y = Position.Y + VelocityY;
        }

        // clamp the value to the screen height and width
        Position.X = Lib.Clamp(Position.X, 0, GameConfiguration.ScreenWidth - Size.X);
        Position.Y = Lib.Clamp(Position.Y, 0, GameConfiguration.ScreenHeight);

    }
}