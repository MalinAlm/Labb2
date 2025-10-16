using DungeonCrawler;

namespace DungeonCrawler.Elements
{
    internal class Rat : Enemy
    {
        private Random _randomPosition = new Random();
    
        public Rat()
        {
            Name = "Rat";
            Sign = 'r';
            Foreground = ConsoleColor.Red;
            Health = 10;
            AttackDice = new Dice(1, 6, 3);
            DefenceDice = new Dice(1, 6, 1);
        }

        public override void Update(LevelData level, Player player)
        {
            int newX = X;
            int newY = Y;

            switch (_randomPosition.Next(4))
            {
                case 0: newY --; break;
                case 1: newY ++; break;
                case 2: newX --; break; 
                case 3: newX ++; break;
            }

            if (player.X == newX && player.Y == newY)
            {
                Combat.ResolveEnemyAttack(this, player, level);
                return;
            }

            if (!level.IsWalkable(newX, newY)) return;

            Console.SetCursorPosition(X, Y);
            Console.Write(' ');

            X = newX;
            Y = newY;
        }
    }
}
