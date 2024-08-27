using Raylib_cs;
using Squatch.Game.Core;

namespace Squatch.Game.GameObjects;

public class BaseGameObject : IGameObject
{
    public float X { get; set; }
    public float Y { get; set; }
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
}