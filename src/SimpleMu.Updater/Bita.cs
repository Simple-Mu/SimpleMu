using System.Text.RegularExpressions;
using CliWrap;

namespace SimpleMu.Updater;

public class Bita
{
    private static readonly Regex  FileNameFromUrlRegex = new(@"\w*\.\w[^ ]\w*(?=\.cba)");
    private readonly        string _bitaPath;

    public Bita(string bitaPath)
    {
        _bitaPath = bitaPath;
    }

    public async Task Clone(string url, string outputPath)
    {
        var fileName       = FileNameFromUrlRegex.Match(url).Value;
        var outputFileName = Path.Join(outputPath, fileName);
        var result = await Cli.Wrap(_bitaPath)
                              .WithArguments("clone")
                              .WithArguments("--seed-output")
                              .WithArguments(url)
                              .WithArguments(outputFileName)
                              .WithWorkingDirectory(outputPath)
                              .ExecuteAsync();
    }

    public async Task Compress(string filePath, string? outputDirectory = null)
    {
        outputDirectory ??= Path.GetDirectoryName(filePath);
        var outputFileName = $"{Path.GetFileName(filePath)}.cba";
        var output         = Path.Join(outputDirectory, outputFileName);

        await Cli.Wrap(_bitaPath)
                 .WithArguments("compress")
                 .WithArguments($"-i {filePath}")
                 .WithArguments(output)
                 .WithWorkingDirectory(Path.GetDirectoryName(filePath) ?? throw new InvalidOperationException())
                 .ExecuteAsync();
    }
}