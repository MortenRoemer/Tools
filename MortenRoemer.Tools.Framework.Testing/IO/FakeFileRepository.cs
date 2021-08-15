using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MortenRoemer.Tools.Framework.IO;

// disable async without awaiter warning
#pragma warning disable 1998 

namespace MortenRoemer.Tools.Framework.Testing.IO
{
    public class FakeFileRepository : IFileRepository
    {
        public FakeFileRepository() : this(null) { }
        
        public FakeFileRepository(IEnumerable<FakeFile>? files)
        {
            Files = new Dictionary<string, byte[]>();

            if (files is null)
                return;
            
            foreach (var file in files)
            {
                Files.Add(file.Path, file.Content);
            }
        }
        
        private IDictionary<string, byte[]> Files { get; }
        
        public async Task<Stream> ReadFile(string path, CancellationToken token = default)
        {
            if (Files.TryGetValue(path, out var file))
                return new MemoryStream(file);
            
            throw new FileNotFoundException($"no file found in path: {path}");
        }

        public async Task<Stream> WriteFile(string path, CancellationToken token = default)
        {
            return new FakeWriteStream(this, path);
        }

        public async Task<bool> FileExists(string path, CancellationToken token = default)
        {
            return Files.ContainsKey(path);
        }

        public async Task<bool> DirectoryExists(string path, CancellationToken token = default)
        {
            return Files.Keys.Any(file => file.StartsWith(path));
        }

        public async Task CreateDirectory(string path, CancellationToken token = default)
        {
            if (!await DirectoryExists(path, token))
                Files.Add(Path.Combine(path, "/0.txt"), Array.Empty<byte>());
        }

        public async Task DeleteFile(string path, CancellationToken token = default)
        {
            Files.Remove(path);
        }

        public async Task DeleteDirectory(string path, CancellationToken token = default)
        {
            foreach (var file in Files.Keys.Where(file => file.StartsWith(path)).ToArray())
            {
                Files.Remove(file);
            }
        }

        private class FakeWriteStream : Stream, IDisposable
        {
            public FakeWriteStream(FakeFileRepository repository, string path)
            {
                Repository = repository;
                Path = path;
            }

            ~FakeWriteStream()
            {
                Dispose();
            }
            
            private FakeFileRepository Repository { get; }
            
            private string Path { get; }
            
            private MemoryStream Buffer { get; } = new();
            
            public override void Flush()
            {
                // no action required
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException();
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotSupportedException();
            }

            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }

            public override void Write(byte[] source, int offset, int count)
            {
                Buffer.Write(source, offset, count);
            }

            public new void Dispose()
            {
                GC.SuppressFinalize(this);
                base.Dispose();
                Repository.Files[Path] = Buffer.ToArray();
            }

            public override bool CanRead => false;
            public override bool CanSeek => false;
            public override bool CanWrite => true;
            public override long Length => throw new NotSupportedException();

            public override long Position
            {
                get => throw new NotSupportedException();
                set => throw new NotSupportedException();
            }
        }
    }
}

#pragma warning restore 1998