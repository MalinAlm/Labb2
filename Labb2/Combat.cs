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
            Console.Write(new string(' ', Console.WindowWidth));
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

        private static int DoAttack(Character attacker, Character defender, int line, string actionText, LevelData level)
        {
            int attackRoll = attacker.AttackDice.Throw();
            int defenceRoll = defender.DefenceDice.Throw();
            int damage = attackRoll - defenceRoll;

            if (damage > 0) defender.Health = Math.Max(0, defender.Health - damage);

            string baseText = $"{attacker.Name} {actionText} {defender.Name}! " +
                $"(attack {attacker.AttackDice}: {attackRoll}, defense {defender.DefenceDice}: {defenceRoll})";

            string message;

            if (damage > 0)
            {
                message = $"{baseText} -> {damage} damage!";
            }
            else
            {
                message = $"{baseText} - blocked!";
            }

            ConsoleColor attackColor = ConsoleColor.DarkCyan;
            if (defender is Player)
            {
                attackColor = damage > 0 ? ConsoleColor.Red : ConsoleColor.Green;
            }

            WriteMessage(message, line, attackColor);
            return damage;
        }


        private static void PerformAttack(Character attacker, Character defender, LevelData level)
        {
            for (int line = 0; line < 4; line++)
            {
                WriteMessage(string.Empty, line);
            }

            DoAttack(attacker, defender, 0, "attacks", level);

            if (defender.Health > 0)
            {
                DoAttack(defender, attacker, 1, "hits back!", level);

                if (attacker is Player player && player.Health <= 0)
                {
                    player.GameOver();
                    WriteMessage($"Oh no! You have been defeated! Game over!", 2, ConsoleColor.Red);
                }
            }
            else
            {
                WriteMessage($"Yaay! {defender.Name} has been killed!", 2);
                if (defender is Enemy)
                {
                    Console.SetCursorPosition(defender.X, defender.Y);
                    Console.Write(' ');
                    level.RemoveElement(defender);
                }
            }

            if (attacker is Player p1) p1.DrawPlayerStatus();
            if (defender is Player p2) p2.DrawPlayerStatus();

        }
    }
}
