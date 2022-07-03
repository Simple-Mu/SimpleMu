using System.Reactive.Linq;
using System.Reactive.Subjects;
using SimpleMu.Common.Extensions;
using SimpleMu.Common.Interfaces;

namespace SimpleMu.Common.BaseImplementations;

public abstract class BaseConfigFile : IConfigFile
{
    public           string              FileName    { get; }
    public           string              FullPath    { get; }
    public           IObservable<string> FileChanged { get; }
    private readonly Subject<string>     _fileChanged = new();

    public BaseConfigFile(string fileName)
    {
        FileName = fileName;
        FullPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\Config\\{fileName}";
        FileHelpers.Create(FullPath);
        FileChanged = _fileChanged.AsObservable();
    }

    public void NotifyFileChanged(string content)
    {
        _fileChanged.OnNext(content);
    }
}