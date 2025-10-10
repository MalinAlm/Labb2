

namespace DungeonCrawler
{
    class Dice
    {
        private int _numberOfDice = 0;
        private int _sidesPerDice = 0;
        private int _modifier = 0;
        private Random _random = new Random();

        public Dice(int numberOfDice, int sidesPerDice, int modifier)
        {
            _numberOfDice = numberOfDice;
            _sidesPerDice = sidesPerDice;
            _modifier = modifier;
        }

        public int Throw()
        {
            int diceRollSum = 0;

            for (int i = 0; i < _numberOfDice; i++)
            {
                diceRollSum += _random.Next(1, _sidesPerDice + 1);
            }

            int total = diceRollSum + _modifier;
            return total;
        }

        public override string ToString()
        {
            if (_modifier == 0)
            {
                return $"{_numberOfDice}d{_sidesPerDice}";
            }
            var signOperators = _modifier >= 0 ? "+" : "-";
            return $"{_numberOfDice}d{_sidesPerDice}{signOperators}{Math.Abs(_modifier)}";
        }
    }
}
