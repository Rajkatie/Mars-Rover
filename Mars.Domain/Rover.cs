using Mars.Domain.Abstraction;
using Mars.Domain.Imple;

using System;

namespace Mars.Domain
{
    public class Rover : Entity
    {
        public Location StartLocation { get; private set; }

        public Location LastLocation
        {
            get
            {
                return getFinishLocation();
            }
        }

        private Coordinates _coordinates;

        private Orientation _orientation;

        private Location _lastLocation;

        private readonly IPlanetCommand _commandExecutor;

        public Rover() : this(new MarsCommand(), new Coordinates(0,0), new Orientation())   {  }

        public Rover(IPlanetCommand command, Coordinates coordinates, Orientation orientation)
        {
            if (command == null)
                throw new ArgumentNullException("command instance can't be null.");

            _commandExecutor = command;

            if (coordinates == null)
                throw new ArgumentNullException("start-location instance can't be null.");

            _coordinates = coordinates;

            if (orientation == null)
                throw new ArgumentNullException("orientation instance can't be null.");

            _orientation = orientation;

            _lastLocation = StartLocation = new Location(_coordinates, _orientation);

        }

        public void Navigate(ICommandReader commandReader)
        {
            if (commandReader == null)
                throw new ArgumentNullException("command reader instance can't be null.");

            string commands = commandReader.Read();

            ThrowExceptionIfContainsInvalidChars(commands);

            _commandExecutor.SetInitialCompassPoint(_orientation);

            foreach (char cmdChar in commands)
            {
                _commandExecutor.Execute(cmdChar);
            }

            _lastLocation = _commandExecutor.GetLastLocation();
        }

        private static void ThrowExceptionIfContainsInvalidChars(string commands)
        {
            bool isValid = commands.IsValidCommandChar();

            if (string.IsNullOrWhiteSpace(commands) || isValid==false)
            {
                throw new ArgumentOutOfRangeException("command char(s) can not be empty.");
            }
        }

        private Location getFinishLocation()
        {
            return _lastLocation;
        }

    }
}
