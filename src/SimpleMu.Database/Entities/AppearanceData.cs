using SimpleMu.Database.Configuration;

namespace SimpleMu.Database.Entities;

/// <summary>
///     The appearance data of an character.
/// </summary>
public class AppearanceData : IAppearanceData
{
    /// <summary>
    ///     Gets or sets the equipped items.
    /// </summary>

    public virtual ICollection<ItemAppearance> EquippedItems { get; protected set; } = null!;

    /// <summary>
    ///     Occurs when the appearance of the player changed.
    /// </summary>
    /// <remarks>
    ///     This never happens in this implementation.
    /// </remarks>
    public event EventHandler? AppearanceChanged;

    /// <summary>
    ///     Gets or sets the character class.
    /// </summary>
    public virtual CharacterClass? CharacterClass { get; set; }

    /// <inheritdoc />
    public CharacterPose Pose { get; set; }

    /// <inheritdoc />
    public bool FullAncientSetEquipped { get; set; }

    /// <inheritdoc />
    IEnumerable<ItemAppearance> IAppearanceData.EquippedItems => EquippedItems;
}