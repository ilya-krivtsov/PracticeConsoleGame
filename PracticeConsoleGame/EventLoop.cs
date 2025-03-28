namespace PracticeConsoleGame;

public class EventLoop
{
    public event Action LeftKeyPress = () => { };
    public event Action RightKeyPress = () => { };
    public event Action UpKeyPress = () => { };
    public event Action DownKeyPress = () => { };

    public void Run()
    {
        while (true)
        {
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    LeftKeyPress();
                    break;

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    RightKeyPress();
                    break;

                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    UpKeyPress();
                    break;

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    DownKeyPress();
                    break;
            }
        }
    }
}
