

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
            Health = 25;
            Foreground = ConsoleColor.Green;

        }

        public override void Update(LevelData level, Player player)
        {

            int oldX = X;
            int oldY = Y;
     

            Console.SetCursorPosition(oldX, oldY);
            Console.Write(' ');

           
            Draw();

        }
    }
    
}
