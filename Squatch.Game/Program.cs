using Raylib_cs;
using System.Numerics;
using Squatch.Game.Core;
using Squatch.Game.GameObjects;
using System.Text.Json;


namespace Squatch.Game;

class Program
{
    static void Main(string[] args)
    {        

        GameConfiguration.GameObjectList = new List<IGameObject>();

        Raylib.SetTargetFPS(GameConfiguration.FramesPerSecond);
        Raylib.InitWindow(GameConfiguration.ScreenWidth, GameConfiguration.ScreenHeight, "Hello World");

        Lib.Initialize();


        var lev = Lib.CreateLevel();

        Lib.AddGameObject(lev);


        for(var c = 0; c < 10; c++)
        {
            Lib.AddGameObject( Lib.CreateEnemy() );
        }

        var ship = Lib.CreateHero();
        Lib.AddGameObject( ship );

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            //    
            // Check collision
            // remove the objects that collide
            // TOTO add different types of collision
            //
            // var removelist = new List<IGameObject>();
            // for(var x = 0; x < GameConfiguration.GameObjectList.Count; x++)
            // {
            //     for(var y = x; y < GameConfiguration.GameObjectList.Count;y++)
            //     {
            //         if (Lib.CheckCollision(GameConfiguration.GameObjectList[x], GameConfiguration.GameObjectList[y]))
            //         {
            //             removelist.Add(GameConfiguration.GameObjectList[x]);
            //             removelist.Add(GameConfiguration.GameObjectList[y]);                                                
            //         }
            //     }
            // }


            for(var i = 0; i< GameConfiguration.GameObjectList.Count; i++)
            {
                GameConfiguration.GameObjectList[i].Update();                
                GameConfiguration.GameObjectList[i].Draw();
            }

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}