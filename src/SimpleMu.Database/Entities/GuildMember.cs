using SimpleMu.Database.Interfaces;

namespace SimpleMu.Database.Entities;

/// <summary>
///     Information about a guild member.
/// </summary>
public class GuildMember
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="GuildMember" /> class.
    /// </summary>
    public GuildMember()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="GuildMember" /> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    public GuildMember(Guid id)
    {
        Id = id;
    }

    /// <summary>
    ///     Gets or sets the identifier. Should be the same id as the character id to which it belongs.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     Gets or sets the guild identifier to which the member belongs.
    /// </summary>
    public Guid GuildId { get; set; }

    /// <summary>
    ///     Gets or sets the status of the member.
    /// </summary>
    public GuildPosition Status { get; set; }
}