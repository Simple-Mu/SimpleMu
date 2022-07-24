namespace SimpleMu.Database.Entities;

/// <summary>
///     A guild is a group of players who like to play together.
/// </summary>
public class Guild : Interfaces.Guild
{
    /// <summary>
    ///     Gets or sets the identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     Gets or sets the members.
    /// </summary>
    public virtual ICollection<GuildMember> Members { get; protected set; } = null!;
}