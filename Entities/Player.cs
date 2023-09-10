using The_Fountain_of_Object.Location;

namespace The_Fountain_of_Object.Entities;

/*
 * A four by four room.
 * 
 * O # X #   0   O => Player
 * # # # #   1   X => Fountain
 * # # # #   2   TotalRow = 4
 * # # # #   3   TotalColumn = 4
 * 
 * 0 1 2 3
 */

public class Player : Entity
{
    public int Bullets = 5;
    public bool IsAlive { get; set; } = true;
    public bool IsEscapable { get; set; }
    public bool PlayerWon { get; set; }
    public Player(int row, int column)
    {
        Row = row;
        Column = column;
    }
    
    public void Move(Direction direction)
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

    public void Move(Direction direction, int times)
    {
        if (times < 0) return;
        for (var x = 0; x < times; x++)
        {
            Move(direction);
        }
    }

    public override void OutOfBoundEvent()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("You crashed your head to the wall.");
        Console.ResetColor();
    }
    
    /*
     * I am out of idea when implementing this method.
     * Basically you need to use GetInstances method to get the list of amaroks instance, and pass it in this method.
     *
     * 
     */
    public void Shoot(Direction direction, List<Amarok> amaroks)
    {
        /*
         * Notify player when out of bullet.
         */
        if (Bullets < 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Out of bullet.");
            Console.ResetColor();
            return;
        }
        
        /*
         * Reduce the bullets by 1;
         */
        Bullets--;
        
        /*
         * Get player's current location first, and make changes base on the 'direction' parameter.
         */
        var targetRow = Row;
        var targetColumn = Column;
        
        switch (direction)
        {
            case Direction.North:
                targetRow--;
                break;
            case Direction.South:
                targetRow++;
                break;
            case Direction.West:
                targetColumn--;
                break;
            case Direction.East:
                targetColumn++;
                break;
            default:
                Console.WriteLine("Invalid direction for shooting.");
                break;
        }
        
        foreach (var amarok in amaroks)
        {
            /*
             * If any of them doesn't meet, it means that it is not the amarok we want to make contact with.
             */
            if (amarok.Row != targetRow || amarok.Column != targetColumn || !amarok.IsAlive) continue;
            
            amarok.IsAlive = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You shot an amarok!");
            Console.ResetColor();

            return;
        }
        
        Console.WriteLine("Nothing there.");
    }
    
    
    public override string ToString() => $"(Row={Row}, Column={Column})";
    
}

