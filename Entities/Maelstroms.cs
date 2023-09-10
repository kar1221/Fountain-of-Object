using The_Fountain_of_Object.Levels;
using The_Fountain_of_Object.Location;

namespace The_Fountain_of_Object.Entities;

public class Maelstroms : Entity
{
    public Maelstroms(int row, int column)
    {
        Row = row;
        Column = column;
    }
    

    public override void NearbyEvent(Player player, Level level)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("You hear the growling and groaning of a maelstrom nearby.");
        Console.ResetColor();
    }

    public override void CollisionEvent(Player player, Level level)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("You are being sucked into the maelstroms, which pushed you to move 1 space North and two space east.");
        Console.ResetColor();
        player.Move(Direction.North, 1);
        player.Move(Direction.East, 2);
        Move(Direction.South, 1);
        Move(Direction.West, 2);
    }
    
    private void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                Row--;
                break;
            case Direction.South:
                Row++;
                break;
            case Direction.East:
                Column++;
                break;
            case Direction.West:
                Column--;
                break;
            default: 
                Console.WriteLine("Invalid direction!");
                break;
        }
    }

    private void Move(Direction direction, int times)
    {
        if (times < 0) return;
        for (var x = 0; x < times; x++)
        {
            Move(direction);
        }
    }
}