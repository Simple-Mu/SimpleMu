namespace SimpleMu.Common.Interfaces;

public interface IReloadableFile
{
    string                            FileName    { get; }
    string                            FullPath    { get; }
    string                            FileContent { get; set; }
    event EventDelegates.VoidDelegate FileChanged;
    event EventDelegates.VoidDelegate FileUpdated;
    public void                       NotifyFileChanged();
}