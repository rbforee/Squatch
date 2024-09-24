using Raylib_cs;
using System.Numerics;
using Squatch.Game.Core;
using System.Text.Json;

namespace Squatch.Game.GameObjects;

public class LevelGameObject : BaseGameObject
{
    public Texture2D[] textures {get;set;}

    public Data.LevelDefinition lev {get;set;}

    public override void Init()
    {
        using (StreamReader r = new StreamReader("Assets//Level.json"))  
        {  
            string json = r.ReadToEnd();  
            lev = JsonSerializer.Deserialize<Data.LevelDefinition>(json);

            var tmp = new List<Texture2D> ();
            foreach(var t in lev.TileAssets)
            {
                tmp.Add(Raylib.LoadTexture(t));
            }

            textures = tmp.ToArray();  
        }  
    }

    public override void Draw()
    {
        for(var i = 0; i < lev.TileMapHeight * lev.TileMapWidth; i++)
        {
            Raylib.DrawTexture
            (
                textures[ lev.TileMap[i] ], 
                (i % lev.TileMapWidth) * lev.TileWidth,
                (i / lev.TileMapWidth) * lev.TileHeight,
                Color.White
            );
        }
    }

    //
    //
    //
    public override void Update()
    {

    }
}