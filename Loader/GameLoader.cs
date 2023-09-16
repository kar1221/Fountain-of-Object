using The_Fountain_of_Object.Entities;
using The_Fountain_of_Object.GUI;
using The_Fountain_of_Object.Levels;
using The_Fountain_of_Object.Location;

namespace The_Fountain_of_Object.Loader;

public class GameLoader
{
    private readonly Player _player;
    private readonly Fountain _fountain;
    private readonly Level _level;
    
    /*
     * Get level instance from user and execute initialization.
     */
    public GameLoader(Level level)
    {
        _level = level;
        if (_level == null) throw new Exception("Level not found");
        _player = GetInstance<Player>(_level) ?? throw new NullReferenceException("Player cannot be null");
        _fountain = GetInstance<Fountain>(_level) ?? throw new NullReferenceException("Fountain cannot be null");
    }
    
    /*
     * After the level is initialized, run the game.
     */
    public Status Run()
    {
        var gameplayGui = new GameplayGui(_level.Rows, _level.Columns);
        
        CollisionEvent();
        NearbyEvent();
        
        while (true)
        {
            gameplayGui.ShowBoard(_player.Row, _player.Column);
            
            
            
            // Show bullets count
            Console.WriteLine(_player);
            
            /*
             * Since player.PlayerWon is changed in CollisionEvent, we need to move the winning condition check to here
             * otherwise the player will be asked to enter a command again even though they have already won the game.
             */
            if (_player.PlayerWon) return Status.LevelFinished;
            if (!_player.IsAlive) return Status.Failed;
            
            
            PlayerCommand(Console.ReadKey(true));
            
            
            /*
             * Check events after user has made their move.
             */
            NearbyEvent();
            CollisionEvent();
            
            /*
             * Perform out of bound check to ensure everything is in the board.
             */
            OutOfBoundCheck();
            
        }
        

    }
    
    /*
     * Receive command from user and run it.
     */
    private void PlayerCommand(ConsoleKeyInfo keyInfo)
    {
        /*
         * Another evidence to prove my code is really messy.
         * Move Console.Clear(); here so that the console is able to show Shoot(),  NearbyEvent(), CollisionEvent()'s
         * message as well.
         */
        Console.Clear();
        
        /*
         * Add or remove command here.
         */
        /* ----------------------------------------------------- */
        var commandActions = new Dictionary<ConsoleKey, Action>
        {
            { ConsoleKey.DownArrow, () => _player.Move(Direction.South) },
            { ConsoleKey.UpArrow, () => _player.Move(Direction.North) },
            { ConsoleKey.RightArrow, () => _player.Move(Direction.East) },
            { ConsoleKey.LeftArrow, () => _player.Move(Direction.West) },
            { ConsoleKey.E, () => _fountain.EnableFountain(_player) },
            { ConsoleKey.W, () => Shoot(Direction.North) },
            { ConsoleKey.A, () => Shoot(Direction.West) },
            { ConsoleKey.S, () => Shoot(Direction.South) },
            { ConsoleKey.D, () => Shoot(Direction.East) },
        };
        /* ----------------------------------------------------- */
        
        if (commandActions.TryGetValue(keyInfo.Key, out var action))
            action?.Invoke();
        else
            Console.WriteLine("Invalid command.");
        

    }
    
    /*
     * Iterate through the level.entities array and return the instance if it is of type T.
     * Otherwise return null.
     * Only works on single entity.
     */
    private static T? GetInstance<T>(Level level) where T : Entity
    {
        if (level.Entities == null) return null;
        
        foreach (var entity in level.Entities)
        {
            if (entity is T instance)
                return instance;
        }
        
        return null;
    }
    
    /*
     * Iterate through the level.Entities array and return a List of Entity instance found in level.Entities array.
     */
    private static List<T>? GetInstances<T>(Level level) where T : Entity
    {
        var entities = new List<T>();

        if (level.Entities == null) return null;

        foreach (var entity in level.Entities)
        {
            if (entity is T instance)
                entities.Add(instance);
        }

        return entities;
    }
    
    /*
     * Iterate through the _level.Entities array and call NearbyEvent() if the entity is nearby the player.
     */
    private void NearbyEvent()  
    {
        foreach(var entity in _level.Entities!)
            if (entity.IsNearby(_player)) entity.NearbyEvent(_player, _level);
    }
    
    /*
     * Iterate through the _level.Entities array and call CollisionEvent() if the entity is collided with the player.
     */
    private void CollisionEvent()
    {
        foreach(var entity in _level.Entities!)
            if (entity.IsCollided(_player)) entity.CollisionEvent(_player, _level);
    }
    
    /*
     * If there are any entities in the level move out of the map, execute the OutOfBoundEvent() method.
     */
    private void OutOfBoundCheck()
    {
        foreach(var entity in _level.Entities!)
            if(entity.IsOutOfBound(_level)) entity.OutOfBoundEvent();
    }

    private void Shoot(Direction direction)
    {
        var amaroks = GetInstances<Amarok>(_level);

        if (amaroks == null) return;
        
        _player.Shoot(direction, amaroks);
    }
}