namespace MK;

public class GameModel
{
    // public event Action StateUpdated;
    public Player Player;
    // private List<Player> _players = new List<Player>();
    // private Dictionary<Directions, > _keyToDirection = new Dictionary<Keys, Directions>();

    public GameModel()
    {
        Player = new Player("img/jax", 200, 200);
    }

    public void MovePlayer(Directions direction)
    {
        if (direction == Directions.Right)
            Player.MoveRight();
        if (direction == Directions.Left)
            Player.MoveLeft();
        if (direction == Directions.Up)
            Player.MoveUp();
    }

    public void Update(ControllerData data)
    {
        MovePlayer(data.MoveDirection);
    }
}