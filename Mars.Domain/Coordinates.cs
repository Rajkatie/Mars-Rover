using System.Collections.Generic;

namespace Mars.Domain
{
    public class Coordinates : ValueObject
    {
        public byte X { get; private set; }

        public byte Y { get; private set; }

        public Coordinates(byte x, byte y)
        {
            X = x;
            Y = y;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return X;
            yield return Y;
        }
    }
}