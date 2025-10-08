using DungeonCrawler.Elements;

namespace DungeonCrawler
{
    internal class Player : MainCharacter
    {
        private LevelData _level;
        public ConsoleKey? LastKey { get; set; }
        public int VisionRange { get; set; } = 5;

        public Player(int x, int y, LevelData level)
        {           
            _level = level;
            Name = "Beep Boop";
            Sign = '@';
            Foreground = ConsoleColor.Magenta;
            X = x;
            Y = y;

            Health = 100;
            AttackDice = new Dice(2, 6, 2);
            DefenceDice = new Dice(2, 6, 0);
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
            int oldX = X;
            int oldY = Y;

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
                X = oldX;
                Y = oldY;
                return;
            }

            Console.SetCursorPosition(oldX, oldY);
            Console.Write(' ');

            Draw();

        }
    }
}
