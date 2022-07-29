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

    public async Task<bool> Clone(string url, string outputPath)
    {
        var fileName       = FileNameFromUrlRegex.Match(url).Value;
        var outputFileName = Path.Join(outputPath, fileName);
        var result = await Cli.Wrap(_bitaPath)
                              .WithArguments(args =>
                               {
                                   args.Add("clone");
                                   args.Add("--seed-output");
                                   args.Add(url);
                                   args.Add(outputFileName);
                               })
                              .WithWorkingDirectory(outputPath)
                               //.WithValidation(CommandResultValidation.None)
                              .ExecuteAsync();

        return result.ExitCode == 0;
    }

    public async Task<bool> Compress(string filePath, string? outputDirectory = null)
    {
        outputDirectory ??= Path.GetDirectoryName(filePath);
        var outputFileName = $"{Path.GetFileName(filePath)}.cba";
        var output         = Path.Join(outputDirectory, outputFileName);

        var result = await Cli.Wrap(_bitaPath)
                              .WithArguments(args =>
                               {
                                   args.Add("compress");
                                   args.Add($"-i {filePath}");
                                   args.Add(output);
                               })
                              .WithWorkingDirectory(Path.GetDirectoryName(filePath) ??
                                                    throw new InvalidOperationException())
                               //.WithValidation(CommandResultValidation.None)
                              .ExecuteAsync();

        return result.ExitCode == 0;
    }
}