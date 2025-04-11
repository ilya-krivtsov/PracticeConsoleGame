namespace PracticeConsoleGame;

public abstract class EventLoop
{
    public event Action LeftKeyPress = () => { };
    public event Action RightKeyPress = () => { };
    public event Action UpKeyPress = () => { };
    public event Action DownKeyPress = () => { };

    public abstract void Run();

    protected void OnLeftKey() => LeftKeyPress();
    protected void OnRightKey() => RightKeyPress();
    protected void OnUpKey() => UpKeyPress();
    protected void OnDownKey() => DownKeyPress();
}
