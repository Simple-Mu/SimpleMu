namespace SimpleMu.Database.Interfaces;

/// <summary>
///     Special server ids.
/// </summary>
/// <remarks>Ids from 0 to 0xFFFF are reserved to game servers.</remarks>
public static class SpecialServerIds
{
    /// <summary>
    ///     The connect server special server id.
    /// </summary>
    public static readonly int ConnectServer = 0x10000;

    /// <summary>
    ///     The chat server special server id.
    /// </summary>
    public static readonly int ChatServer = 0x20000;
}