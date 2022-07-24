namespace SimpleMu.Database.Interfaces;

/// <summary>
///     The guild member status of a guild member.
/// </summary>
public class GuildMemberStatus
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="GuildMemberStatus" /> class.
    /// </summary>
    /// <param name="guildId">The guild identifier.</param>
    /// <param name="position">The position.</param>
    public GuildMemberStatus(uint guildId, GuildPosition position)
    {
        GuildId  = guildId;
        Position = position;
    }

    /// <summary>
    ///     Gets the guild identifier.
    /// </summary>
    /// <value>
    ///     The guild identifier.
    /// </value>
    public uint GuildId { get; }

    /// <summary>
    ///     Gets the position.
    /// </summary>
    /// <value>
    ///     The position.
    /// </value>
    public GuildPosition Position { get; }
}