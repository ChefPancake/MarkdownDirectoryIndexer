using CommandLine;

namespace MarkdownDirectoryIndexer;

record ProgramOptions {
    [Option('r', "RootPath", Required = true, HelpText = "The path to index. Must be a Directory.")]
    public string? RootDirectoryPath { get; set; }

    [Option('o', "OutputPath", Required = true, HelpText = "Path to the ouptut file.")]
    public string? OutputFilePath { get; set; }
}
