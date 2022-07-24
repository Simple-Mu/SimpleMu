namespace SimpleMu.Database.Configuration;

/// <summary>
///     The root of a master skill tree. One character can have more than one root.
/// </summary>
public class MasterSkillRoot
{
    /// <summary>
    ///     Gets or sets the identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     Gets or sets the name.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}