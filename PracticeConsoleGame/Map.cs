namespace PracticeConsoleGame;

public class Map
{

    public const int MaxHeight = 256;
    public const int MaxWidth = 256;

    public char[,] Grid { get; } = new char[MaxHeight, MaxWidth];
    public int PlayerX { get; set; }
    public int PlayerY { get; set; }

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

                if (c == '#' || c == '@')
                {
                    Width = Math.Max(Width, x);
                    Height = Math.Max(Height, y);
                }

                Grid[y, x] = c;

                if (c == '@')
                {
                    PlayerX = x;
                    PlayerY = y;
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

        return Grid[y, x] == '#';
    }
}
