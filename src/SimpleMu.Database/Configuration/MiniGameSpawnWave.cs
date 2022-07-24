namespace SimpleMu.Database.Configuration;

/// <summary>
///     Defines a spawn wave of a <see cref="MiniGameDefinition" />.
/// </summary>
public class MiniGameSpawnWave
{
    /// <summary>
    ///     Gets or sets the number of the wave, <seealso cref="MonsterSpawnArea.WaveNumber" />.
    /// </summary>
    public byte WaveNumber { get; set; }

    /// <summary>
    ///     Gets or sets the description about this wave.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     Gets or sets a message which is shown to the player when the wave starts.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    ///     Gets or sets the starting time of the wave.
    /// </summary>
    public TimeSpan StartTime { get; set; }

    /// <summary>
    ///     Gets or sets the end time of the wave.
    /// </summary>
    public TimeSpan EndTime { get; set; }
}