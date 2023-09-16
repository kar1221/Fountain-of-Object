using The_Fountain_of_Object.Builder;
using The_Fountain_of_Object.Entities;

namespace The_Fountain_of_Object.Levels;

public class LevelLarge : Level
{   
    public LevelLarge()
    {
        /*
         * Set the level border size.
         */
        SetRoomSize(8, 8);
        
        /*
         * Add Entities to the level.
         */
        /* ----------------------------------------------------------------- */
        Builder = new RoomBuilder(12, this);
        
        Builder.AddEntity(new Entrance(1,1));
        Builder.AddEntity(new Player(1,1, 6));
        
        
        Builder.AddEntity(new Pits(1, 5));
        Builder.AddEntity(new Pits(5, 6));
        Builder.AddEntity(new Pits(6, 5));
        
        Builder.AddEntity(new Amarok(4, 5));
        Builder.AddEntity(new Amarok(5, 4));
        Builder.AddEntity(new Amarok(3, 4));
        
        Builder.AddEntity(new Maelstroms(2, 2));
        Builder.AddEntity(new Maelstroms(4, 1));
        Builder.AddEntity(new Maelstroms(7, 2));
        
        Builder.AddEntity(new Fountain(5,5));
        /* ----------------------------------------------------------------- */
        
        Entities = Builder?.ReturnLayout();
    }

}