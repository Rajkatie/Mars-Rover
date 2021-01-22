using Mars.Domain.Abstraction;

using System.IO;

namespace Mars.Infrastructure.Impl
{
   public class TextCommandReader : ICommandReader
    {
        private readonly string _commandChars;

        public TextCommandReader(string commandChars)
        {
            _commandChars = commandChars;
        }
        public string Read()
        {
            using (StringReader stringReader = new StringReader(_commandChars))
            {
                return stringReader.ReadToEnd();
            }
        }
    }
}
