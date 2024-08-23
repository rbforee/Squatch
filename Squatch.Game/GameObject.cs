using Raylib_cs;

namespace Squatch.Game;

public class GameObject
{
    public int x {get;set;}
    public int y {get;set;}
    public Color color {get;set;}
    public int radius {get;set;}
 
    public int stateX {get;set;} = 1;
    public int stateY {get;set;} = 1;
    public int velocity {get;set;} = 1;
 
    public int range {get;set;} = 30;

    public int startX{get;set;}
    public int startY{get;set;}

    public void Update()
    {
        x = x + (velocity * stateX);

        if (x > (startX + range) || x < (startX - range)) 
        {
            stateX = stateX * -1;
        }

        y = y + (velocity * stateY);

        if (y > (startY + range) || y < (startY - range)) 
        {
            stateY = stateY * -1;
        }


    }
}