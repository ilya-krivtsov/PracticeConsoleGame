namespace PracticeConsoleGame;

public class EventLoop
{
    private readonly Dictionary<ConsoleKey, Action> keyLookup;

    public event Action LeftKeyPress = () => { };
    public event Action RightKeyPress = () => { };
    public event Action UpKeyPress = () => { };
    public event Action DownKeyPress = () => { };

    public EventLoop()
    {
        keyLookup = new()
        {
            [ConsoleKey.LeftArrow] = LeftKeyPress,
            [ConsoleKey.A] = LeftKeyPress,

            [ConsoleKey.RightArrow] = RightKeyPress,
            [ConsoleKey.D] = RightKeyPress,

            [ConsoleKey.UpArrow] = UpKeyPress,
            [ConsoleKey.W] = UpKeyPress,

            [ConsoleKey.DownArrow] = DownKeyPress,
            [ConsoleKey.S] = DownKeyPress,
        };
    }

    public void Run()
    {
        while (true)
        {
            var key = Console.ReadKey(true);
            if (keyLookup.TryGetValue(key.Key, out var action))
            {
                action();
            }
        }
    }
}
