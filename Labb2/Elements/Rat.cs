using DungeonCrawler;

namespace DungeonCrawler.Elements
{
    internal class Rat : Enemy
    {
        private Random randomPosition = new Random();

        public int RandomMovement()
        {
            int randomMovement = randomPosition.Next(4);
            return randomMovement;
        }
    
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
            int oldX = X;
            int oldY = Y;

            int newX = X;
            int newY = Y;

            int direction = RandomMovement();

            switch (direction)
            {
                case 0: 
                    newY -- ; 
                    break;
                case 1: 
                    newY ++; 
                    break;
                case 2: 
                    newX --; 
                    break; 
                case 3: 
                    newX ++; 
                    break;
                default:
                    break;
            }

            if (player.X == newX && player.Y == newY)
            {
                Combat.ResolveEnemyAttack(this, player, level);
                return;
            }

            //bool isBlockedByPlayer = level.IsBlocked(newX, newY) || (player.X ==  newX && player.Y == newY);
            bool isBlocked = level.IsBlocked(newX, newY);
            //if (isBlockedByPlayer)
            if (isBlocked)
            {
                return;
            }

            Console.SetCursorPosition(oldX, oldY);
            Console.Write(' ');

            X = newX;
            Y = newY;

        }
    }
    
}
