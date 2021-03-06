namespace SimpleMu.Database.Configuration.Items;

/// <summary>
///     Defines an item base power up definition.
/// </summary>
public class ItemBasePowerUpDefinition
{
    /// <summary>
    ///     Gets or sets the additional value to the base value.
    /// </summary>
    public float BaseValue;
    /// <summary>
    /// Gets or sets the target attribute.
    /// </summary>
    //public virtual AttributeDefinition? TargetAttribute { get; set; }

    /// <summary>
    /// Gets or sets the base value.
    /// </summary>
    //[Transient]
    //public ConstantElement? BaseValueElement { get; set; }

    /// <summary>
    ///     Gets or sets the bonus per level.
    /// </summary>

    public virtual ICollection<LevelBonus> BonusPerLevel { get; protected set; } = null!;
    //{
    //    get => this.BaseValueElement?.Value ?? 0;
    //    set => this.BaseValueElement = new ConstantElement(value);
    //}

    /// <inheritdoc />
    public override string ToString()
    {
        return string.Empty;
        //return $"{this.BaseValue} {this.TargetAttribute}";
    }
}