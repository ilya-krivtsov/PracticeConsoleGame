namespace PracticeConsoleGame;

public class GameRenderer
{
    private Game game;
    private int _lastPlayerX;
    private int _lastPlayerY;

    private bool _firstDraw;

    public GameRenderer(Game game)
    {
        this.game = game;

        _lastPlayerX = game.Player.X;
        _lastPlayerY = game.Player.Y;

        _firstDraw = true;
    }

    public void Redraw()
    {
        if (_firstDraw)
        {
            Console.Clear();
            DrawMap();
            _firstDraw = false;
        }
        RedrowPlayer();
    }

    public void DrawMap()
    {
        for (int y = 0; y <= game.Map.Height; ++y)
        {
            Console.SetCursorPosition(0, y);
            for (int x = 0; x <= game.Map.Width; ++x)
            {
                Console.Write(game.Map.GetTile(x, y) ? '#' : ' ');
            }
            Console.WriteLine();
        }
    }

    public void RedrowPlayer()
    {
        Console.SetCursorPosition(_lastPlayerX, _lastPlayerY);
        Console.Write(' ');

        Console.SetCursorPosition(game.Player.X, game.Player.X);
        Console.Write('@');

        _lastPlayerX = game.Player.X;
        _lastPlayerY = game.Player.Y;
    }
}
