namespace SimpleMu.Common.Interfaces;

public interface IConfigFile
{
    string              FileName    { get; }
    string              FullPath    { get; }
    IObservable<string> FileChanged { get; }
    public void         NotifyFileChanged(string content);
}