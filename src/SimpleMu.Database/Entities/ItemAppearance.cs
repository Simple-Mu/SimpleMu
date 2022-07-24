using SimpleMu.Database.Configuration.Items;

namespace SimpleMu.Database.Entities;

/// <summary>
///     Appearance of an item.
/// </summary>
public class ItemAppearance
{
    /// <summary>
    ///     Gets or sets the item slot.
    /// </summary>
    public byte ItemSlot { get; set; }

    /// <summary>
    ///     Gets or sets the definition of the item.
    /// </summary>
    public virtual ItemDefinition? Definition { get; set; }

    /// <summary>
    ///     Gets or sets the level.
    /// </summary>
    public byte Level { get; set; }

    /// <summary>
    ///     Gets or sets the visible options.
    /// </summary>
    public virtual ICollection<ItemOptionType> VisibleOptions { get; protected set; } = null!;
}