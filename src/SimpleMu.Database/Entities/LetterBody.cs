﻿// <copyright file="LetterBody.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

using System.ComponentModel.DataAnnotations;
using SimpleMu.Database.Interfaces;

namespace SimpleMu.Database.Entities;

/// <summary>
/// The body of a letter.
/// </summary>

public class LetterBody
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the header.
    /// </summary>
    [Required]
    public virtual LetterHeader? Header { get; set; }

    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the rotation of the sender character.
    /// </summary>
    public byte Rotation { get; set; }

    /// <summary>
    /// Gets or sets the animation of the sender character.
    /// </summary>
    public byte Animation { get; set; }

    /// <summary>
    /// Gets or sets the sender appearance data.
    /// </summary>
    
    public virtual AppearanceData? SenderAppearance { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{this.Header}";
    }
}