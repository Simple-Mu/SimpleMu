using System.ComponentModel.DataAnnotations;

namespace SimpleMu.Database.Configuration;

/// <summary>
///     Defines an endpoint of a server.
/// </summary>
public class ServerEndpoint
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ServerEndpoint" /> class.
    /// </summary>
    protected ServerEndpoint()
    {
    }

    /// <summary>
    ///     Gets or sets the network port on which the server is listening.
    /// </summary>
    public int NetworkPort { get; set; }

    /// <summary>
    ///     Gets or sets the client which is expected to connect.
    /// </summary>
    [Required]
    public virtual GameClientDefinition? Client { get; set; }

    /// <summary>
    ///     Returns a <see cref="string" /> that represents this instance.
    /// </summary>
    /// <returns>
    ///     A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        return $"Client: {Client?.Description}; Port: {NetworkPort}";
    }
}