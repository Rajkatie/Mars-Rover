
using Mars.Domain;
using Mars.Domain.Abstraction;
using Mars.Domain.Imple;

using Moq;

using System;

using Xunit;

namespace Mars.Tests
{
    public class MarsRoverTest
    {
        [Fact]
        public void ThrowException_If_rover_is_not_initialize_properly()
        {
            Exception ex = Record.Exception(() => new Rover(null, null, null));

            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void rover_default_position_and_location_must_be_north_and_zero()
        {

            Location currentLocation = new Rover().StartLocation;

            Coordinates defaultCoordinates = currentLocation.Coordinates;
            
            var expectedCoordinate = new Coordinates(0, 0);

            // Assert

            Assert.Equal('n', currentLocation.Direction.Name);

            Assert.True(expectedCoordinate.Equals(defaultCoordinates));
        }

        [Fact]
        public void without_any_move_default_starting_and_ending_position_of_rover_must_be_same()
        {
            Rover marsRover = new Rover();

            Location startLocation = marsRover.StartLocation;

            Location LastLocation = marsRover.LastLocation;

            //Assert

            Assert.Equal('n', startLocation.Direction.Name);

            Assert.Equal('n', LastLocation.Direction.Name);

             Assert.Equal(LastLocation.Coordinates, startLocation.Coordinates);

        }

        [Fact]
        public void Navigate_ThrowException_IfCommandReader_IsNull()
        {
            Rover marsRover = new Rover(new MarsCommand(), new Coordinates(0,0), new Orientation('w'));

            Exception ex = Record.Exception(() => marsRover.Navigate(null));

            Assert.IsType<ArgumentNullException>(ex);
        }

        [Theory]
        [InlineData("")]
        [InlineData("edrtgy")]
        public void Navigate_ThrowException_IfCommandReader_Contains_InValidCommandChars(string inpuCommand)
        {
            Rover marsRover = new Rover(new MarsCommand(), new Coordinates(0, 0), new Orientation('w'));

            Mock<ICommandReader> mockCommandReader = getCommandReaderMockInstance(inpuCommand);

            Exception ex = Record.Exception(() => marsRover.Navigate(mockCommandReader.Object));

            Assert.IsType<ArgumentOutOfRangeException>(ex);
        }

        [Fact]
        public void do_not_create_rover_instance_if_direction_is_invalid()
        {
            Mock<ICommandReader> mockCommandReader = new Mock<ICommandReader>();

            Exception ex = Record.Exception(() =>
            new Rover(new MarsCommand(), new Coordinates(0, 0), new Orientation((char)0)));

            Assert.IsType<ArgumentOutOfRangeException>(ex);

        }


        //[Theory]
        //[InlineData("MMMMM",'n')]
        //public void Test3(string command,char expectedDirection)
        //{
        //    MarsRover marsRover = new MarsRover(new Grid(5, 5));

        //    Location currentLocation = marsRover.Execute(command);

        //    Assert.Equal(expectedDirection, currentLocation.Direction);

        //    Assert.Equal(3, currentLocation.Position.Y);

        //}

        ////[Fact]
        ////public void Move_Move()
        ////{
        ////    MarsRover marsRover = new MarsRover(new Grid(5, 5), 
        ////        new Position(3, 4, 'n'));

        ////    marsRover.Execute("MML");

        ////    var currentPosition = marsRover.LastPosition;

        ////   Assert.Equal('w', currentPosition.Direction);
        ////   Assert.Equal(3, currentPosition.X);
        ////   Assert.Equal(6, currentPosition.Y);
        ////}

        [Theory]
        [InlineData("L", 'w')]
        [InlineData("LL", 's')]
        [InlineData("LLL", 'e')]
        [InlineData("LLLL", 'n')]
        public void Navigate_WhenControlCharIsLeft_ShouldChangeDirection(string command, char expectedDirection)
        {
            Rover marsRover = new Rover();

            Mock<ICommandReader> mockCommandReader = getCommandReaderMockInstance(command);

            marsRover.Navigate(mockCommandReader.Object);

            Assert.Equal(expectedDirection, marsRover.LastLocation.Direction.Name);
        }

        [Theory]
        [InlineData("R", 'e')]
        [InlineData("RR", 's')]
        [InlineData("RRR", 'w')]
        [InlineData("RRRR", 'n')]
        public void Navigate_WhenControlCharIsRight_ShouldChangeDirection(string command, char expectedDirection)
        {
            Rover marsRover = new Rover();

            Mock<ICommandReader> mockCommandReader = getCommandReaderMockInstance(command);

            marsRover.Navigate(mockCommandReader.Object);

            Assert.Equal(expectedDirection, marsRover.LastLocation.Direction.Name);

        }


        private static Mock<ICommandReader> getCommandReaderMockInstance(string command)
        {
            Mock<ICommandReader> mockCommandReader = new Mock<ICommandReader>();
            mockCommandReader.Setup(x => x.Read()).Returns(command);
            return mockCommandReader;


        }

    }
}
