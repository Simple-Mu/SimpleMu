﻿// -----------------------------------------------------------------------

namespace SimpleMu.Database.Interfaces;

/// <summary>
///     Interface of the login server, which keeps track of all connected accounts.
/// </summary>
public interface ILoginServer
{
    /// <summary>
    ///     Tries to login the account on the specified server.
    /// </summary>
    /// <param name="accountName">Name of the account.</param>
    /// <param name="serverId">The server identifier.</param>
    /// <returns>The success.</returns>
    bool TryLogin(string accountName, byte serverId);

    /// <summary>
    ///     Logs the account off from the specified server.
    /// </summary>
    /// <param name="accountName">Name of the account.</param>
    /// <param name="serverId">The server identifier.</param>
    void LogOff(string accountName, byte serverId);
}