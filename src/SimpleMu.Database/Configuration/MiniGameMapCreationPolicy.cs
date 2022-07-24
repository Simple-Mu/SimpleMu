namespace SimpleMu.Database.Configuration;

/// <summary>
///     Defines how a mini game map is created.
/// </summary>
public enum MiniGameMapCreationPolicy
{
    /// <summary>
    ///     One map is created per party and game level.
    /// </summary>
    OnePerParty,

    /// <summary>
    ///     One map is created for each player.
    /// </summary>
    OnePerPlayer,

    /// <summary>
    ///     One map is created and shared for all players.
    /// </summary>
    Shared
}