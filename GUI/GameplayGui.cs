namespace The_Fountain_of_Object.GUI;

public class GameplayGui
{
    private readonly int _roomRow;
    private readonly int _roomColumn;

    public GameplayGui(int row, int column)
    {
        _roomRow = row;
        _roomColumn = column;
    }

    public void ShowBoard(int playerRow, int playerColumn)
    {
        Console.ForegroundColor = ConsoleColor.White;
        for (var row = 0; row < _roomRow + 2; row++)
        {
            for (var col = 0; col < _roomColumn + 2; col++)
            {
                if (row == 0 || row == _roomRow + 1 || col == 0 || col == _roomColumn + 1)
                    Console.Write("* ");
                else if (row == playerRow + 1 && col == playerColumn + 1)
                    Console.Write("# ");
                else
                    Console.Write("  ");
            }

            Console.WriteLine();
        }
        
        Console.ResetColor();
    }
    
}