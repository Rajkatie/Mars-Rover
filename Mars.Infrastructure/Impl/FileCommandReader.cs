using Mars.Domain.Abstraction;

using System.IO;

namespace Mars.Infrastructure.Impl
{
    class FileCommandReader : ICommandReader
    {
        private readonly string _filePath;

        public FileCommandReader(string filePath)
        {
            _filePath = filePath;
        }
        public string Read()
        {
            if (File.Exists(_filePath))
            {
               return File.ReadAllText(_filePath);
            }
            return string.Empty;
        }
    }
}
