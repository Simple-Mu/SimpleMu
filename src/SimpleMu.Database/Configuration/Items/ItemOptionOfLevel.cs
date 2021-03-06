namespace SimpleMu.Database.Configuration.Items;

/// <summary>
///     The item option, depending on the specified item level.
/// </summary>
public class ItemOptionOfLevel
{
    /// <summary>
    ///     Gets or sets the level.
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    ///     Gets or sets the required item level.
    /// </summary>
    public int RequiredItemLevel { get; set; }

    /// <summary>
    /// Gets or sets the power up definition.
    /// </summary>

    //public virtual PowerUpDefinition? PowerUpDefinition { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"Level {Level}:"; // {this.PowerUpDefinition}";
    }
}