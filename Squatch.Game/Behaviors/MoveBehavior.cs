using Squatch.Game.Core;
using Raylib_cs;
namespace Squatch.Game.Behaviors;

public class MoveBehavior : Core.IBehavior
{   
    public Core.Path Path {get;set;} 
    public float Velocity {get;set;} = 1000.0f;
    public float StateX {get;set;} = 1.0f;
    public float StateY {get;set;} = 1.0f;

    public void Input()
    {

    }

    public void Update(IGameObject GameObject)
    {
        var i = Raylib.GetFrameTime();

        var newX = GameObject.X + (Velocity * i * StateX);
        var newY = GameObject.Y + (Velocity * i * StateY);

        if (newX > GameConfiguration.ScreenWidth)
        {
            StateX *= -1;
            newX = GameConfiguration.ScreenWidth;
        }

        if (newX < 1)
        {
            StateX *= -1;
            newX = 1;
        }

        if (newY > GameConfiguration.ScreenHeight)
        {
            StateY *= -1;
            newY = GameConfiguration.ScreenHeight;
        }

        if (newY < 1)
        {
            StateY *= -1;
            newY = 1;
        }

        GameObject.X = newX;
        GameObject.Y = newY;
    }

    public void Draw()
    {

    }
}