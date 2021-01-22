using System;
using System.Collections.Generic;
using System.Linq;

namespace Mars.Domain
{
    public class Orientation
    {
        static IDictionary<char, Dictionary<string, char>> directionDict =

             new Dictionary<char, Dictionary<string, char>>(4);

        static Orientation()
        {
            directionDict.Add('n', new Dictionary<string, char>(2)
            {
                { "left",'w'},
                { "right",'e' },
            });

            directionDict.Add('s', new Dictionary<string, char>(2)
            {
                { "left",'e' },
                { "right",'w' },
            });

            directionDict.Add('e', new Dictionary<string, char>(2)
            {
                { "left",'n' },
                { "right",'s' },
            });

            directionDict.Add('w', new Dictionary<string, char>(2)
            {
                { "left",'s' },
                { "right",'n' },
            });
        }

        private Orientation _currentDirection;

        public char Name { get; private set; }

        public Orientation() : this('n')
        {

        }

        public Orientation(char directionName)
        {
            EnforceInvariants(directionName);

            Name = directionName;
        }
        private void EnforceInvariants(char directionName)
        {
            char[] directions = new char[4] { 'n', 'e', 's', 'w' };

            if(!directions.Any(x => x.Equals(char.ToLower(directionName))))
                throw new ArgumentOutOfRangeException("oreintation must have valid initial of direction.");
        }
        public Orientation GetRight()
        {
            Dictionary<string, char> foundValues;

            bool hasValue = directionDict.TryGetValue(Name, out foundValues);

            if (hasValue)
            {
                _currentDirection = new Orientation(foundValues["right"]);
            }

            return _currentDirection;
        }

        public Orientation GetLeft()
        {
            Dictionary<string, char> foundValues;

            bool hasValue = directionDict.TryGetValue(Name, out foundValues);

            if (hasValue)
            {
                _currentDirection = new Orientation(foundValues["left"]);
            }

            return _currentDirection;
        }

        
    }
}
