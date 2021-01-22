using Mars.Domain;
using Mars.Domain.Abstraction;
using Mars.Domain.Imple;
using Mars.Infrastructure.Impl;

using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                IPlanetCommand planetCommand = new MarsCommand();
                
                Rover rover = new Rover(planetCommand, new Coordinates(0,0),
                    new Orientation('n'));

                ICommandReader commandReader = new TextCommandReader("mmm");

                bool isValidControlChars = commandReader.Read().IsValidCommandChar();

                if (isValidControlChars)
                {
                    rover.Navigate(commandReader);

                    var lastDirection = rover.LastLocation.Direction;

                    Console.WriteLine("last direction: " + lastDirection.Name);

                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
           
        }
    }
}
