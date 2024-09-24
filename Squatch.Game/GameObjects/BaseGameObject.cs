using Raylib_cs;
using Squatch.Game.Core;
using System.Numerics;

namespace Squatch.Game.GameObjects;

public class BaseGameObject : IGameObject
{
    public bool IsDestroyed {get;set;}

    public float Direction {get;set;}
    public Point Position {get;set;}
    public Point Size {get;set;}
    public uint ID {get;set;}
    public float Velocity {get;set;}
    public IList<IBehavior> Behaviors {get;set;} = new List<IBehavior>();

    public virtual void Draw() 
    {

    }

    public virtual void Init() 
    {

    }

    public virtual void Terminate() 
    {

    }

    public virtual void Update() 
    {
        foreach(var b in this.Behaviors)
        {
            b.Update(this);
        }
    }

    public virtual void Remove()
    {

    }
}