using CommandLine;
using Indexer;
using MarkdownDirectoryIndexer;
using MarkdownWriter;
using Utilities;

Parser parser= new Parser();
ParserResult<ProgramOptions> result = parser.ParseArguments<ProgramOptions>(args)
    .WithParsed(DoThing)
    .WithNotParsed(_ => WriteHelpText());

static void DoThing(ProgramOptions options) {
    DirectoryIndexer indexer = new();
    MarkdownIndexWriter writer = new();
    if (options.RootDirectoryPath is not null && options.OutputFilePath is not null) {
        Console.WriteLine("Reading from directory...");
        var index = indexer.IndexPath(options.RootDirectoryPath);
        Console.WriteLine("Writing to output file");
        writer.WriteIndexToPath(index, options.OutputFilePath);
    }
}

static void WriteHelpText() =>
    new[] {
        "-- Mindex --",
        "This tool will create an index file in markdown format for the supplied directory",
        "-- Usage --",
        "- Flags -",
        "-r, --RootPath     [Path to index]",
        "-o, --OutputPath   [Path to output file]",
    }.Pipe(x => string.Join(Environment.NewLine, x))
    .Pipe(Console.WriteLine);