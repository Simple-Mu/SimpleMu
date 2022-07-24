using SimpleMu.Common.BaseImplementations;

namespace SimpleMu.LoginServer;

public class LoginServerConfig : BaseConfigFile
{
    public LoginServerConfig() : base("loginServer.json")
    {
        FileUpdated += () =>
        {
            Console.WriteLine(Name);
            Console.WriteLine(ID);
        };
    }

    public string Name { get; set; }

    public int ID { get; set; }
}