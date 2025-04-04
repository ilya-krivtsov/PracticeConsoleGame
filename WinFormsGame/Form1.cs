using PracticeConsoleGame;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace WinFormsGame;

public partial class Form1 : Form
{

    public Form1()
    {
        InitializeComponent();
        this.Paint += new PaintEventHandler(ControlPaint);
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
        System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        System.Drawing.Graphics formGraphics;
        formGraphics = this.CreateGraphics();
 
        for (int y = 0; y < MaxHeight && y < lines.Length; y++)
        {
            var line = lines[y];
            for (int x = 0; x < MaxWidth && x < line.Length; x++)
            {
                char c = line[x];

                if (c == '#' || c == '@')
                {
                    formGraphics.FillRectangle(myBrush, new Rectangle(x * 20, y * 20, 10, 10));
                }
            }
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {

    }
}
