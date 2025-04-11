namespace PracticeConsoleGame;

public class Enemy(Game game) : Entity(game)
{
    public override void Move()
    {
        int px = Game.Player.X;
        int py = Game.Player.Y;

        int dist = 8;

        var (dx, dy) = (px - X, py - Y);
        if ((dx * dx) + (dy * dy) >= (dist * dist))
        {
            Span<(int, int)> dirs = [(-1, 0), (1, 0), (0, 1), (0, -1)];
            (int, int) direction = (0, 0);
            Random.Shared.GetItems(dirs, new Span<(int, int)>(ref direction));
            Move(direction.Item1, direction.Item2);
            return;
        }

        if (Math.Abs(dx) > Math.Abs(dy))
        {
            Move(Math.Sign(dx), 0);
        }
        else
        {
            Move(0, Math.Sign(dy));
        }
    }
}
