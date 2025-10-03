using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Elements
{
    internal class Wall : LevelElement
    {

        public Wall()
        {
            Sign = '#';
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        public override void Draw()
        {
            Console.SetCursorPosition((int)X, (int)Y);
            Console.Write(Sign);
        }

    }
    
}
