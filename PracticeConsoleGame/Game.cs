namespace PracticeConsoleGame;

public class Game
{
    private Map map;
    private MapRenderer renderer;

    private Player player;

    private readonly List<Entity> entities = [];

    public Game(EventLoop loop, Map map)
    {
        this.map = map;
        renderer = new(map);
        renderer.Redraw();

        player = new(map);
        entities.Add(player);

        loop.LeftKeyPress += () => Move(-1, 0);
        loop.RightKeyPress += () => Move(1, 0);
        loop.UpKeyPress += () => Move(0, -1);
        loop.DownKeyPress += () => Move(0, 1);
    }

    private void Move(int dx, int dy)
    {
        player.Move(dx, dy);

        foreach (var entity in entities)
        {
            entity.Move();
        }

        renderer.Redraw();
    }
}
