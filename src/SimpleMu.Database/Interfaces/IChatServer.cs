﻿// <copyright file="IChatServer.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace SimpleMu.Database.Interfaces;

/// <summary>
/// The interface for a chat server.
/// </summary>
public interface IChatServer : IManageableServer
{
    /// <summary>
    /// Registers the client to the server.
    /// </summary>
    /// <param name="roomId">The room identifier.</param>
    /// <param name="clientName">Name of the client.</param>
    /// <returns>The authentication info.</returns>
    ChatServerAuthenticationInfo RegisterClient(ushort roomId, string clientName);

    /// <summary>
    /// Creates the chat room.
    /// </summary>
    /// <returns>The new chat room id.</returns>
    ushort CreateChatRoom();
}