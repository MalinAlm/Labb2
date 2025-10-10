using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public readonly struct Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double VisionDistanceTo(Position otherObject)
        {
            int xDifference = X - otherObject.X;
            int yDifference = Y - otherObject.Y;

            return Math.Sqrt(xDifference * xDifference + yDifference * yDifference);
        }

        public int StraightPathDistanceTo(Position otherObject)
        {
            return Math.Abs(X - otherObject.X) + Math.Abs(Y - otherObject.Y);
        }

        public bool IsSamePosition(Position otherPosition)
        {
            return X == otherPosition.X && Y == otherPosition.Y;
        }

        public Position MoveBy(int xDifference, int yDifference)
        {
            return new Position(X + xDifference, Y + yDifference);
        }
    }
}
