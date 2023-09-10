using The_Fountain_of_Object.Loader;

/*
 * Code is messy, dont read if you are allergic to messy code.
 */


/*
 * Have no time to complete the gui part. Maybe I will finish it one day.
 */
var levelOne = LevelLoader.LoadLevel("LevelSmall");
var gameLoader = new GameLoader(levelOne);
gameLoader.Run();
Console.ReadKey();

    
    