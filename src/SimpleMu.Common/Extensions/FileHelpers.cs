namespace SimpleMu.Common.Extensions;

public static class FileHelpers
{
    /// <summary>
    /// Creates path or file if it doesn't exist.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static bool Create(string filePath)
    {
        try
        {
            var directory = Path.GetDirectoryName(filePath);
            if(directory == null || string.IsNullOrEmpty(directory))
            {
                directory = Path.Join(AppDomain.CurrentDomain.BaseDirectory, filePath);
            }
            
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
            if(File.Exists(filePath))
            {
                return false;
            }
            
            File.Create(filePath).Close();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static string ReadNonBlock(string path)
    {
        using var fs          = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var sr          = new StreamReader(fs);
        var       fileContent = sr.ReadToEnd();
        return fileContent;
    }
}