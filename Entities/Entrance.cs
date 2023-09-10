using The_Fountain_of_Object.Levels;

namespace The_Fountain_of_Object.Entities;

public class Entrance : Entity
{

    public Entrance(int row, int column)
    {
        Row = row;
        Column = column;
    }
    
    public override void CollisionEvent(Player player, Level level)
    {
        Console.WriteLine("You see light coming from the cavern entrance.");

        if (!player.IsEscapable) return;
        
        player.PlayerWon = true;
        Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
        Console.WriteLine("You Won!");
    }
}