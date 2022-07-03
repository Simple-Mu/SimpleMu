using SimpleMu.Common.BaseImplementations;
using SimpleMu.Common.Interfaces;

namespace SimpleMu.LoginServer;

public class LoginServerConfig : BaseConfigFile, IConfigFile
{
    public LoginServerConfig() : base("loginServer.json")
    {
        this.FileUpdated += () =>
        {
            Console.WriteLine(Name);
            Console.WriteLine(ID);
        };
    }

    public string Name { get; set; }

    public int ID { get; set; }
}