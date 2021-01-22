namespace Mars.Domain.Abstraction
{
    public interface IPlanetCommand
    {
        void SetInitialCompassPoint(Orientation compassPoint);

        void Execute(char controlChar);

        Location GetLastLocation();
    }
}
