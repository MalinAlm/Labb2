

namespace DungeonCrawler.Elements
{
    abstract class LevelElement
    {
        public char Sign { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public virtual ConsoleColor Foreground { get; set; }
        public virtual void Draw()
        {
            Console.ForegroundColor = Foreground;
            Console.SetCursorPosition(X, Y);
            Console.Write(Sign);
        }

    }
}

