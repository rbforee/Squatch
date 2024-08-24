namespace Squatch.Game.Core;

public interface IGameObject
{
    float X {get;set;}
    float Y {get;set;}

    IList<IBehavior> Behaviors {get;set;}
    
}