using DungeonCrawler.Elements;

namespace DungeonCrawler
{
    internal class Player : Character
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

        public void DrawPlayerStatus()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(0, 0);

            Console.Write(new string(' ', Console.WindowWidth));

            Console.SetCursorPosition(0, 0);
            Console.Write($"{Name} - HP: {Health}/100");
        }

        public override void Update()
        {
            int newX = X;
            int newY = Y;

            switch (LastKey)
            {
                case ConsoleKey.LeftArrow: newX--; break;
                case ConsoleKey.RightArrow: newX++;break;
                case ConsoleKey.UpArrow: newY--; break;
                case ConsoleKey.DownArrow: newY++; break;
            }

            Enemy? enemy = _level.Elements.OfType<Enemy>().FirstOrDefault(e => e.X == newX && e.Y == newY);

            if (enemy != null)
            {
                Combat.ResolvePlayerAttack(this, enemy, _level);
                return;
            }

            if (!_level.IsWalkable(newX, newY)) return;

            Console.SetCursorPosition(X, Y);
            Console.Write(' ');

            X = newX;
            Y = newY;

            Draw();
        }
    }
}
