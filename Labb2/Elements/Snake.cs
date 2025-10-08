using DungeonCrawler;

namespace DungeonCrawler.Elements
{
    internal class Snake : Enemy
    {
        private Random randomPosition = new Random();

        public int RandomMovement()
        {
            int randomMovement = randomPosition.Next(0, 4);
            return randomMovement;
        }

        public Snake()
        {
            Name = "Snake";
            Sign = 's';
            Foreground = ConsoleColor.Green;

            Health = 25;
            AttackDice = new Dice(3, 4, 2);
            DefenceDice = new Dice(1, 8, 5);
        }

        public override void Update(LevelData level, Player player)
        {
            int oldX = X;
            int oldY = Y;

            int newX = X;
            int newY = Y;   

            int distanceToPlayer = Math.Abs(X - player.X) + Math.Abs(Y - player.Y);
            if (distanceToPlayer > 2) return;
           
            if (player.X < X)
            {
                newX++;
            }
            else if (player.X > X)
            {
                newX--;
            }

            if (player.Y < Y)
            {
                newY++;
            }
            else if (player.Y > Y)
            {
                newY--;
            }

            if (level.IsBlocked(newX, newY))
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
