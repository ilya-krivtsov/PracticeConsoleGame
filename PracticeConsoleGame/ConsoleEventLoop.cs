namespace PracticeConsoleGame;

public class ConsoleEventLoop : EventLoop
{
    public override void Run()
    {
        while (true)
        {
            var key = Console.ReadKey(true);
            HandleKeyPress(key.Key);
        }
    }

    public void HandleKeyPress(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.LeftArrow:
            case ConsoleKey.A:
                OnLeftKey();
                break;

            case ConsoleKey.RightArrow:
            case ConsoleKey.D:
                OnRightKey();
                break;

            case ConsoleKey.UpArrow:
            case ConsoleKey.W:
                OnUpKey();
                break;

            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                OnDownKey();
                break;
        }
    }
}
