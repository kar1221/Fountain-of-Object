namespace The_Fountain_of_Object.GUI;


public class Menu
{
    private readonly string[] _options;
    private int _selectedIndex;

    public Menu(string[] options) => _options = options;
    
    private void ShowMenu()
    {
        var arrayLength = _options.Length;

        for (var x = 0; x < arrayLength; x++)
        {
            if(x == _selectedIndex) Console.Write("> ");
            Console.WriteLine($"{x+1}. {_options[x]}");
        }
    }

    public string RunGui()
    {
        var optionsLength = _options.Length;
        ConsoleKeyInfo keyInfo;
        do
        {
            Console.Clear();
            ShowMenu();
            keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.DownArrow:
                    if (_selectedIndex < optionsLength - 1) _selectedIndex++;
                    break;
                case ConsoleKey.UpArrow:
                    if (_selectedIndex > 0) _selectedIndex--;
                    break;
            }
        } while (keyInfo.Key != ConsoleKey.Enter);

        return _options[_selectedIndex];
    }
    
    
}