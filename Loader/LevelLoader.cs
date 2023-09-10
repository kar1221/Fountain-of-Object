using The_Fountain_of_Object.Levels;
using System.Reflection;

namespace The_Fountain_of_Object.Loader;

public static class LevelLoader
{
    public static Level LoadLevel(string className)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var type = assembly.GetTypes()
            .First(t => t.Name == className);
        
        if (type == null) throw new Exception("Level not found");

        return (Activator.CreateInstance(type) as Level)!;
    }
}

