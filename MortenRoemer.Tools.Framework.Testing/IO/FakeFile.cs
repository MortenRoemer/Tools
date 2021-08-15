using System.IO;
using System.Text;

namespace MortenRoemer.Tools.Framework.Testing.IO
{
    public readonly struct FakeFile
    {
        public FakeFile(string path, byte[] content)
        {
            Path = path;
            Content = content;
        }

        public FakeFile(string path, string content, Encoding encoding)
        {
            Path = path;
            Content = encoding.GetBytes(content);
        }
        
        public string Path { get; }

        public byte[] Content { get; }

        public long Size => Content.LongLength;

        public Stream Read()
        {
            return new MemoryStream(Content);
        }
    }
}