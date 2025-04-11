using PracticeConsoleGame;
namespace WinFormsGame;

public partial class Form1 : Form
{
    private Game game;

    private FormEventLoop eventLoop;

    public Form1()
    {
        InitializeComponent();
        this.Paint += new PaintEventHandler(ControlPaint);
        KeyDown += OnKeyDown;

        var map = new Map("map.txt"); 

        eventLoop = new();
        game = new(eventLoop, map);
    }

    private void OnKeyDown(object? sender, KeyEventArgs e)
    {
        // trigger event loop
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void ControlPaint(object sender,
System.Windows.Forms.PaintEventArgs e)
    {
        var lines = File.ReadAllLines("map.txt");
        int MaxHeight = 256;
        int MaxWidth = 256;

        var font = new Font("Arial", 10);
        var wallBrush = new SolidBrush(Color.Red);
        var playerBrush = new SolidBrush(Color.Green);
        Graphics formGraphics;
        formGraphics = this.CreateGraphics();
 
        for (int y = 0; y < MaxHeight && y < lines.Length; y++)
        {
            var line = lines[y];
            for (int x = 0; x < MaxWidth && x < line.Length; x++)
            {
                char c = line[x];

                if (c == '#')
                {
                    formGraphics.FillRectangle(wallBrush, new Rectangle(x * 20, y * 20, 10, 10));
                }
                else
                {
                    var entity = 
                }

                if (c == '@')
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
