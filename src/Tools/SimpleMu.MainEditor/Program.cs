using System.Text;

if (args.Length <= 0)
{
    Console.WriteLine("Usage: Simple.MainEditor <input file>");
    return;
}

var programPath = args[0];

if (!File.Exists(programPath))
{
    Console.WriteLine("File not found: " + programPath);
    Console.ReadLine();
    return;
}

var       connect         = Encoding.Default.GetBytes("connect.muonline.webzen.com");
var       newValue        = Encoding.Default.GetBytes("127.0.0.1");
using var fileStream      = new FileStream(programPath, FileMode.Open, FileAccess.ReadWrite);
//var       connectPosition = FindBytes(fileStream, connect); // 0xA5F7B2
var       connectPosition = 0xA5F7B2; // 0xA5F7B2
using var writer          = new BinaryWriter(fileStream);

//GoTo the location of the IP address
writer.Seek(connectPosition, SeekOrigin.Begin);
//Write the new IP address
writer.Write(newValue);
//Erase the rest of the old IP address
for (var i = 0; i < 16 - newValue.Length; i++)
{
    writer.Write(0);
}
Console.WriteLine(connectPosition.ToString("X2"));
Console.WriteLine("Finished");

int FindBytes(Stream fs, IReadOnlyList<byte> bytes)
{
    int i;

    for (i = 0; i < fs.Length - bytes.Count; i++)
    {
        fs.Seek(i, SeekOrigin.Begin);
        int j;
        for (j = 0; j < bytes.Count; j++)
        {
            if (fs.ReadByte() != bytes[j])
            {
                break;
            }
        }
        
        //Reached the end of the file if we didn't find the bytes
        if (j == bytes.Count)
        {
            break;
        }
    }

    return i;
}