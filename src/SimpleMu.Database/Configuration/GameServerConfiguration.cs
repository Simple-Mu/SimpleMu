namespace SimpleMu.Database.Configuration;

/// <summary>
///     Defines the game server configuration.
/// </summary>
public class GameServerConfiguration
{
    /// <summary>
    ///     Gets or sets the maximum number of players which can connect.
    /// </summary>
    public short MaximumPlayers { get; set; }

    /// <summary>
    ///     Gets or sets the maps which should be hosted on the server.
    /// </summary>
    public virtual ICollection<GameMapDefinition> Maps { get; protected set; } = null!;
}