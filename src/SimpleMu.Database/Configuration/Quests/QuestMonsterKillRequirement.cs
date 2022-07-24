using System.ComponentModel.DataAnnotations;

namespace SimpleMu.Database.Configuration.Quests;

/// <summary>
///     The monster kill requirement of a <see cref="QuestDefinition" />.
/// </summary>
public class QuestMonsterKillRequirement
{
    /// <summary>
    ///     Gets or sets the monster which must be killed.
    /// </summary>
    [Required]
    public virtual MonsterDefinition? Monster { get; set; }

    /// <summary>
    ///     Gets or sets the minimum number of killed <see cref="Monster" />s.
    /// </summary>
    public int MinimumNumber { get; set; }
}