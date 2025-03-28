using PracticeConsoleGame;

var map = new Map(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "map.txt"));

var eventLoop = new EventLoop();

var game = new Game(eventLoop, map);

eventLoop.Run();
