using System.Globalization;
using SimpleMu.Database.Configuration.Items;

namespace SimpleMu.Database.Configuration.ItemCrafting;

/// <summary>
///     Describes an required item for a crafting.
/// </summary>
public class ItemCraftingRequiredItem
{
    /// <summary>
    ///     Gets or sets the collection of possible items which are valid for this requirement.
    /// </summary>
    public virtual ICollection<ItemDefinition> PossibleItems { get; protected set; } = null!;

    /// <summary>
    ///     Gets or sets the minimum item level.
    /// </summary>
    public byte MinimumItemLevel { get; set; }

    /// <summary>
    ///     Gets or sets the maximum item level.
    /// </summary>
    public byte MaximumItemLevel { get; set; }

    /// <summary>
    ///     Gets or sets the required item options.
    /// </summary>
    public virtual ICollection<ItemOptionType> RequiredItemOptions { get; protected set; } = null!;

    /// <summary>
    ///     Gets or sets the minimum amount.
    /// </summary>
    public byte MinimumAmount { get; set; }

    /// <summary>
    ///     Gets or sets the maximum amount.
    /// </summary>
    public byte MaximumAmount { get; set; }

    /// <summary>
    ///     Gets or sets the success result.
    /// </summary>
    public MixResult SuccessResult { get; set; }

    /// <summary>
    ///     Gets or sets the fail result.
    /// </summary>
    public MixResult FailResult { get; set; }

    /// <summary>
    ///     Gets or sets the NPC price divisor. For each full division, the percentage gets increased by 1 percent, and the mix
    ///     price rises.
    /// </summary>
    public int NpcPriceDivisor { get; set; }

    /// <summary>
    ///     Gets or sets the add percentage per item.
    /// </summary>
    public byte AddPercentage { get; set; }

    /// <summary>
    ///     Gets or sets the reference identifier to the corresponding <see cref="ItemCraftingResultItem.Reference" />.
    ///     If <c>0</c>, no reference exists.
    /// </summary>
    public byte Reference { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        string itemName;
        if (!PossibleItems.Any())
        {
            itemName = "Random Item";
        }
        else
        {
            itemName = string.Join(", ", PossibleItems.Select(p => p.Name));
        }

        var amount = MinimumAmount == MaximumAmount
                         ? MinimumAmount.ToString(CultureInfo.InvariantCulture)
                         : $"{MinimumAmount}~{MaximumAmount}";

        string level;
        if (MinimumItemLevel == MaximumItemLevel && MinimumItemLevel == 0)
        {
            level = string.Empty;
        }
        else if (MinimumItemLevel == MaximumItemLevel)
        {
            level = $"+{MinimumItemLevel}";
        }
        else
        {
            level = $"+{MinimumItemLevel}~{MaximumItemLevel}";
        }

        string options;
        if (RequiredItemOptions.Any())
        {
            options = "+" + string.Join("+", RequiredItemOptions.Select(o => o.Name));
        }
        else
        {
            options = string.Empty;
        }

        return $"{amount} x {itemName}{level}{options}";
    }
}