using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



namespace DungeonCrawler
{
    internal class GameLoop
    {       
         //TODO: ett varv i loopen motsvarar en runda, invänta och läs in spelarens knapptryck, utför sedan spelarens drag.
         //TODO: urför sedan datorns drag´(uppdatera alla fiender)
         //TODO: ha ev en escape för att avbryta spelet

            public void Run()
            {

                string currentDirectory = Directory.GetCurrentDirectory();
                string projectRoot = Path.GetFullPath(Path.Combine(currentDirectory, @".\Levels"));
                string filePath = Path.Combine(projectRoot, "Level1.txt");

                LevelData level = new LevelData();
                level.Load(filePath);

                var start = level.PlayerStartPosition ?? (0, 0);
                Player player = new Player(level.PlayerStartPosition.Value.X, level.PlayerStartPosition.Value.Y, level);

            while (true)
            {
                //TODO: pausa loop tills spelaren trycker på en tangent
              
                level.Draw();
                player.Draw();
                var key = Console.ReadKey(true).Key;
                player.LastKey = key;
                player.Update();

            }

            }

    }
}

