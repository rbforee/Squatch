using Squatch.Game.Core;

namespace Squatch.Game;

public class GameConfiguration
{
    public static List<IGameObject> GameObjectList;
    public static int ScreenHeight {get;set;} = 768;
    public static int ScreenWidth {get;set;} = 1024;
    public static int FramesPerSecond {get;set;} = 144;
}