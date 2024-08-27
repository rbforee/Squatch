namespace Squatch.Game.Core;

public interface IBehavior
{
    void Input();
    void Update(IGameObject GameObject);
    void Draw();
}

