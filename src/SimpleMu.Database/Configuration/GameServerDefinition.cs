using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SimpleMu.Database.Configuration;

/// <summary>
///     Defines the configuration of a game server.
/// </summary>
public class GameServerDefinition
{
    /// <summary>
    ///     Gets or sets the server identifier.
    /// </summary>
    public byte ServerID { get; set; }

    /// <summary>
    ///     Gets or sets the description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the experience rate for the specific server.
    ///     Be aware that this multiplies with the <see cref="Configuration.GameConfiguration.ExperienceRate" />.
    /// </summary>
    public float ExperienceRate { get; set; }

    /// <summary>
    ///     Gets or sets the server configuration.
    /// </summary>
    [Required]
    public virtual GameServerConfiguration? ServerConfiguration { get; set; }

    /// <summary>
    ///     Gets or sets the game configuration.
    /// </summary>
    [Required]
    public virtual GameConfiguration? GameConfiguration { get; set; }

    /// <summary>
    ///     Gets or sets the endpoints of the game server.
    /// </summary>

    public virtual ICollection<GameServerEndpoint> Endpoints { get; protected set; } = null!;

    /// <inheritdoc />
    public override string ToString()
    {
        return string.Format(CultureInfo.InvariantCulture, "[GameServerDefinition ServerID={0}, Description={1}]",
                             ServerID, Description);
    }
}