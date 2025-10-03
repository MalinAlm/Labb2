using DungeonCrawler.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal class Player : MainCharacter
    {

        public Player()
        {
            Name = "Beep Boop";
            Sign = '@';
            Health = 100;
            Console.ForegroundColor = ConsoleColor.Magenta;
        }

        //public override void Draw()
        //{
        //    Console.SetCursorPosition((int)X, (int)Y);
        //    Console.Write(Sign);
        //}

        public override void Update()
        {
        }
    }
}
