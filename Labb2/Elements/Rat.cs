using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Elements
{
    internal class Rat : Enemy
    {
        public Rat()
        {
            Name = "Rat";
            Sign = 'r';
            Health = 10;

            //Console.ForegroundColor = ConsoleColor.Red;
            Foreground = ConsoleColor.Red;
        }


        public override void Draw()
        {
            Console.ForegroundColor = Foreground;

            Console.SetCursorPosition((int)X, (int)Y);
            Console.Write(Sign);
        }

        public override void Update()
        { 
                
        }



        
    }
    
}
