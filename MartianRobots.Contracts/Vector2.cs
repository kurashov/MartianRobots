using System;

namespace MartianRobots.Contracts
{
    public struct Vector2 : IEquatable<Vector2>
    {
        public Vector2( int x, int y )
        {
            X = x;
            Y = y;
        }

        public Vector2( int value )
        {
            X = value;
            Y = value;
        }

        public int X { get; }
        public int Y { get; }

        public static Vector2 Zero => new Vector2();

        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X + right.X, left.Y + right.Y);
        }

        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X - right.X, left.Y - right.Y);
        }

        public static Vector2 operator *(Vector2 left, int right)
        {
            return left * new Vector2(right, right);
        }

        public static Vector2 operator *(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X * right.X, left.Y * right.Y);
        }

        public static Vector2 operator /(Vector2 value1, int value2)
        {
            return new Vector2(value1.X / value2, value1.Y / value2);
        }

        public static Vector2 operator /(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X / right.X, left.Y / right.Y);
        }

        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"<{X}, {Y}>";
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2 otherObj)
            {
                return (this == otherObj);
            }

            return false;
        }

        public bool Equals(Vector2 other)
        {
            return (this == other);
        }

        public override int GetHashCode() => (X, Y).GetHashCode();
    }
}
