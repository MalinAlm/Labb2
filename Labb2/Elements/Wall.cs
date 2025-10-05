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
            Foreground = ConsoleColor.Gray;

        }

        public override void Draw()
        {
            Console.ForegroundColor = Foreground;
            Console.SetCursorPosition((int)X, (int)Y);
            Console.Write(Sign);
        }

    }
    
}
