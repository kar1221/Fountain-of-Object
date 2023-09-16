using The_Fountain_of_Object.Builder;
using The_Fountain_of_Object.Entities;

namespace The_Fountain_of_Object.Levels;

public class LevelMedium : Level
{   
    public LevelMedium()
    {
        /*
         * Set the level border size.
         */
        SetRoomSize(6, 6);
        
        /*
         * Add Entities to the level.
         */
        /* ----------------------------------------------------------------- */
        Builder = new RoomBuilder(9, this);
        
        Builder.AddEntity(new Entrance(3,2));
        Builder.AddEntity(new Player(3,2, 4));
        
        
        Builder.AddEntity(new Pits(4, 3));
        Builder.AddEntity(new Pits(1, 5));
        
        Builder.AddEntity(new Amarok(0, 3));
        Builder.AddEntity(new Amarok(2, 4));
        
        Builder.AddEntity(new Maelstroms(3, 1));
        Builder.AddEntity(new Maelstroms(3, 3));
        
        Builder.AddEntity(new Fountain(1,4));
        /* ----------------------------------------------------------------- */
        
        Entities = Builder?.ReturnLayout();
    }

}