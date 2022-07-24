namespace SimpleMu.Database.Configuration.Items;

/// <summary>
///     The item slot type. Each of this may have one or more actual item slots.
/// </summary>
public class ItemSlotType
{
    /// <summary>
    ///     Gets or sets the description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the item slots of this slot type.
    /// </summary>
    public virtual ICollection<int> ItemSlots { get; protected set; } = null!;
}