using Contracts;
using Utilities;

namespace MarkdownWriter;

public class MarkdownIndexWriter : IIndexWriter {
    public void WriteIndexToPath(DirectoryIndex index, string outputPath) {
        string outputDir = Path.GetDirectoryName(outputPath)
            ?? throw new ArgumentNullException(nameof(outputPath));
        Directory.CreateDirectory(outputDir);
        File.WriteAllLines(
            outputPath,
            index.Entries.Select(x => new WritableEntry(x, Path.Combine(index.RootPath, x.FileName), 0))
            .SelectMany(ListAllEntriesWithChildren)
            .Select(ConvertToMarkdownLine));
    }

    private static IEnumerable<WritableEntry> ListAllEntriesWithChildren(WritableEntry entry) {
        yield return entry;
        foreach (WritableEntry child
                in entry.ListChildren().SelectMany(ListAllEntriesWithChildren)) {
            yield return child;
        }
    }

    private static string ConvertToMarkdownLine(WritableEntry entry) =>
        $"{new string('\t'.Replicate(entry.Depth).ToArray())}- [{entry.Entry.FileName}](<file:///{new Uri(entry.AbsolutePath).AbsolutePath}>)";
}
