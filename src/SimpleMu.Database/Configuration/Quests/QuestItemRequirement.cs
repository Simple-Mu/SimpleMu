using System.ComponentModel.DataAnnotations;
using SimpleMu.Database.Configuration.Items;

namespace SimpleMu.Database.Configuration.Quests;

/// <summary>
///     Defines the required item(s) which should be in the inventory of the character
///     when the player requests to complete the quest.
/// </summary>
public class QuestItemRequirement
{
    /// <summary>
    ///     Gets or sets the required item.
    /// </summary>
    [Required]
    public virtual ItemDefinition? Item { get; set; }

    /// <summary>
    ///     Gets or sets the drop item group which should be considered when this quest is active and this requirement applies.
    /// </summary>
    public virtual DropItemGroup? DropItemGroup { get; set; }

    /// <summary>
    ///     Gets or sets the minimum number of <see cref="Item" />s.
    /// </summary>
    public int MinimumNumber { get; set; }
}