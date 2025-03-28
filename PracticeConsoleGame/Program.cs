using PracticeConsoleGame;

var eventLoop = new EventLoop();

eventLoop.LeftKeyPress += () => Console.WriteLine("left");
eventLoop.RightKeyPress += () => Console.WriteLine("right");
eventLoop.UpKeyPress += () => Console.WriteLine("up");
eventLoop.DownKeyPress += () => Console.WriteLine("down");

eventLoop.Run();
