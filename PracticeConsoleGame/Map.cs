namespace PracticeConsoleGame;

public class Map
{
    public const int MaxHeight = 256;
    public const int MaxWidth = 256;

    public char[,] Grid { get; } = new char[MaxWidth, MaxHeight];
    public int PlayerStartX { get; }
    public int PlayerStartY { get; }

    public Entity?[,] Entities { get; } = new Entity?[MaxWidth, MaxHeight];

    public int Width { get; private set; }
    public int Height { get; private set; }

    public Map(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        for (int y = 0; y < MaxHeight && y < lines.Length; y++)
        {
            var line = lines[y];
            for (int x = 0; x < MaxWidth && x < line.Length; x++)
            {
                char c = line[x];

                if (c == '#' || c == '@' || c == 'M')
                {
                    Width = Math.Max(Width, x);
                    Height = Math.Max(Height, y);
                }

                Grid[x, y] = c;

                if (c == '@')
                {
                    PlayerStartX = x;
                    PlayerStartY = y;
                }
            }
        }
    }

    public bool GetTile(int x, int y)
    {
        if (x < 0 || x >= MaxWidth || y < 0 || y >= MaxHeight)
        {
            return false;
        }

        return Grid[x, y] == '#';
    }
}
