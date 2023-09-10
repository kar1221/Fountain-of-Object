using The_Fountain_of_Object.Builder;
using The_Fountain_of_Object.Entities;

namespace The_Fountain_of_Object.Levels;

public class LevelSmall : Level
{   
    public LevelSmall()
    {
        /*
         * Set the level border size.
         */
        SetRoomSize(4, 4);
        
        /*
         * Add Entities to the level.
         */
        /* ----------------------------------------------------------------- */
        Builder = new RoomBuilder(6, this);
        
        Builder.AddEntity(new Entrance(0,0));
        Builder.AddEntity(new Player(0,0));
        
        
        Builder.AddEntity(new Pits(0, 1));
        Builder.AddEntity(new Amarok(1, 1));
        
        Builder.AddEntity(new Maelstroms(2, 2));
        Builder.AddEntity(new Fountain(3,3));
        /* ----------------------------------------------------------------- */
        
        Entities = Builder?.ReturnLayout();
    }

}