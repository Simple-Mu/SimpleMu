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
        _watcher                       = new FileSystemWatcher($"{AppDomain.CurrentDomain.BaseDirectory}\\Config");
        _watcher.NotifyFilter          = NotifyFilters.LastWrite;
        _watcher.Filter                = "*.json";
        _watcher.IncludeSubdirectories = true;
        _watcher.EnableRaisingEvents   = true;
    }

    private readonly FileSystemWatcher                _watcher;
    private          IObservable<FileSystemEventArgs> _fileChanged;

    public void Initialize()
    {
        _fileChanged = Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(ev => _watcher.Changed += ev,
                                                                     ev => _watcher.Changed -= ev).Select(x => x.EventArgs);
        
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