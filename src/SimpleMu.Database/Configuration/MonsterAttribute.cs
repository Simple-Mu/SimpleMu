namespace SimpleMu.Database.Configuration;

/// <summary>
///     The attribute and value of a monster.
/// </summary>
/// <remarks>
///     Just needed for entity framework, because it does not support the mapping of dictionaries. May be removed in the
///     future.
/// </remarks>
public class MonsterAttribute
{
    /// <summary>
    /// Gets or sets the attribute definition.
    /// </summary>
    //public virtual AttributeDefinition? AttributeDefinition { get; set; }

    /// <summary>
    ///     Gets or sets the value.
    /// </summary>
    public float Value { get; set; }

    /// <inheritdoc />
    //public override string ToString()
    //{
    //    return $"{this.AttributeDefinition}: {this.Value}";
    //}
}