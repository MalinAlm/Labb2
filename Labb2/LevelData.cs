using DungeonCrawler.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

/*
 Läsa in bandesign från fil
Skapa en klass “LevelData” som har en private field “elements” av typ List<LevelElement>. 
Denna ska även exponeras i form av en public readonly property “Elements”.
 

Vidare har LevelData en metod, Load(string filename), som läser in data från filen man anger vid anrop. 
Load läser igenom textfilen tecken för tecken, och för varje tecken den hittar (som är någon av #, r, eller s) 
så skapar den en ny instans av den klass som motsvarar tecknet och lägger till en referens till instansen på “elements”-listan. 
Tänk på att när instansen skapas så måste den även få en (X/Y) position; 
d.v.s Load behöver alltså hålla reda på vilken rad och kolumn i filen som tecknet hittades på. 
Den behöver även spara undan startpositionen för spelaren när den stöter på @.
 

När filen är inläst bör det alltså finnas ett objekt i “elements” för varje tecken i filen (exkluderat space/radbyte), 
och en enkel foreach-loop som anropar .Draw() för varje element i listan bör nu rita upp hela banan på skärmen.
 */

namespace DungeonCrawler
{
    internal class LevelData
    {
        private List<LevelElement> _elements = new();

        public IReadOnlyList<LevelElement> Elements => _elements;

        public void Load(string filename)
        {

            string path = Path.Combine(filename);
            int y = 0;

            using (StreamReader reader = new StreamReader(path))
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
                                element = new Player { X = x, Y = y, Sign = '@' };
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
    }
}
