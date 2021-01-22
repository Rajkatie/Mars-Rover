namespace Mars.Domain
{
    public class Location
    {
       public Coordinates Coordinates;

        public Orientation Direction;

        public Location():this(new Coordinates(0,0), new Orientation())
        {

        }
        public Location(Coordinates position):this(position, new Orientation())
        {

        }
        public Location(Coordinates position, Orientation direction)
        {
            Coordinates = position;
            Direction = direction;
        }
    }
}