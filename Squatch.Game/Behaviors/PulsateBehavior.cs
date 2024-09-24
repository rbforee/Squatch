using Squatch.Game.Core;
using Raylib_cs;

namespace Squatch.Game.Behaviors;

public class PulsateBehavior : IBehavior
{

    public float Min {get;set;}
    public float Max {get;set;}

    public float Rate {get;set;}
    public float Direction {get;set;}
    public void Input()
    {

    }
    public void Draw()
    {

    }

    public void Update (IGameObject GameObject)
    {
        var i = Lib.GetDelta();

        GameObject.Size.Y += (Rate * i) * Direction;
        GameObject.Size.X += (Rate * i) * Direction;

        if (GameObject.Size.Y > Max || GameObject.Size.Y < Min) Direction = Direction * -1;
    }

}