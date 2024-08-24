using Squatch.Game.Core;

namespace Squatch.Game.GameObjects;

public class CircleGameObject : IGameObject
{
    public float X {get;set;}
    public float Y { get; set; }

    public IList<IBehavior> Behaviors {get;set;}



}