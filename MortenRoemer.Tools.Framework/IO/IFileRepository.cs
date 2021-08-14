using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MortenRoemer.Tools.Framework.IO
{
    public interface IFileRepository
    {
        Task<Stream> ReadFile(string path, CancellationToken token = default);

        Task<Stream> WriteFile(string path, CancellationToken token = default);

        Task<bool> FileExists(string path, CancellationToken token = default);

        Task<bool> DirectoryExists(string path, CancellationToken token = default);

        Task CreateDirectory(string path, CancellationToken token = default);

        Task DeleteFile(string path, CancellationToken token = default);

        Task DeleteDirectory(string path, CancellationToken token = default);
    }

    public static class FileRepositoryExtension
    {
        public static async Task<StreamReader> ReadTextFile(
            this IFileRepository repository, 
            string path, 
            Encoding encoding, 
            CancellationToken token = default)
        {
            return new StreamReader(await repository.ReadFile(path, token), encoding);
        }

        public static async Task<StreamWriter> WriteTextFile(
            this IFileRepository repository, 
            string path,
            Encoding encoding, 
            CancellationToken token = default)
        {
            return new StreamWriter(await repository.WriteFile(path, token), encoding);
        }
    }
}