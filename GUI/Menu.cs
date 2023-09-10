namespace The_Fountain_of_Object.GUI;

public class Menu
{
    private readonly string[] _options;
    private int _selectedIndex;
    private readonly int _lengthOfOptions;

    public Menu(string[] options)
    {
        _options = options;
        _lengthOfOptions = options.Length;
    }

    private void PrintMenu()
    {
        for (var x = 0; x < _options.Length; x++)
        {
            if (_selectedIndex == x)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{x+1} -- {_options[x]}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"{x+1} -- {_options[x]}");
            }
        }
    }

    public int GetUserChoice()
    {
        ConsoleKeyInfo consoleKeyInfo;
        do
        {
            Console.Clear();
            PrintMenu();
            consoleKeyInfo = Console.ReadKey();

            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (_selectedIndex > 0)
                        _selectedIndex--;
                    break;
                case ConsoleKey.DownArrow:
                    if (_selectedIndex < _lengthOfOptions - 1)
                        _selectedIndex++;
                    break;
            }
            
        } while (consoleKeyInfo.Key != ConsoleKey.Enter);

        return _selectedIndex;

    }
}