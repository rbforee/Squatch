using Squatch.Game.Core;
using Raylib_cs;
namespace Squatch.Game.Behaviors;

public class ColorBehavior : IBehavior
{
    public ColorBehavior()
    {
    }

    public void Input()
    {

    }

    public void Draw()
    {

    }

    public float ColorIndex {get;set;} = 1.0f;
    public float Velocity {get;set;} = 1.0f;

    public void Update(IGameObject GameObject)
    {
        if (GameObject is IColorObject)
        {
            var i = Lib.GetDelta();
            ColorIndex = (ColorIndex + (Velocity * 1)) % 360f;
            ((IColorObject)GameObject).Color = Raylib.ColorFromHSV(ColorIndex, 1.0f, 1.0f);
        }
    }
}