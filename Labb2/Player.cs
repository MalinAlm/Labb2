using DungeonCrawler.Elements;

namespace DungeonCrawler
{
    internal class Player : MainCharacter
    {
        private LevelData _level;
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
            Console.SetCursorPosition(X, Y);
            Console.CursorVisible = false;
            Console.Write(Sign);
        }

        public override void Update()
        {
            int oldXPosition = X;
            int oldYPosition = Y;

            switch (LastKey)
            {
                case ConsoleKey.LeftArrow:
                    X--;
                    break;
                case ConsoleKey.RightArrow:
                    X++;
                    break;
                case ConsoleKey.UpArrow:
                    Y--;
                    break;
                case ConsoleKey.DownArrow:
                    Y++;
                    break;
                default:
                    break;
               
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
