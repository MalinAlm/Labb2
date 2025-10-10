using DungeonCrawler.Elements;


namespace DungeonCrawler
{
    internal static class Combat
    {
        private static void WriteMessage(string message, int line = 0)
        {
            Console.SetCursorPosition(0, line);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(new String(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, line);
            Console.Write(message);
        }

        public static void ResolvePlayerAttack(Player player, Enemy enemy, LevelData level)
        {
            WriteMessage($"{player.Name} attacks {enemy.Name}! ");
            PerformAttack(player, enemy, level);
        }

        public static void ResolveEnemyAttack(Enemy enemy, Player player, LevelData level)
        {
            WriteMessage($"{enemy.Name} attacks {player.Name}!");
            PerformAttack(enemy, player, level);
        }

        private static void PerformAttack(dynamic attacker, dynamic defender, LevelData level)
        {
            for (int line = 0; line <= 3; line++)
            {
                Console.SetCursorPosition(0, line);
                WriteMessage(string.Empty, line);
            }
            
            int attackRoll = attacker.AttackDice.Throw();
            int defenceRoll = defender.DefenceDice.Throw();
            int damage = attackRoll - defenceRoll;

            if (damage > 0) defender.Health = Math.Max(0, defender.Health - damage);
            
            string attackMessage;

            if (damage > 0)
            {
                attackMessage = $"{attacker.Name} attacks {defender.Name}  (attack {attacker.AttackDice}: {attackRoll}, defense {defender.DefenceDice}: {defenceRoll}) -> {damage} damage!";
            }
            else
            {
                attackMessage = $"{attacker.Name} attacks {defender.Name}  (attack {attacker.AttackDice}: {attackRoll}, defense {defender.DefenceDice}: {defenceRoll}) -> {defender.Name} blocked the attack!";
            }

            WriteMessage(attackMessage, 0);

            if (defender.Health > 0)
            {
                int counterAttackRoll = defender.AttackDice.Throw();
                int counterDefenceRoll = attacker.DefenceDice.Throw();
                int counterDamage = counterAttackRoll - counterDefenceRoll;

                if (counterDamage > 0)
                {
                    attacker.Health = Math.Max (0, attacker.Health - counterDamage);
                }

                string counterMessage;
                if (counterDamage > 0)
                {
                    counterMessage = $"{defender.Name} hits back! {defender.AttackDice}  (attack {defender.AttackDice}: {counterAttackRoll}, defense {attacker.DefenceDice}: {counterDefenceRoll}) -> {counterDamage} damage!";
                }
                else
                {
                    counterMessage = $"{defender.Name} hits back! {defender.AttackDice}  (attack {defender.AttackDice}: {counterAttackRoll}, defense {attacker.DefenceDice}: {counterDefenceRoll}) -> {attacker.Name} blocked the attack!";
                }

                WriteMessage (counterMessage, 1);

                if (attacker.Health <= 0 && attacker is Player)
                {
                    WriteMessage($"Oh no! You have been defeated! Game over!", 2);
                    Thread.Sleep(3000);
                    Environment.Exit(0); 
                }
            }
            else
            {
                WriteMessage($"Yaay! {defender.Name} has been killed!!", 2);
                if (defender is Enemy)
                {
                    Console.SetCursorPosition(defender.X, defender.Y);
                    Console.Write(' ');
                    level.RemoveElement(defender);
                }
            }

            WriteMessage($"HP: {attacker.Name} {attacker.Health} | HP: {defender.Name} {defender.Health}", 3);
            Thread.Sleep(800);
        }
    }
}
