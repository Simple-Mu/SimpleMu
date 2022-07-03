using SimpleMu.Common.BaseImplementations;

namespace SimpleMu.LoginServer;

public class LoginServerConfig : BaseConfigFile
{
    public LoginServerConfig() : base("loginServer.json")
    {
    }

    public string Name { get; set; }
}