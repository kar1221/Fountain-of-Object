using The_Fountain_of_Object.Builder;
using The_Fountain_of_Object.Entities;

namespace The_Fountain_of_Object.Levels;

/*
 * For polymorphism purpose, so its children can be declared using Level instead of its own class.
 */
public abstract class Level
{
    public Entity[]? Entities;
    protected RoomBuilder? Builder;
    public int Rows { get; private set; }
    public int Columns { get; private set; }

    protected void SetRoomSize(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
    }
}