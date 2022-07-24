namespace SimpleMu.Database.Configuration;

/// <summary>
///     Defines a level dependent damage.
/// </summary>
public class LevelDependentDamage
{
    /// <summary>
    ///     Gets or sets the level belonging to this damage value.
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    ///     Gets or sets the damage belonging to this level.
    /// </summary>
    public int Damage { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"Level {Level}: {Damage}";
    }
}