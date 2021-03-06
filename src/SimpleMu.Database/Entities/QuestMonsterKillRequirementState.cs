using SimpleMu.Database.Configuration.Quests;

namespace SimpleMu.Database.Entities;

/// <summary>
///     Keeps the progress of the <see cref="QuestDefinition.RequiredMonsterKills" /> of the currently active quest.
/// </summary>
public class QuestMonsterKillRequirementState
{
    /// <summary>
    ///     Gets or sets the requirement for which this state is kept.
    /// </summary>
    public virtual QuestMonsterKillRequirement? Requirement { get; set; }

    /// <summary>
    ///     Gets or sets the monster kill count for this <see cref="Requirement" />.
    /// </summary>
    public int KillCount { get; set; }
}