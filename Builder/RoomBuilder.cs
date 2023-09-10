using The_Fountain_of_Object.Entities;
using The_Fountain_of_Object.Levels;

namespace The_Fountain_of_Object.Builder;

public class RoomBuilder
{
    private readonly Entity[] _entities;
    private readonly int _rows;
    private readonly int _columns;
    private int _index;
    
    /*
     * Usage: new RoomBuilder({Entities amount in this level});
     */
    public RoomBuilder(int entitiesAmount, Level level)
    {
        _entities = new Entity[entitiesAmount];
        
        for (int i = 0; i < entitiesAmount; i++)
            _entities[i] = new Blank();
        
        _rows = level.Rows;
        _columns = level.Columns;
    }
    
    /*
     * Add entities into the _entities array when the array is not full.
     */
    public void AddEntity(Entity entity)
    {
        if (_index >= _entities.Length) return;

        if (entity.Row >= _rows || entity.Column >= _columns)
            throw new Exception("Entity out of bound.");
        
        if (IsOverlapping(entity))
            throw new Exception("Entity overlaps with another entity.");
        
        
        _entities[_index] = entity;
        _index++;
    }
    
    /*
     * My code is so messy ⊙﹏⊙∥
     *
     * Iterate through _entities array and check if the entity is overlapping with another entity by checking if their
     * Row and Column are the same.
     *
     * But since it Player and Entrance must be overlapping, otherwise how would player get out of this place.
     * So Player and Entrance must be excluded in this check.
     *
     * I added Blank as an entity because otherwise _entities will be an array with null elements before I add entity in
     * it, and either foreach and LINQ will throw an error because it is null, so Blank entity need to be excluded
     * as well.
     */
    private bool IsOverlapping(Entity entity)
    {
        var isOverlappingObject = _entities.Any(existingEntity =>
            entity.Row == existingEntity.Row &&
            entity.Column == existingEntity.Column &&
            existingEntity is not (Entrance or Player or Blank)); // Exclusion of those three Entity.

        return isOverlappingObject;
    }

    public Entity[] ReturnLayout() => _entities;
    

}