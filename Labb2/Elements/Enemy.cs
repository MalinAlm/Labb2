

namespace DungeonCrawler.Elements
{
    //abstract class Enemy : LevelElement
    abstract class Enemy : Character
    {
        //public string Name { get; set; }
        //public int Health { get; set; }
        //public Dice AttackDice { get; set; }
        //public Dice DefenceDice { get; set; }
        public new abstract void Update(LevelData level, Player player);
    }
}
