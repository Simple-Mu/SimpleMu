namespace SimpleMu.Database.Interfaces;

/// <summary>
///     The type of a <see cref="IManageableServer" />.
/// </summary>
public enum ServerType
{
    /// <summary>
    ///     Undefined type.
    /// </summary>
    Undefined = 0,

    /// <summary>
    ///     A game server.
    /// </summary>
    GameServer = 1,

    /// <summary>
    ///     A connect server.
    /// </summary>
    ConnectServer = 2,

    /// <summary>
    ///     A chat server.
    /// </summary>
    ChatServer = 3
}