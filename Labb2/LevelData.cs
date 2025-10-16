using DungeonCrawler.Elements;

namespace DungeonCrawler
{
    internal class LevelData
    {
        public (int X, int Y)? PlayerStartPosition { get; set; }
        private List<LevelElement> _elements = new();
        public IReadOnlyList<LevelElement> Elements => _elements;
        private HashSet<(int X, int Y)> _seenPositions = new();

        public void Load(string filename)
        {
            int y = 4;

            using (StreamReader reader = new StreamReader(filename))
            {
                string? line;

                while ((line = reader.ReadLine()) != null)
                {

                    for (int x = 0; x < line.Length; x++)
                    {
                        char sign = line[x];
                        LevelElement? element = null;

                        switch (sign)
                        {
                            case '#':
                                    element = new Wall { X = x, Y = y };
                                    break;
                            case '@':
                                    PlayerStartPosition = (x, y);
                                break;
                            case 'r':
                                    element = new Rat { X = x, Y = y };
                                    break;
                            case 's':
                                element = new Snake { X = x, Y = y };
                                break;
                            default:
                                break;
                        }

                        if (element != null)
                        {
                            _elements.Add(element);
                        }
                    }

                    y++;
                }
            }
        }
        public void Draw(Player player)
        {
            foreach (var element in _elements)
            {
                double distance = Math.Sqrt(
                    Math.Pow(player.X - element.X, 2) +
                    Math.Pow(player.Y- element.Y, 2)
                    );

                bool isVisible = distance <= player.VisionRange;

                if (isVisible)
                {
                    _seenPositions.Add((element.X, element.Y));
                }

                bool hasBeenSeen = _seenPositions.Contains((element.X, element.Y));

                if (isVisible || (element is Wall && hasBeenSeen))
                {
                    element.Draw();
                }
                else
                {
                    Console.SetCursorPosition(element.X, element.Y);
                    Console.Write(' ');
                }
            }
        }
        //TODO: ändra IsBlocked till isWalkable
        public bool IsBlocked(int x, int y)
        {
            return _elements.Any(element =>
            element.X == x &&
            element.Y == y && 
            (element is Wall || element is Enemy));
        }

        public void RemoveElement(LevelElement element)
        {
            _elements.Remove(element);
        }
    }
}
