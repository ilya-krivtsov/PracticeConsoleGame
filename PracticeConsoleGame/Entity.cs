namespace PracticeConsoleGame;

public class Entity(Map map)
{
    public Map Map { get; } = map;

    public int X { get; set; }
    public int Y { get; set; }

    public virtual void Move()
    {
    }
}
