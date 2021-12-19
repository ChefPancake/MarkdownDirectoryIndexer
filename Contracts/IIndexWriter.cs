namespace Contracts;

public interface IIndexWriter {
    void WriteIndexToPath(DirectoryIndex index, string outputPath);
}
