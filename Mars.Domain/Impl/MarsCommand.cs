using Mars.Domain.Abstraction;

namespace Mars.Domain.Imple
{
    public class MarsCommand : IPlanetCommand
    {
        private Orientation _compassPoint;

        public void SetInitialCompassPoint(Orientation compassPoint)
        {
            _compassPoint = compassPoint;
        }

        public void Execute(char controlChar)
        {
            if (controlChar.Equals('L'))
            {
                _compassPoint = _compassPoint.GetLeft();
            }

            else if (controlChar.Equals('R'))
            {
                _compassPoint = _compassPoint.GetRight();
            }

            else if (controlChar.Equals('M'))
            {
                //_compassPoint = Move();
            }
        }

        public Location GetLastLocation()
            => new Location(new Coordinates(0,0), _compassPoint);

       
    }
}
