namespace SimpleMu.Database.Configuration.Items;

/// <summary>
///     Defines a bonus which gets granted when the equipped items
///     have at least the specified required item options in total.
/// </summary>
/// <remarks>
///     Usage example: The "Socket Package Options" when a character wears socket items with all kind of elemental options.
/// </remarks>
public class ItemOptionCombinationBonus
{
    /// <summary>
    ///     Gets or sets the description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the number.
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this bonus applies multiple times, for each set of found options.
    /// </summary>
    public bool AppliesMultipleTimes { get; set; }

    /// <summary>
    ///     Gets or sets the required item options which all have to be fulfilled in order to get the <see cref="Bonus" />.
    /// </summary>

    public virtual ICollection<CombinationBonusRequirement> Requirements { get; protected set; } = null!;

    /// <summary>
    /// Gets or sets the bonus power up.
    /// </summary>

    //public virtual PowerUpDefinition? Bonus { get; set; }
}