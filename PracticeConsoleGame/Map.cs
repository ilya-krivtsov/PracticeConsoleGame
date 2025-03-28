namespace PracticeConsoleGame;

public class Map
{

    public const int Height = 256;
    public const int Width = 256;
    public char[,] Grid { get; } = new char[Height, Width];
    public int PlayerX { get; set; }
    public int PlayerY { get; set; }
    public Map(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        for (int y = 0; y < Height && y < lines.Length; y++)
        {
            var line = lines[y];
            for (int x = 0; x < Width && x < line.Length; x++)
            {
                char c = line[x];
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
    if (x < 0 || x >= Width || y < 0 || y >= Height)
    {
        return false;
    }

    return Grid[y, x] == '#';
    }
}
