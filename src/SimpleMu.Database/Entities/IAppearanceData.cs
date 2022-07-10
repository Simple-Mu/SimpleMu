// <copyright file="IAppearanceData.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

using SimpleMu.Database.Configuration;

namespace SimpleMu.Database.Entities;

/// <summary>
/// The interface for the appearance data.
/// </summary>
public interface IAppearanceData
{
    /// <summary>
    /// Occurs when the appearance of the player changed.
    /// </summary>
    event EventHandler? AppearanceChanged;

    /// <summary>
    /// Gets the character class.
    /// </summary>
    CharacterClass? CharacterClass { get; }

    /// <summary>
    /// Gets the current pose.
    /// </summary>
    CharacterPose Pose { get; }

    /// <summary>
    /// Gets a value indicating whether a full ancient set is equipped.
    /// </summary>
    bool FullAncientSetEquipped { get; }

    /// <summary>
    /// Gets the equipped items.
    /// </summary>
    IEnumerable<ItemAppearance> EquippedItems { get; }
}