﻿using Raylib_cs;
using System.Numerics;
using Squatch.Game.Core;
using Squatch.Game.GameObjects;

namespace Squatch.Game;

class Program
{
    static void Main(string[] args)
    {        
        //CreateObjects();

        GameConfiguration.GameObjectList = new List<IGameObject>();

        Raylib.SetTargetFPS(GameConfiguration.FramesPerSecond);
        Raylib.InitWindow(GameConfiguration.ScreenWidth, GameConfiguration.ScreenHeight, "Hello World");

        var ship = new ShipGameObject
        {
            X = GameConfiguration.ScreenWidth / 2, 
            Y = GameConfiguration.ScreenHeight - 64
        };



        var enemy1 = new EnemyGameObject ();

        enemy1.Behaviors.Add
        (
            new Behaviors.MoveBehavior
            {
                Path = Lib.CreatePath(new Vector2(10, 10), new Vector2(1000, 1000))
            }
        );


        var enemy2 = new EnemyGameObject 
        {
            X = 200,  
            Y = 100,

            Behaviors = new List<IBehavior> 
            {
                new Behaviors.MoveBehavior
                {
                    Path = Lib.CreatePath(new Vector2(10, 10), new Vector2(1000, 1000))
                }
            }           
        };

        GameConfiguration.GameObjectList.Add(ship);
        GameConfiguration.GameObjectList.Add(enemy1);
        GameConfiguration.GameObjectList.Add(enemy2);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            for(var i = 0; i< GameConfiguration.GameObjectList.Count; i++)
            {

                //    
                // Check collision
                //
                GameConfiguration.GameObjectList[i].Update();
                
                GameConfiguration.GameObjectList[i].Draw();
            }

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

    static void CreateObjects()
    {
        GameConfiguration.GameObjectList = new List<IGameObject>();

        var rnd = new Random((int)DateTime.Now.Ticks % int.MaxValue );

        for(var i = 0; i < 30; i++)
        {
            var tx = rnd.Next() % GameConfiguration.ScreenWidth;
            var ty = rnd.Next() % GameConfiguration.ScreenHeight;

            GameConfiguration.GameObjectList.Add
            (
                new CircleGameObject 
                {
                    X = tx, 
                    Y = ty,
                    Radius = rnd.Next() % 50,
                    Behaviors = new List<IBehavior> 
                    {
                        new Behaviors.MoveBehavior
                        {
                            Path = Lib.CreatePath(new Vector2(10, 10), new Vector2(1000, 1000))
                        }
                    }
                }
            );
        }
    }
}