namespace SimpleMu.Database.Configuration;

/// <summary>
///     Defines a gate through which a player can exit or enter to other maps.
/// </summary>
public class Gate
{
    /// <summary>
    ///     Gets or sets the upper left corner, x-coordinate.
    /// </summary>
    public byte X1 { get; set; }

    /// <summary>
    ///     Gets or sets the upper left corner, y-coordinate.
    /// </summary>
    public byte Y1 { get; set; }

    /// <summary>
    ///     Gets or sets the bottom right corner, x-coordinate.
    /// </summary>
    public byte X2 { get; set; }

    /// <summary>
    ///     Gets or sets the bottom right corner, y-coordinate.
    /// </summary>
    public byte Y2 { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        var start = $"({X1}, {Y1})";
        if (X1 == X2 && Y1 == Y2)
        {
            return start;
        }

        return $"{start} - ({X2}, {Y2})";
    }
}