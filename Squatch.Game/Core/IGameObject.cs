namespace Squatch.Game.Core;

public interface IGameObject
{
    float X {get;set;}
    float Y {get;set;}

    float Height {get;set;}
    float Width {get;set;}

    Guid ID {get;set;}

    IList<IBehavior> Behaviors {get;set;}

    void Draw();
    void Update();
    void Init();
    void Terminate();
    
}