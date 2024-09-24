using System.Numerics;
using Raylib_cs;
using Squatch.Game.Core;
using Squatch.Game.Behaviors;
using Squatch.Game.GameObjects;

namespace Squatch.Game.Core;

public class Lib
{    

    public static Random RandomNumberGenerator {get;set;}

    //
    //
    //
    public static IGameObject AddGameObject(IGameObject gameObject)
    {        
        gameObject.ID = GenerateID();
        GameConfiguration.GameObjectList.Add(gameObject);
        gameObject.Init();
        return gameObject;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="g1"></param>
    /// <param name="g2"></param>
    /// <returns></returns>
    public static bool CheckCollision(IGameObject g1, IGameObject g2)
    {
        return Raylib.CheckCollisionRecs
        (
            new Rectangle(g1.Position.ToVector2(), g1.Size.ToVector2())
            ,new Rectangle(g2.Position.ToVector2(), g2.Size.ToVector2())
        );
    }

    /// <summary>
    /// 
    /// </summary>
    public static void CollectionDestroyedGameObjects()
    {
        var temp = new List<IGameObject>();

        foreach(var go in GameConfiguration.GameObjectList)
        {
            if (go.IsDestroyed) temp.Add(go);
        }

        foreach(var go in temp)
        {
            GameConfiguration.GameObjectList.Remove(go);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static void Initialize()
    {
        RandomNumberGenerator = new Random();
        GameConfiguration.CurrentObjectID = 0;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static IGameObject CreateHero()
    {
        return new HeroGameObject 
        {
            Position = new Point(GameConfiguration.ScreenWidth / 2, GameConfiguration.ScreenHeight - 64), 
            Size = new Point(64, 64),
            Velocity = 200.0f
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    public static void DrawRectangle(Point v1, Point v2)
    {
        Raylib.DrawRectangleV
        (
            v1.ToVector2(), 
            v2.ToVector2(), 
            Raylib.ColorFromHSV(10.0f, 1.0f, 1.0f)
        );
    }

    /// <summary>
    /// Returns a new point with p1{x,y} added to p2{x,y}
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    public static Point AddPoints(Point p1, Point p2)
    {
        return new Point (p1.X + p2.X, p1.Y + p2.Y);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="p1"></param>
    public static Vector2 PointToVector(Point p1)
    {
        return CreateVector2(p1.X, p1.Y);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static IGameObject CreateEnemy()
    {
        var enemy = new EnemyGameObject
        {
            Position = new Point 
            (
                10, 10 
                //GenerateRandom(0, GameConfiguration.ScreenWidth),
                //GenerateRandom(0, GameConfiguration.ScreenHeight)
            ),
            Size = new Point (64,64)
        };

        return enemy;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static IGameObject CreateCoin()
    {
        var coin = new CoinGameObject
        {
            Position = new Point
            (
                GenerateRandom(0, GameConfiguration.ScreenWidth),
                GenerateRandom(0, GameConfiguration.ScreenHeight)
            )
        };

        return coin;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static float GenerateRandom(float min, float max)
    {
        double range = (double) max  - (double) min;
        double sample = RandomNumberGenerator.NextDouble();
        double scaled = (sample * range) + min;
        float f = (float) scaled;

        return f;
    }



    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static IGameObject CreateLevel()
    {
        var level = new LevelGameObject();        
        return level;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="direction"></param>
    /// <returns></returns>
    public static IGameObject CreateBullet(float x, float y, float direction)
    {
        var go = new BulletGameObject
        {
            Position = new Point(x,y),
            Size = new Point (30,30),
            Direction = direction
        };

        return go;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static IGameObject CreateExplosion (float x, float y)
    {
        var i = new CircleGameObject
        {
            ID = GenerateID(), 
            Position = new Point (x, y),
            Size = new Point(50,50), 
            Color = Color.White,
            Behaviors = new List<IBehavior>
            {
                new ColorBehavior { ColorIndex = 360, Velocity = 100000},
                new PulsateBehavior { Min = 50, Max = 200},
                new LifeSpanBehavior { Age=0, LifeSpanInSeconds = 3}
            }
        };

        return i;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static uint GenerateID()
    {
        GameConfiguration.CurrentObjectID += 1;

        return GameConfiguration.CurrentObjectID;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="X"></param>
    /// <returns></returns>
    public static float Sin(float X)
    {
        double d= X;
        return (float)Math.Sin(d); 
    }


    /// <summary>
    /// 
    /// 
    /// </summary>
    /// <param name="X"></param>
    /// <returns></returns>
    public static float Cos(float X)
    {
        double d = X;
        return (float)Math.Cos(d);
    }

    /// <summary>
    /// 
    /// 
    /// </summary>
    /// <param name="X"></param>
    /// <returns></returns>
    public static float Tan(float X)
    {
        double d = X;
        return (float)Math.Cos(d);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static float GetDelta()
    {
        return Raylib.GetFrameTime();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static Vector2 CreateVector2(float x, float y)
    {
        return new Vector2(x,y);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="p1"></param>
    /// <returns></returns>
    public static Vector2 CreateVector2(Point p1)
    {
        return new Vector2(p1.X , p1.Y);
    }

    //
    //
    // 
    public static void RemoveGameObject(IGameObject i)
    {
        GameConfiguration.GameObjectList.Remove(i);
    }

    //
    //
    //
    public static Path CreatePath(params Point[] points)
    {
        return new Path {Points = points};
    }

    //
    //
    //
    public static void DrawPath(params Vector2[] points)
    {
        for(var i = 1; i < points.Length; i++)
        {
            Raylib.DrawLineEx(points[i - 1], points[i], 10, Color.Black);
        }
    }

    //
    // Clamp function
    //
    public static float Clamp(float value, float min, float max)
    {
        return Math.Clamp(value, min, max);

    }
}