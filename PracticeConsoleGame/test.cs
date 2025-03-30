namespace PracticeConsoleGame;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading;

public class MapTests
{
    private const string TestFilePath = "test.txt";
    private EventLoop loop;
    private Map map;
    private Game game;

    public void Setup()
    {
        File.WriteAllText(TestFilePath,
            "#####\n" +
            "#@   \n" +
            "#   #\n" +
            "#   #\n" +
            "# ###");

        loop = new EventLoop();
        map = new Map(TestFilePath);
        game = new Game(loop, map);
    }

    public void TearDown()
    {
        if (File.Exists(TestFilePath))
        {
            File.Delete(TestFilePath);
        }
    }

    public void IsWorks()
    {

    }

    public void RightBorderline()
    {
        for (var i = 0; i < 3; ++i)
        {
            loop.HandleKeyPress(ConsoleKey.RightArrow);
        }
        
    }

    public void Empty()
    {

    }

}
