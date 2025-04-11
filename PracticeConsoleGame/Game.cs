namespace PracticeConsoleGame;

public class Game
{
    public Map Map { get; }

    public Player Player { get; }

    public event Action OnPlayerMove = () => { };

    private readonly List<Entity> entities = [];

    public Game(EventLoop loop, Map map)
    {
        Map = map;

        Player = new(this);
        entities.Add(Player);
        Player.X = map.PlayerStartX;
        Player.Y = map.PlayerStartY;
        map.Entities[Player.X, Player.Y] = Player;

        for (int y = 0; y <= map.Height; ++y)
        {
            for (int x = 0; x <= map.Width; ++x)
            {
                if (map.Grid[x, y] == 'M')
                {
                    var enemy = new Enemy(this)
                    {
                        X = x,
                        Y = y
                    };
                    map.Entities[x, y] = enemy;
                    entities.Add(enemy);
                }
            }
        }

        loop.LeftKeyPress += () => Move(-1, 0);
        loop.RightKeyPress += () => Move(1, 0);
        loop.UpKeyPress += () => Move(0, -1);
        loop.DownKeyPress += () => Move(0, 1);
    }

    private void Move(int dx, int dy)
    {
        Player.Move(dx, dy);

        foreach (var entity in entities)
        {
            entity.Move();
        }

        OnPlayerMove();
    }
}
