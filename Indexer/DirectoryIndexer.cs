using Contracts;

namespace Indexer;

public class DirectoryIndexer : IDirectoryIndexer {
    public DirectoryIndex IndexPath(string rootDirectoryPath) =>
        new DirectoryIndex(rootDirectoryPath, ListEntriesInPath(rootDirectoryPath));

    private static IEnumerable<IEntry> ListEntriesInPath(string path) =>
        Directory.EnumerateDirectories(path)
        .Select(GetDirectoryEntryFromPath)
        .Concat(
            Directory.EnumerateFiles(path)
            .Select(GetFileEntryFromPath));

    private static IEntry GetDirectoryEntryFromPath(string path) =>
        new DirectoryEntry(Path.GetFileName(path), ListEntriesInPath(path));

    private static IEntry GetFileEntryFromPath(string path) =>
        new FileEntry(Path.GetFileName(path));
}
