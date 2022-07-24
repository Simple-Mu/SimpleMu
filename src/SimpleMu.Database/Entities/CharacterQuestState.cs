using SimpleMu.Database.Configuration.Quests;

namespace SimpleMu.Database.Entities;

/// <summary>
///     Keeps the progress state of a started quest.
///     It's only possible to have one quest of the same group active.
/// </summary>
public class CharacterQuestState
{
    /// <summary>
    ///     Gets or sets the group.
    /// </summary>
    public short Group { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether the game client action was performed.
    /// </summary>
    public bool ClientActionPerformed { get; set; }

    /// <summary>
    ///     Gets or sets the last finished quest of the <see cref="Group" />.
    /// </summary>
    public virtual QuestDefinition? LastFinishedQuest { get; set; }

    /// <summary>
    ///     Gets or sets the active quest.
    /// </summary>
    public virtual QuestDefinition? ActiveQuest { get; set; }

    /// <summary>
    ///     Gets or sets the requirement states for the current <see cref="ActiveQuest" />.
    /// </summary>
    public virtual ICollection<QuestMonsterKillRequirementState> RequirementStates { get; protected set; } = null!;
}