using Raylib_cs;

namespace Squatch.Game;

class Program
{
    static List<GameObject> GameObjectList;
    static int ScreenHeight;
    static int ScreenWidth;

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


        for(var i = 0; i < 50; i++)
        {
            GameObjectList.Add
            (
                new GameObject 
                {
                    x = rnd.Next() % 800, 
                    y = rnd.Next() % 480,
                    color = Raylib.ColorFromHSV(rnd.Next() % 360, .75f, .5f),
                    radius = rnd.Next() % 50    
                }
            );
        }
    }
}