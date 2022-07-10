using System.Reactive.Linq;
using SimpleMu.Common.Extensions;
using SimpleMu.Common.Interfaces;

namespace SimpleMu;

public class ConfigWatcher : IInitializer
{
    private readonly IEnumerable<IReloadableFile> _configFiles;

    public ConfigWatcher(IEnumerable<IReloadableFile> configFiles)
    {
        FileHelpers.Create("Config");
        _configFiles                   = configFiles;
        var watcher = new FileSystemWatcher($"{AppDomain.CurrentDomain.BaseDirectory}\\Config");
        watcher.NotifyFilter          = NotifyFilters.LastWrite;
        watcher.Filter                = "*.json";
        watcher.IncludeSubdirectories = true;
        watcher.EnableRaisingEvents   = true;
        
        _fileChanged = Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(ev => watcher.Changed += ev,
         ev => watcher.Changed -= ev).Select(x => x.EventArgs);
    }

    private readonly IObservable<FileSystemEventArgs> _fileChanged;

    public void Initialize()
    {
        //Debounce for one second to prevent multiple config reloads on file change.
        _fileChanged.Throttle(TimeSpan.FromSeconds(1)).Subscribe(OnFileChanged);
    }

    private void OnFileChanged(FileSystemEventArgs e)
    {
        var configFile = _configFiles.FirstOrDefault(x => e.Name == x.FileName);
        if (configFile == null)
        {
            return;
        }
        
        configFile.FileContent = File.ReadAllText(e.FullPath);

        configFile.NotifyFileChanged();
    }
}