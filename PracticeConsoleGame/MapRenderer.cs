namespace PracticeConsoleGame;

public class MapRenderer
{
    private Map _map;
    private int _lastPlayerX;
    private int _lastPlayerY;

    private bool _firstDraw;

    public MapRenderer(Map map)
    {
        _map = map;

        _lastPlayerX = map.PlayerX;
        _lastPlayerY = map.PlayerY;

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
        for (int y = 0; y <= _map.Height; ++y)
        {
            Console.SetCursorPosition(0, y);
            for (int x = 0; x <= _map.Width; ++x)
            {
                Console.Write(_map.GetTile(x, y) ? '#' : ' ');
            }
            Console.WriteLine();
        }
    }

    public void RedrowPlayer()
    {
        Console.SetCursorPosition(_lastPlayerX, _lastPlayerY);
        Console.Write(' ');

        Console.SetCursorPosition(_map.PlayerX, _map.PlayerY);
        Console.Write('@');

        _lastPlayerX = _map.PlayerX;
        _lastPlayerY = _map.PlayerY;
    }
}
