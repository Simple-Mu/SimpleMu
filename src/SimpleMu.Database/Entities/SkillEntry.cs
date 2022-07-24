using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SimpleMu.Database.Configuration;

namespace SimpleMu.Database.Entities;

/// <summary>
///     An actual entry of a skill in the characters skill list.
/// </summary>
public class SkillEntry : INotifyPropertyChanged
{
    private int level;

    /// <summary>
    ///     Gets or sets the skill definition.
    /// </summary>
    [Required]
    public virtual Skill? Skill { get; set; }

    /// <summary>
    ///     Gets or sets the level of the skill, primarily master skill level.
    /// </summary>
    public int Level
    {
        get => level;

        set
        {
            if (level != value)
            {
                level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
    }

    /// <summary>
    ///     Occurs when a property changed.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Gets or sets the power up element of this skill of this player. It is a "cached" element which will be created on demand and can be applied multiple times.
    /// </summary>
    //[Transient]
    //public IElement? BuffPowerUp { get; set; }

    /// <summary>
    /// Gets or sets the duration of the <see cref="BuffPowerUp"/>.
    /// </summary>
    /// <remarks>
    /// It is an IElement, because the duration can be dependent from the player attributes.
    /// </remarks>
    //[Transient]
    //public IElement? PowerUpDuration { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{Skill?.Name}{(Level > 0 ? ", Level: " + Level : string.Empty)}";
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}