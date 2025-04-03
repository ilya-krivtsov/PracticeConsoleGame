namespace UnitTests;
using PracticeConsoleGame;
using NUnit.Framework;
using System;
using System.IO;

[TestFixture]
public class MapTests
{
    private const string TestFilePath = "test.txt";
    private EventLoop loop;
    private Map map;
    private Game game;

    public ConsoleKey Left() => ConsoleKey.LeftArrow;
    public ConsoleKey Right() => ConsoleKey.RightArrow;
    public ConsoleKey Up() => ConsoleKey.UpArrow;
    public ConsoleKey Down() => ConsoleKey.DownArrow;

    [SetUp]
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

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(TestFilePath))
        {
            File.Delete(TestFilePath);
        }
    }

    [Test]
    public void TestMovement()
    {
        var initialX = map.PlayerX;
        var initialY = map.PlayerY;

        for (var i = 0; i < 4; ++i)
        {
            loop.HandleKeyPress(Right());
        }

        loop.HandleKeyPress(Down());
        loop.HandleKeyPress(Up());
        loop.HandleKeyPress(Left());

        Assert.AreEqual(initialX + 2, map.PlayerX);
        Assert.AreEqual(initialY, map.PlayerY);
    }

    [Test]
    public void TestEmptyMap()
    {
        File.WriteAllText(TestFilePath, "");

        for (var i = 0; i < 3; ++i)
        {
            loop.HandleKeyPress(Right());
        }

        loop.HandleKeyPress(Left());
        loop.HandleKeyPress(Down());
        loop.HandleKeyPress(Up());

        Assert.AreEqual(0, map.PlayerX);
        Assert.AreEqual(0, map.PlayerY);
    }

    [Test]
    public void TestBorderlineMovement()
    {
        File.WriteAllText(TestFilePath,
           "# #\n" +
           " @ \n" +
           "# #");

        var initialX = map.PlayerX;
        var initialY = map.PlayerY;

        for (var i = 0; i < 4; ++i)
        {
            loop.HandleKeyPress(Right());
        }

        for (var i = 0; i < 4; ++i)
        {
            loop.HandleKeyPress(Left());
        }

        loop.HandleKeyPress(Right());

        for (var i = 0; i < 4; ++i)
        {
            loop.HandleKeyPress(Up());
        }

        for (var i = 0; i < 4; ++i)
        {
            loop.HandleKeyPress(Down());
        }

        Assert.AreEqual(initialX, map.PlayerX);
        Assert.AreEqual(initialY + 1, map.PlayerY);
    }
}
