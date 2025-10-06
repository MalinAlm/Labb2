using DungeonCrawler.Elements;

namespace DungeonCrawler
{
    internal class GameLoop
    {
        //TODO: urför sedan datorns drag´(uppdatera alla fiender)
        //TODO: ha ev en escape för att avbryta spelet
        public void Run()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectRoot = Path.GetFullPath(Path.Combine(currentDirectory, @".\Levels"));
            string filePath = Path.Combine(projectRoot, "Level1.txt");

            LevelData level = new LevelData();
            level.Load(filePath);

            var start = level.PlayerStartPosition ?? (0,0);
            Player player = new Player(start.X, start.Y, level);

            level.Draw();
            player.Draw();

            while (true)
            {
                var key = Console.ReadKey(true).Key;
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

                level.Draw();
                player.Draw();
            }

        }

    }
}

