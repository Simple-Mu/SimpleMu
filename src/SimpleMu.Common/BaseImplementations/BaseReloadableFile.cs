using SimpleMu.Common.Extensions;
using SimpleMu.Common.Interfaces;

namespace SimpleMu.Common.BaseImplementations;

public abstract class BaseReloadableFile : IReloadableFile
{
    public string                             FileName    { get; }
    public string                             FullPath    { get; }
    public string                             FileContent { get; set; }
    public event EventDelegates.VoidDelegate? FileChanged;
    public event EventDelegates.VoidDelegate? FileUpdated;

    public BaseReloadableFile(string fileName)
    {
        FileName = fileName;
        FullPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\Config\\{fileName}";
        //FileHelpers.Create(FullPath);
        FileContent = FileHelpers.ReadNonBlock(FullPath);
    }

    public virtual void NotifyFileChanged()
    {
        FileChanged?.Invoke();
    }
    
    public virtual void NotifyFileUpdated()
    {
        FileUpdated?.Invoke();
    }

    public override string ToString()
    {
        return $"{FullPath}";
    }
}