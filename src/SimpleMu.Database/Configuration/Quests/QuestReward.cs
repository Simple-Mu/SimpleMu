﻿// <copyright file="QuestReward.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

using SimpleMu.Database.Entities;

namespace SimpleMu.Database.Configuration.Quests;

/// <summary>
/// Defines the reward of a completed quest.
/// </summary>
public class QuestReward
{
    /// <summary>
    /// Gets or sets the type of the reward.
    /// </summary>
    /// <value>
    /// The type of the reward.
    /// </value>
    public QuestRewardType RewardType { get; set; }

    /// <summary>
    /// Gets or sets the value of the reward. It may have a different meaning, depending on the <see cref="RewardType"/>.
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// Gets or sets the item reward.
    /// The <see cref="Value"/> contains how often the item is rewarded.
    /// </summary>
    
    public virtual Item? ItemReward { get; set; }

    /// <summary>
    /// Gets or sets the attribute reward. It's set when <see cref="RewardType"/> is <see cref="QuestRewardType.Attribute"/>.
    /// </summary>
    //public virtual AttributeDefinition? AttributeReward { get; set; }
}