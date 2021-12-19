namespace Contracts;

public record FileEntry(
    string FileName)
    : IEntry;
public record DirectoryEntry(
    string FileName,
    IEnumerable<IEntry> Children)
    : IEntry;
public record DirectoryIndex(string RootPath, IEnumerable<IEntry> Entries);

