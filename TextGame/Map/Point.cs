using System;

namespace TextGame.Map
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; }
        public int Y { get; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is Point point) return point.X == X && Y == point.Y;
            return false;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }

    public static class PointEx
    {
        public static Point Copy(this Point other)
        {
            return new Point(other.X, other.Y);
        }

        public static Point MoveTo(this Point currentPosition, ConsoleKey direction)
        {
            switch (direction)
            {
                case ConsoleKey.W: return currentPosition.MoveTop();
                case ConsoleKey.S: return currentPosition.MoveDown();
                case ConsoleKey.A: return currentPosition.MoveLeft();
                case ConsoleKey.D: return currentPosition.MoveRight();
                default: return currentPosition;
            }
        }

        public static Point MoveTop(this Point point)
        {
            var newY = point.Y - 1;
            return new Point(point.X, newY);
        }

        public static Point MoveDown(this Point point)
        {
            var newY = point.Y + 1;
            return new Point(point.X, newY);
        }
        
        public static Point MoveLeft(this Point point)
        {
            var newX = point.X - 1;
            return new Point(newX, point.Y);
        }
        
        public static Point MoveRight(this Point point)
        {
            var newX = point.X + 1;
            return new Point(newX, point.Y);
        }
    }
}
