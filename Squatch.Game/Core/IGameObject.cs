using Raylib_cs;
using System.Numerics;

namespace Squatch.Game.Core;

public interface IGameObject
{
    /// <summary>
    /// Direction in degrees with 0 being east
    /// </summary>
    float Direction {get;set;}

    Point Position {get;set;}

    Point Size {get;set;}

    bool IsDestroyed {get;set;}
    uint ID {get;set;}

    IList<IBehavior> Behaviors {get;set;}

    float Velocity {get;set;}
    void Draw();
    void Update();
    void Init();
    void Terminate();
    void Remove(); // when the object is removed from the list    
}
