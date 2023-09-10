using The_Fountain_of_Object.Levels;

namespace The_Fountain_of_Object.Entities;

public class Amarok : Entity
{
    public bool IsAlive = true;
    
    public Amarok(int row, int column)
    {
        Row = row;
        Column = column;
    }
    
    public override void NearbyEvent(Player player, Level level)
    {
        if (IsAlive == false) return;
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("You can smell the rotten stench of an amarok in a nearby room.");
        Console.ResetColor();
    }

    public override void CollisionEvent(Player player, Level level)
    {
        if (IsAlive == false) return;
        
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Suddenly, you are attacked by an amarok from the behind, you accidentally dropped your weapon.");
        Console.WriteLine("Your are not as strong as the amarok.");
        Console.WriteLine("You died, eaten by the amarok mercilessly.");
        player.IsAlive = false;
        Console.ResetColor();
    }
    
}