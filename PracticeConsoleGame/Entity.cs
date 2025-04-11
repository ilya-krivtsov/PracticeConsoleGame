using System.Security.Cryptography.X509Certificates;

namespace PracticeConsoleGame;

public class Entity(Map map)
{
    public Map Map { get; } = map;

    public virtual void Move()
    {
    }
}
