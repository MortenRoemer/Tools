using System.IO;
using System.Threading;
using System.Threading.Tasks;

// disable async without awaiter warning
#pragma warning disable 1998

namespace MortenRoemer.Tools.Framework.IO
{
    public class LocalFileRepository : IFileRepository
    {
        public static readonly LocalFileRepository Singleton = new();

        private LocalFileRepository() { }
        
        public async Task<Stream> ReadFile(string path, CancellationToken token = default)
        {
            return File.OpenRead(path);
        }

        public async Task<Stream> WriteFile(string path, CancellationToken token = default)
        {
            return File.OpenWrite(path);
        }

        public async Task<bool> FileExists(string path, CancellationToken token = default)
        {
            return File.Exists(path);
        }

        public async Task<bool> DirectoryExists(string path, CancellationToken token = default)
        {
            return Directory.Exists(path);
        }

        public async Task CreateDirectory(string path, CancellationToken token = default)
        {
            Directory.CreateDirectory(path);
        }

        public async Task DeleteFile(string path, CancellationToken token = default)
        {
            File.Delete(path);
        }

        public async Task DeleteDirectory(string path, CancellationToken token = default)
        {
            Directory.Delete(path, true);
        }
    }
}

#pragma warning restore 1998