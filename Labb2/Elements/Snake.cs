using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Elements
{
    internal class Snake : Enemy
    {
        public Snake()
        {
            Name = "Snake";
            Sign = 's';
            Health = 25;
            //Console.ForegroundColor = ConsoleColor.Green;
            Foreground = ConsoleColor.Green;

        }

        public override void Draw()
        {   
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition((int)X, (int)Y);
            Console.Write(Sign);
        }

        public override void Update()
        {
        }
    }
    
}
