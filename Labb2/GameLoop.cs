using DungeonCrawler.Elements;

namespace DungeonCrawler
{
    internal class GameLoop
    {
        public void Run()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectRoot = Path.GetFullPath(Path.Combine(currentDirectory, @".\Levels"));
            string filePath = Path.Combine(projectRoot, "Level1.txt");

            LevelData level = new LevelData();
            level.Load(filePath);

            var start = level.PlayerStartPosition ?? (1, 6);
            Player player = new Player(start.X, start.Y, level);

            level.Draw(player);
            player.Draw();
            player.DrawPlayerStatus();

            bool isRunning = true;

            while (isRunning)
            {   
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Escape)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Exiting game... Bye!!");
                    Thread.Sleep(2000);
                    isRunning = false;
                    break;
                }

                player.LastKey = key;
                player.Update();

                for (int i = 0; i < level.Elements.Count; i++)
                {
                    LevelElement element = level.Elements[i];
                    if (element is Enemy enemy)
                    {
                        enemy.Update(level, player);
                    }
                }

                level.Draw(player);
                player.Draw();
                player.DrawPlayerStatus();
            }

        }

    }
}

