using The_Fountain_of_Object.Loader;

namespace The_Fountain_of_Object.GUI;

public static class MainMenu
{
    private static readonly Menu Menu = new Menu(new[] { "Start", "Help", "Exit" });
    private static readonly string[] Levels = { "LevelSmall", "LevelMedium", "LevelLarge" };
    private static int _currentLevel;

    public static void RunMainMenu()
    {
        string selectedOption;
        do
        {
            selectedOption = Menu.RunGui();

            if (selectedOption == "Help") Help();
            if (selectedOption == "Exit") Exit();

        } while (selectedOption != "Start");

        Console.Clear();
        StartGame();
    }

    private static void Help()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("""
                          You enter the Cavern of Objects, a maze of rooms filled with dangerous pits
                          in search of the Fountain of Objects.
                          """);
        Console.WriteLine("Light is visible only in the entrance, and no other light is seen anywhere in the caverns.");
        Console.WriteLine("You must navigate the Caverns with your other senses.");
        Console.WriteLine("Find the Fountain of Objects, activate it, and return to the entrance.");
        Console.WriteLine(" --------------------------------------------------------------------- ");
        Console.WriteLine("Up => Move North by 1");
        Console.WriteLine("Down => Move South by 1");
        Console.WriteLine("Left => Move West by 1");
        Console.WriteLine("Down => Move East by 1");
        Console.WriteLine("E => Enable Fountain");
        Console.WriteLine("-------------------------------Weapon----------------------------------");
        Console.WriteLine("W => Shoot at North");
        Console.WriteLine("S => Shoot at South");
        Console.WriteLine("A => Shoot at West");
        Console.WriteLine("D => Shoot at East");
        Console.Write("Press any key to return...");
        Console.ResetColor();
        Console.ReadKey(true);

    }

    private static void Exit() => Environment.Exit(0);
    
    /*
     * Loader level from LevelLoader.LoadLevel() method and execute it in gameLoader.Run() method.
     * gameLoader will return Status enum type depends on player gameplay status.
     * If player won the game, ask them if they want to continue, if they do, add _currentLevel by 1 and repeat the loop.
     * If player lost the game, ask them if they want to continue, if they do, continue the loop.
     * The loop ends when _currentLevel is greater than _levels' length, which means that there are no level remaining. 
     */
    private static void StartGame()
    {
        do
        {
            Console.Clear();
            var level = LevelLoader.LoadLevel(Levels[_currentLevel]);
            var gameLoader = new GameLoader(level);
            var status = gameLoader.Run();
            

            switch (status)
            {
                case Status.Failed:
                    Console.WriteLine("Continue? (Y/N)...");
                    
                    if (!CheckIfContinue()) Exit();
                    
                    break;
                case Status.LevelFinished:
                    Console.WriteLine("Continue? (Y/N)...");
                    
                    if (!CheckIfContinue()) Exit();
                    
                    _currentLevel++;
                    break;
            }
        } while (_currentLevel < Levels.Length);
    }

    private static bool CheckIfContinue()
    {
            while (true) // Keep looping until valid input is received
            {
                var userOption = Console.ReadKey(true);
                if (userOption.Key == ConsoleKey.Y) return true;
                if (userOption.Key == ConsoleKey.N) Exit();
                
                Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
                
            }
    }
    
}