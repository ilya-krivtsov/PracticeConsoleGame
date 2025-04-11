namespace PracticeConsoleGame;

public class Game
{
    public Map Map { get; }
    private GameRenderer renderer;

    public Player Player { get; }

    private readonly List<Entity> entities = [];

    public Game(EventLoop loop, Map map)
    {
        Map = map;
        renderer = new(this);
        renderer.Redraw();

        Player = new(map);
        entities.Add(Player);
        Player.X = map.PlayerStartX;
        Player.Y = map.PlayerStartY;
        map.Entities[Player.X, Player.Y] = Player;

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

        renderer.Redraw();
    }
}
