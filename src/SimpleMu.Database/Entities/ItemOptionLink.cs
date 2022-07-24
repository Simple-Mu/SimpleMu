using System.ComponentModel.DataAnnotations;
using SimpleMu.Database.Configuration.Items;

namespace SimpleMu.Database.Entities;

/// <summary>
///     This class defines a link between the item and the concrete item option which the actual item instance possess.
/// </summary>
public class ItemOptionLink
{
    /// <summary>
    ///     Gets or sets the item option.
    ///     Link to <see cref="ItemDefinition.PossibleItemOptions" />, <see cref="ItemOptionDefinition.PossibleOptions" />.
    /// </summary>
    [Required]
    public virtual IncreasableItemOption? ItemOption { get; set; }

    /// <summary>
    ///     Gets or sets the level.
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    ///     Gets or sets the index of the option. This is required when the options are sorted, e.g. for socket options.
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    ///     Clones this instance.
    /// </summary>
    /// <returns>The cloned instance.</returns>
    public virtual ItemOptionLink Clone()
    {
        var link = new ItemOptionLink();
        link.AssignValues(this);
        return link;
    }

    /// <summary>
    ///     Assigns the values.
    /// </summary>
    /// <param name="otherLink">The other link.</param>
    public void AssignValues(ItemOptionLink otherLink)
    {
        ItemOption = otherLink.ItemOption;
        Level      = otherLink.Level;
        Index      = otherLink.Index;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return string.Empty;
        //var powerUpDefinition = this.ItemOption?.LevelDependentOptions?.FirstOrDefault(ldo => ldo.Level == this.Level)?.PowerUpDefinition ?? this.ItemOption?.PowerUpDefinition;
        //return powerUpDefinition?.ToString() ?? "empty";
    }
}