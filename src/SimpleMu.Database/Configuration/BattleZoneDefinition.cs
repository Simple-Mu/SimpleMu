﻿namespace SimpleMu.Database.Configuration;

/// <summary>
///     Defines a battle zone.
/// </summary>
public class BattleZoneDefinition
{
    /// <summary>
    ///     Gets or sets the battle type.
    /// </summary>
    public BattleType Type { get; set; }

    /// <summary>
    ///     Gets or sets the x-coordinate of the upper spawn point for the left team.
    /// </summary>
    public byte? LeftTeamSpawnPointX { get; set; }

    /// <summary>
    ///     Gets or sets the y-coordinate of the upper spawn point for the left team.
    /// </summary>
    public byte LeftTeamSpawnPointY { get; set; }

    /// <summary>
    ///     Gets or sets the x-coordinate of the upper spawn point for the right team.
    /// </summary>
    public byte? RightTeamSpawnPointX { get; set; }

    /// <summary>
    ///     Gets or sets the y-coordinate of the upper spawn point for the right team.
    /// </summary>
    public byte RightTeamSpawnPointY { get; set; }

    /// <summary>
    ///     Gets or sets the battle ground.
    /// </summary>

    public virtual Rectangle? Ground { get; set; }

    /// <summary>
    ///     Gets or sets the first goal zone.
    /// </summary>

    public virtual Rectangle? LeftGoal { get; set; }

    /// <summary>
    ///     Gets or sets the second goal zone.
    /// </summary>

    public virtual Rectangle? RightGoal { get; set; }
}