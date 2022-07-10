// <copyright file="IConnectServer.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace SimpleMu.Database.Interfaces;

/// <summary>
/// The interface for a connect server.
/// </summary>
public interface IConnectServer : IManageableServer, IGameServerStateObserver
{
    /// <summary>
    /// Gets the settings.
    /// </summary>
    IConnectServerSettings Settings { get; }
}