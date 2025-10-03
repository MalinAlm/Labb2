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
        public double X { get; set; }
        public double Y { get; set; }


        public virtual void Draw()
        {

        }

    }
}

