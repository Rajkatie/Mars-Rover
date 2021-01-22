namespace Mars.Domain
{
    public class Grid
    {
        public int Length { get; private set; }
        public int Width { get; private set; }

        
        public Grid(int length=1, int width=1)
        {
            Length = length;
            Width = width;

        }


    }
}