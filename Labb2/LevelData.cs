using DungeonCrawler.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    internal class LevelData
    {
        public (int X, int Y)? PlayerStartPosition { get; set; }

        private List<LevelElement> _elements = new();

        public IReadOnlyList<LevelElement> Elements => _elements;

        public void Load(string filename)
        {

            int y = 0;

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
                                element = new Wall { X = x, Y = y, Sign = '#' };
                                break;
                        case '@':
                                PlayerStartPosition = (x, y);
                                break;
                        case 'r':
                                element = new Rat { X = x, Y = y, Sign = 'r' };
                                break;
                        case 's':
                                element = new Snake { X = x, Y = y, Sign = 's' };
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
        public void Draw()
        {
            foreach (var element in _elements)
            {
                element.Draw();
            }
        }

        public bool IsBlocked(int x, int y)
        {
            return _elements.Any(element => element.X == x && element.Y == y && (element is Wall || element is Enemy));
        }
    }
}
