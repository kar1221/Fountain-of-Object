# Level Template
```
using The_Fountain_of_Object.Builder;  
using The_Fountain_of_Object.Entities;  
  
namespace The_Fountain_of_Object.Levels;  
  
public class {LevelName} : Level  
{     
    public {LevelName}()  
    {  
        /* Set the level border size. */  
        SetRoomSize(Rows, Columns);  
          
          
		    /* Add Entities to the level below. */
 
		    Builder = new RoomBuilder({Entities amount in this room}, this);  
        Builder.AddEntity(new Entity(Row,Column));
        
        /* -------------------------------- */  
        
		    Entities = Builder?.ReturnLayout();  
    }  
  
}
```
