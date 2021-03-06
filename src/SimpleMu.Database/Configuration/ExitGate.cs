using System.ComponentModel.DataAnnotations;

namespace SimpleMu.Database.Configuration;

/// <summary>
///     Defines a gate through which a player enters a map.
/// </summary>
public class ExitGate : Gate
{
    /// <summary>
    ///     Gets or sets the direction to which the player looks when he enters the map.
    /// </summary>
    public Direction Direction { get; set; }

    /// <summary>
    ///     Gets or sets the map which will be entered.
    /// </summary>
    [Required]
    public virtual GameMapDefinition? Map { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this instance is a spawn gate.
    ///     If it's not a spawn gate, it's a target of an <see cref="EnterGate" />.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is spawn gate; otherwise, <c>false</c>.
    /// </value>
    public bool IsSpawnGate { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{Map?.Name} @ {base.ToString()}";
    }
}