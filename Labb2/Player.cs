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
        private readonly LevelData _level;
        public ConsoleKey? LastKey { get; set; }
        public Player(int x, int y, LevelData level)
        {           
            _level = level;
            Name = "Beep Boop";
            Sign = '@';
            Health = 100;
            Foreground = ConsoleColor.Magenta;

            X = x;
            Y = y;
        }

        public override void Draw()
        {
            Console.ForegroundColor = Foreground;
            Console.SetCursorPosition((int)X, (int)Y);
            Console.CursorVisible = false;
            Console.Write(Sign);
            
        }

        public override void Update()
        {

            int oldXPosition = X;
            int oldYPosition = Y;

            if (LastKey == ConsoleKey.LeftArrow)
            {
                X--; 
            }
            else if (LastKey == ConsoleKey.RightArrow)
            {
                X++;
            }
            else if (LastKey == ConsoleKey.UpArrow)
            {
                Y--; 
            }
            else if (LastKey == ConsoleKey.DownArrow)
            {
                Y++; 
            }

            if (_level.IsBlocked( X, Y ))
            {
                X = oldXPosition;
                Y = oldYPosition;
                return;
            }

            Console.SetCursorPosition(oldXPosition, oldYPosition);
            Console.Write(' ');

            Draw();

        }
    }
}
