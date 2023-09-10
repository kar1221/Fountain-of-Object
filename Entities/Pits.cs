using The_Fountain_of_Object.Levels;

namespace The_Fountain_of_Object.Entities;

public class Pits : Entity
{
    public Pits(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public override void NearbyEvent(Player player, Level level)
    {
        if (player.PlayerWon) return;
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("You feel a draft. There is a pit in a nearby room.");
        Console.ResetColor();
    }

    public override void CollisionEvent(Player player, Level level)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("You've fallen into a pit that's too deep for you to climb out using just your bare hands.");
        Console.WriteLine("You have no food alongside with you.");
        Console.WriteLine("You starved to death.");
        player.IsAlive = false;
        Console.ResetColor();
    }
}