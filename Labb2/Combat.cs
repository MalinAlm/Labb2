using DungeonCrawler.Elements;


namespace DungeonCrawler
{
    internal static class Combat
    {
        private static void WriteMessage(string message, int line = 0, ConsoleColor color = ConsoleColor.DarkCyan)
        {
            int verticalOffset = 1;
            int targetLine = line + verticalOffset;

            Console.SetCursorPosition(0, targetLine);
            Console.ForegroundColor = color;
            Console.Write(new String(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, targetLine);
            Console.Write(message);
            Console.ResetColor();
        }

        public static void ResolvePlayerAttack(Player player, Enemy enemy, LevelData level)
        {
            PerformAttack(player, enemy, level);
        }

        public static void ResolveEnemyAttack(Enemy enemy, Player player, LevelData level)
        {
            PerformAttack(enemy, player, level);
        }

        private static void PerformAttack(dynamic attacker, dynamic defender, LevelData level)
        {
            for (int line = 0; line < 4; line++)
            {
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

            ConsoleColor attackColor = ConsoleColor.DarkCyan; 
            if (defender is Player)
            {
                attackColor = damage > 0 ? ConsoleColor.Red : ConsoleColor.Green;
            }

            WriteMessage(attackMessage, 0, attackColor);

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

                ConsoleColor counterColor = ConsoleColor.DarkCyan;
                if (attacker is Player)
                {
                    counterColor = counterDamage > 0 ? ConsoleColor.Red : ConsoleColor.Green;
                }

                WriteMessage (counterMessage, 1, counterColor);

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

            if (attacker is Player p1) p1.DrawPlayerStatus();
            if (defender is Player p2) p2.DrawPlayerStatus();

            Thread.Sleep(800);
        }
    }
}
