using SimpleMu.Common.Extensions;
using SimpleMu.Common.Interfaces;

namespace SimpleMu;

public class ConfigWatcher : IInitializer
{
    private readonly IEnumerable<IConfigFile> _configFiles;

    public ConfigWatcher(IEnumerable<IConfigFile> configFiles)
    {
        FileHelpers.Create("Config");
        _configFiles                   = configFiles;
        _watcher                       = new FileSystemWatcher($"{AppDomain.CurrentDomain.BaseDirectory}\\Config");
        _watcher.NotifyFilter          = NotifyFilters.Size | NotifyFilters.LastWrite;
        _watcher.Filter                = "*.json";
        _watcher.IncludeSubdirectories = true;
        _watcher.EnableRaisingEvents   = true;
    }

    private readonly FileSystemWatcher _watcher;

    public void Initialize()
    {
        _watcher.Changed += OnFileChanged;
    }

    private void OnFileChanged(object sender, FileSystemEventArgs e)
    {
        var configFile = _configFiles.FirstOrDefault(x => e.Name == x.FileName);
        if (configFile == null)
        {
            return;
        }

        var fileContent = File.ReadAllText(e.FullPath);
        configFile.NotifyFileChanged(fileContent);
    }
}