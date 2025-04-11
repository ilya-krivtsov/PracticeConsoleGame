using PracticeConsoleGame;
using System.Diagnostics;
namespace WinFormsGame;

public partial class Form1 : Form
{
    private Game game;

    private FormEventLoop eventLoop;

    public Form1()
    {
        InitializeComponent();
        this.Paint += ControlPaint;

        KeyDown += OnKeyDown;

        var map = new Map("map.txt");
        eventLoop = new();
        game = new(eventLoop, map);
    }

    private void OnKeyDown(object? sender, KeyEventArgs e)
    {
        switch(e.KeyCode)
        {
            case Keys.W:
            case Keys.Up:
                eventLoop.OnUp();
                break;

            case Keys.A:
            case Keys.Left:
                eventLoop.OnLeft();
                break;

            case Keys.S:
            case Keys.Down:
                eventLoop.OnDown();
                break;

            case Keys.D:
            case Keys.Right:
                eventLoop.OnRight();
                break;
            default:
                return;
        }

        Invalidate();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void ControlPaint(object sender, PaintEventArgs e)
    {
        var font = new Font("Arial", 10);
        var wallBrush = new SolidBrush(Color.Red);
        var playerBrush = new SolidBrush(Color.Green);
        Graphics formGraphics;
        formGraphics = this.CreateGraphics();
 
        for (int y = 0; y <= game.Map.Height; y++)
        {
            for (int x = 0; x <= game.Map.Width; x++)
            {
                if (game.Map.GetTile(x, y))
                {
                    formGraphics.FillRectangle(wallBrush, new Rectangle(x * 20, y * 20, 10, 10));
                }

                var entity = game.Map.Entities[x, y];
                if (entity is Player)
                {
                    formGraphics.FillRectangle(playerBrush, new Rectangle(x * 20, y * 20, 10, 10));
                }
            }
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {

    }

    private class FormEventLoop : EventLoop
    {
        public override void Run()
        {
            
        }

        public void OnLeft() => OnLeftKey();
        public void OnRight() => OnRightKey();
        public void OnUp() => OnUpKey();
        public void OnDown() => OnDownKey();
    }
}
