using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Elements
{
    abstract class LevelElement
    {

        public char Sign;
        public int X { get; set; }
        public int Y { get; set; }

        public virtual ConsoleColor Foreground { get; set; }
        public virtual void Draw()
        {

        }

    }
}

