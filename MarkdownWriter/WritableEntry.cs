using Contracts;

namespace MarkdownWriter {
    internal record WritableEntry(IEntry Entry, string AbsolutePath, uint Depth) {
        public IEnumerable<WritableEntry> ListChildren() =>
            Entry is DirectoryEntry dir
            ? dir.Children.Select(x => new WritableEntry(x, Path.Combine(AbsolutePath, x.FileName), Depth + 1))
            : Array.Empty<WritableEntry>();
    }
}