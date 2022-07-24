using System.ComponentModel.DataAnnotations;
using System.Text;
using SimpleMu.Database.Configuration.Items;

namespace SimpleMu.Database.Entities;

/// <summary>
///     The item.
/// </summary>
public class Item
{
    /// <summary>
    ///     Gets or sets the item slot in the <see cref="ItemStorage" />.
    /// </summary>
    public byte ItemSlot { get; set; }

    /// <summary>
    ///     Gets or sets the item definition.
    /// </summary>
    [Required]
    public virtual ItemDefinition? Definition { get; set; }

    /// <summary>
    ///     Gets or sets the currently remaining durability.
    /// </summary>
    public double Durability { get; set; }

    /// <summary>
    ///     Gets or sets the level of the item.
    /// </summary>
    public byte Level { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether this item instance provides the weapon skill while being equipped.
    /// </summary>
    public bool HasSkill { get; set; }

    /// <summary>
    ///     Gets or sets the item options.
    /// </summary>

    public virtual ICollection<ItemOptionLink> ItemOptions { get; protected set; } = null!;

    /// <summary>
    ///     Gets or sets the item set group (Ancient Set,).
    /// </summary>
    public virtual ICollection<ItemSetGroup> ItemSetGroups { get; protected set; } = null!;

    /// <summary>
    ///     Gets or sets the socket count. This limits the amount of socket options in the <see cref="ItemOptions" />.
    /// </summary>
    public int SocketCount { get; set; }

    /// <summary>
    ///     Gets or sets the price which was set by the player for his personal store.
    /// </summary>
    public int? StorePrice { get; set; }

    /// <summary>
    ///     Assigns the values of another item to this item.
    /// </summary>
    /// <param name="otherItem">The other item.</param>
    public void AssignValues(Item otherItem)
    {
        Definition  = otherItem.Definition;
        Durability  = otherItem.Durability;
        Level       = otherItem.Level;
        HasSkill    = otherItem.HasSkill;
        SocketCount = otherItem.SocketCount;
        if (otherItem.ItemOptions != null && otherItem.ItemOptions.Any())
        {
            ItemOptions.Clear();
            foreach (var option in otherItem.ItemOptions) ItemOptions.Add(CloneItemOptionLink(option));
        }

        if (otherItem.ItemSetGroups != null && otherItem.ItemSetGroups.Any())
        {
            ItemSetGroups.Clear();
            foreach (var setGroup in otherItem.ItemSetGroups) ItemSetGroups.Add(setGroup);
        }
    }

    /// <inheritdoc />
    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append("Slot ").Append(ItemSlot).Append(": ");

        if (ItemOptions.Any(o => o.ItemOption?.OptionType == ItemOptionTypes.Excellent))
        {
            stringBuilder.Append("Excellent ");
        }

        var ancientSet = ItemSetGroups.FirstOrDefault(s => s.AncientSetDiscriminator != 0);
        if (ancientSet != null)
        {
            stringBuilder.Append(ancientSet.Name).Append(" ");
        }

        stringBuilder.Append(Definition?.Name);
        if (Level > 0)
        {
            stringBuilder.Append("+").Append(Level);
        }

        foreach (var option in ItemOptions.OrderBy(o => o.ItemOption?.OptionType == ItemOptionTypes.Option))
        {
            //stringBuilder.Append("+").Append(option.ItemOption?.PowerUpDefinition);
        }

        if (HasSkill)
        {
            stringBuilder.Append("+Skill");
        }

        if (ItemOptions.Any(opt => opt.ItemOption?.OptionType == ItemOptionTypes.Luck))
        {
            stringBuilder.Append("+Luck");
        }

        if (SocketCount > 0)
        {
            stringBuilder.Append("+").Append(SocketCount).Append("S");
        }

        return stringBuilder.ToString();
    }

    /// <summary>
    ///     Clones the item option link.
    /// </summary>
    /// <param name="link">The link.</param>
    /// <returns>The cloned item option link.</returns>
    protected virtual ItemOptionLink CloneItemOptionLink(ItemOptionLink link)
    {
        return link.Clone();
    }
}