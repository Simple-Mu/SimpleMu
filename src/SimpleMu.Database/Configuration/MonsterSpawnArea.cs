namespace SimpleMu.Database.Configuration;

/// <summary>
///     Defines the trigger when a monster spawns.
/// </summary>
public enum SpawnTrigger
{
    /// <summary>
    ///     The monster spawns and respawns automatically.
    /// </summary>
    Automatic,

    /// <summary>
    ///     The monster spawns automatically during an event.
    /// </summary>
    AutomaticDuringEvent,

    /// <summary>
    ///     The monster spawns just once at the beginning of an event.
    /// </summary>
    /// <remarks>
    ///     For example blood castle gates, statues. Also golden monsters.
    /// </remarks>
    OnceAtEventStart,

    /// <summary>
    ///     The monster spawns automatically during a wave of an event.
    /// </summary>
    /// <remarks>
    ///     For example, at devil square different monsters spawn in different waves.
    /// </remarks>
    AutomaticDuringWave,

    /// <summary>
    ///     The monster spawns once at the start of a wave of an event.
    /// </summary>
    /// <remarks>
    ///     For example, at devil square there is a wave of bosses, which spawn only once.
    /// </remarks>
    OnceAtWaveStart
}

/// <summary>
///     Defines an monster spawn area.
/// </summary>
public class MonsterSpawnArea
{
    /// <summary>
    ///     Gets or sets the monster definition.
    /// </summary>
    public virtual MonsterDefinition? MonsterDefinition { get; set; }

    /// <summary>
    ///     Gets or sets the game map.
    /// </summary>
    public virtual GameMapDefinition? GameMap { get; set; }

    /// <summary>
    ///     Gets or sets the upper left corner x coordinate.
    /// </summary>
    public byte X1 { get; set; }

    /// <summary>
    ///     Gets or sets the upper left corner y coordinate.
    /// </summary>
    public byte Y1 { get; set; }

    /// <summary>
    ///     Gets or sets the bottom right corner x coordinate.
    /// </summary>
    public byte X2 { get; set; }

    /// <summary>
    ///     Gets or sets the bottom right corner y coordinate.
    /// </summary>
    public byte Y2 { get; set; }

    /// <summary>
    ///     Gets or sets the looking direction when spawning.
    /// </summary>
    public Direction Direction { get; set; }

    /// <summary>
    ///     Gets or sets the quantity of monsters which should spawn in the defined area.
    /// </summary>
    public short Quantity { get; set; }

    /// <summary>
    ///     Gets or sets the spawn trigger.
    /// </summary>
    public SpawnTrigger SpawnTrigger { get; set; }

    /// <summary>
    ///     Gets or sets the wave to which this spawn area belongs to.
    /// </summary>
    public byte WaveNumber { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        var isPoint = X1 == X2 && Y1 == Y2;
        var result = isPoint
                         ? $"{MonsterDefinition?.Designation} - Quantity: {Quantity} - At: {X1}/{Y1}"
                         : $"{MonsterDefinition?.Designation} - Quantity: {Quantity} - Area: {X1}/{Y1} to {X2}/{Y2}";

        if (SpawnTrigger == SpawnTrigger.AutomaticDuringWave || SpawnTrigger == SpawnTrigger.OnceAtWaveStart)
        {
            result += $" - Wave: {WaveNumber}";
        }

        return result;
    }
}