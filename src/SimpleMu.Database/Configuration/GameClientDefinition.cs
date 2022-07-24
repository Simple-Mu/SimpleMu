using SimpleMu.Database.Interfaces;

namespace SimpleMu.Database.Configuration;

/// <summary>
///     Defines a game client.
/// </summary>
public class GameClientDefinition : IGameClientVersion
{
    /// <summary>
    /// Gets or sets the language.
    /// </summary>
    //public ClientLanguage Language { get; set; }

    /// <summary>
    ///     Gets or sets the version which is defined in the client binaries.
    /// </summary>
    public byte[]? Version { get; set; }

    /// <summary>
    ///     Gets or sets the serial which is defined in the client binaries.
    /// </summary>
    public byte[]? Serial { get; set; }

    /// <summary>
    ///     Gets or sets the season.
    /// </summary>
    public byte Season { get; set; }

    /// <summary>
    ///     Gets or sets the episode.
    /// </summary>
    public byte Episode { get; set; }

    /// <inheritdoc />
    byte[] IGameClientVersion.Version => Version ?? throw new InvalidOperationException("Version not initialized.");

    /// <inheritdoc />
    byte[] IGameClientVersion.Serial => Serial ?? throw new InvalidOperationException("Serial not initialized.");

    /// <summary>
    ///     Gets or sets the description.
    /// </summary>
    public string Description { get; set; } = string.Empty;
}