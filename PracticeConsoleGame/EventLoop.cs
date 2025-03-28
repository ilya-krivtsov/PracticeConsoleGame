namespace PracticeConsoleGame;

public class EventLoop
{
    public event Action? LeftKeyPress;
    public event Action? RightKeyPress;
    public event Action? UpKeyPress;
    public event Action? DownKeyPress;

    public EventLoop()
    {

    }
}
