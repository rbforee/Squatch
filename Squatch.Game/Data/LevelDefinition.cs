namespace Squatch.Game.Data;

public class LevelDefinition
{
    public int TileMapHeight {get;set;}
    public int TileMapWidth {get;set;}

    public int TileWidth {get;set;}
    public int TileHeight {get;set;}
    
    public IList<string> TileAssets {get;set;}
    public IList<int> TileMap{get;set;}
}