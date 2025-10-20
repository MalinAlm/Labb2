using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler.Elements
{
    abstract class Character : LevelElement
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefenceDice { get; set; }
        public virtual void Update()
        {

        }
        public virtual void Update(LevelData level, Player player)
        {

        }

    }
}
