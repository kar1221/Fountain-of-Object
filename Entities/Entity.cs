using The_Fountain_of_Object.Levels;
using The_Fountain_of_Object.Location;

namespace The_Fountain_of_Object.Entities;

/*
 * Just for inheritance purpose, it shall not be instantiated.
 */
public class Entity
{
    public int Column { get; protected set; }
    public int Row { get; protected set; }
    
    protected Entity()
    {
     
    }
    
    /*
     * Return the row or column difference between two entities
     */
    private int RowDifference(Entity entity) => int.Abs(entity.Row - this.Row);
    private int ColumnDifference(Entity entity) => int.Abs(entity.Column - this.Column);
    
    /*
     * When it is said to be collided, two entities' row and column difference must be 0.
     */
    public bool IsCollided(Entity entity) => ColumnDifference(entity) == 0 && RowDifference(entity) == 0;
    
    /*
     * When it is said to be nearby, the entity is adjacent to the player.
     * Two circumstances can be seen:
     * - deltaCol = 1, deltaRow = 0
     * - deltaCol = 1, deltaRow = 1
     * - deltaCol = 0, deltaRow = 1
     * - While the sum of them cannot be 0, as it is consider as collision.
     * 
     * The detection range is shown like this:
     * # # # # # # #
     * # # X X X # #
     * # # X O X # #
     * # # X X X # #
     * # # # # # # #
     */
    public bool IsNearby(Entity entity)
    {
        var rowDifference = RowDifference(entity);
        var columnDifference = ColumnDifference(entity);

        switch (rowDifference)
        {
            case 1 when columnDifference == 0:
            case 1 when columnDifference == 1:
            case 0 when columnDifference == 1:
                return true;
            default:
                return false;
        }
    }
    
    /*
     * If entity is outside of the map, execute this.
     */
    public virtual void OutOfBoundEvent()
    {
        
    }
    
    /*
     * Check if entity is outside of the map, if it is, move them back to the map and return true.
     */
    public bool IsOutOfBound(Level level)
    {
        var outOfBound = false;

        if (Row < 0)
        {
            Row = 0;
            outOfBound = true;
        }
        
        if (Row >= level.Rows)
        {
            Row = level.Rows - 1;
            outOfBound = true;
        }
        
        if (Column < 0)
        {
            Column = 0;
            outOfBound = true;
        }
        
        if (Column >= level.Columns)
        {
            Column = level.Columns - 1;
            outOfBound = true;
        }

        return outOfBound;
    }

    public virtual void CollisionEvent(Player player, Level level)
    {
    }

    public virtual void NearbyEvent(Player player, Level level)
    {
        
    }


}