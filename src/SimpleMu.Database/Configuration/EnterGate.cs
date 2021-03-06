using System.ComponentModel.DataAnnotations;

namespace SimpleMu.Database.Configuration;

/// <summary>
///     Defines a gate which a player can enter to move to another <see cref="ExitGate" />.
/// </summary>
public class EnterGate : Gate
{
    /// <summary>
    ///     Gets or sets the target gate.
    /// </summary>
    [Required]
    public virtual ExitGate? TargetGate { get; set; }

    /// <summary>
    ///     Gets or sets the level requirement which the player needs to move through the gate.
    /// </summary>
    public short LevelRequirement { get; set; }

    /// <summary>
    ///     Gets or sets the number of the gate.
    /// </summary>
    public short Number { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{base.ToString()} ({Number}) (Level {LevelRequirement}) to {TargetGate}";
    }
}