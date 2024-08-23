using Raylib_cs;

namespace Squatch.Game;

class Program
{
    static List<GameObject> GameObjectList;
    public static int ScreenHeight;
    public static int ScreenWidth;

    static void Main(string[] args)
    {
        CreateObjects();

        ScreenHeight = 480;
        ScreenWidth = 800;

        Raylib.InitWindow(ScreenWidth, ScreenHeight, "Hello World");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            for(var i = 0; i< GameObjectList.Count; i++)
            {
                GameObjectList[i].Update();
            }

            foreach(var i in GameObjectList)
            {
                Raylib.DrawCircle(i.x, i.y, i.radius, i.color);
            }

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }


    static void CreateObjects()
    {
        GameObjectList = new List<GameObject>();

        var rnd = new Random((int)DateTime.Now.Ticks % int.MaxValue );

        for(var i = 0; i < 30; i++)
        {
            var tx = rnd.Next() % 800;
            var ty = rnd.Next() % 480;

            GameObjectList.Add
            (
                new GameObject 
                {
                    startX = tx, 
                    startY = ty,
                    x = tx, 
                    y = ty,
                    color = Raylib.ColorFromHSV(rnd.Next() % 360, .75f, .5f),
                    radius = rnd.Next() % 50,
                    range = rnd.Next() % 30    
                }
            );
        }
    }
}