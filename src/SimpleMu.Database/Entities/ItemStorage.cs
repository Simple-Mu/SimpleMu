namespace SimpleMu.Database.Entities;

/// <summary>
///     A storage where items can be stored.
/// </summary>
public class ItemStorage
{
    /// <summary>
    ///     Gets or sets the items which are stored.
    /// </summary>

    public virtual ICollection<Item> Items { get; protected set; } = null!;

    /// <summary>
    ///     Gets or sets the money which is stored.
    /// </summary>
    public int Money { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{Items?.Count ?? 0} Items, {Money} Money";
    }
}