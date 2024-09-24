using Squatch.Game.Core;
using Raylib_cs;

namespace Squatch.Game.Behaviors;

public class LifeSpanBehavior : IBehavior
{
    public float LifeSpanInSeconds {get;set;}
    public float Age {get;set;}
    
    public void Input()
    {

    }

    public void Draw()
    {

    }


    public void Update (IGameObject GameObject)
    {
        Age = Age + Lib.GetDelta();

        if (Age > LifeSpanInSeconds)
        {
            Lib.RemoveGameObject (GameObject);
        }
    }
}