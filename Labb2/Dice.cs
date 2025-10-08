
/*
 Kasta tärningar
Spelet använder sig av simulerade tärningskast för att avgöra hur mycket skada spelaren och fienderna gör på varandra.
 

Skapa en klass “Dice” med en konstruktor som tar 3 parametrar: numberOfDice, sidesPerDice och modifier. 
Genom att skapa nya instanser av denna kommer man kunna skapa olika uppsättningar av tärningar 
t.ex “3d6+2”, d.v.s slag med 3 stycken 6-sidiga tärningar, där man tar resultatet och sedan plussar på 2, för att få en total poäng.
 

Dice-objekt ska ha en publik Throw() metod som returnerar ett heltal med den poäng man får när man 
slår med tärningarna enligt objektets konfiguration. Varje anrop motsvarar alltså ett nytt kast med tärningarna.
 

Gör även en override av Dice.ToString(), så att man när man skriver ut ett 
Dice-objekt får en sträng som beskriver objektets konfiguration. t.ex: “3d6+2”.


1.	Skapa Dice-klassen
2.	Lägg till privata fält för numberOfDice, sidesPerDice och modifier.
3.	Implementera en konstruktor som tar emot och sparar dessa tre parametrar.
4.	Implementera metoden Throw() som:
•	Slår rätt antal tärningar.
•	Summerar resultaten.
•	Lägger till modifieraren.
•	Returnerar den totala poängen.
5.	Overridea ToString() så att den returnerar en sträng i formatet “XdY+Z”.
6.	Testa klassen med olika konfigurationer för att säkerställa att den fungerar korrekt.
Tips: Tänk på att hantera både positiva och negativa modifierare i ToString().

 */

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
            //dice.Next(this._numberOfDice, this._sidesPerDice + _modifier);
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
