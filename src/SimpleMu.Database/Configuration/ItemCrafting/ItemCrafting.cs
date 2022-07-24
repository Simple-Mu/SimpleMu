namespace SimpleMu.Database.Configuration.ItemCrafting;

/// <summary>
///     Description of IItemCrafting.
/// </summary>
public class ItemCrafting
{
    /// <summary>
    ///     Gets or sets the number.
    /// </summary>
    /// <remarks>
    ///     Referenced by the client with this number.
    /// </remarks>
    public byte Number { get; set; }

    /// <summary>
    ///     Gets or sets the name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the name of the item crafting handler class.
    /// </summary>
    public string ItemCraftingHandlerClassName { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the simple crafting settings.
    /// </summary>

    public virtual SimpleCraftingSettings? SimpleCraftingSettings { get; set; }
}