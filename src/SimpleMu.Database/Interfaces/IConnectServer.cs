namespace SimpleMu.Database.Interfaces;

/// <summary>
///     The interface for a connect server.
/// </summary>
public interface IConnectServer : IManageableServer, IGameServerStateObserver
{
    /// <summary>
    ///     Gets the settings.
    /// </summary>
    IConnectServerSettings Settings { get; }
}