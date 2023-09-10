using The_Fountain_of_Object.Levels;

namespace The_Fountain_of_Object.Entities;

public class Fountain : Entity
{
    private bool IsActivated { get; set; }
    private bool IsAccessible { get; set; }
    
    public Fountain(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public void EnableFountain(Player player)
    {
        if (!IsAccessible) return;
        
        IsActivated = true;
        player.IsEscapable = true;
    }

    public override void CollisionEvent(Player player, Level level)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        IsAccessible = player.IsCollided(this);
        Console.WriteLine(IsActivated
            ? "You hear the rushing waters from the Fountain of Objects. It has been reactivated!"
            : "You hear water dripping in this room. The Fountain of Objects is here!");
        Console.ResetColor();
    }



}