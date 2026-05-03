[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]

namespace JanZi.Csv.Tests;

[TestClass]
public static class Config
{
    private const string OutputFolderName = "Output";
    private const string InputFolderName = "Input";
    
    public static string BaseDirectory => AppDomain.CurrentDomain.BaseDirectory;
    public static string InputDirectory  => Path.Combine(BaseDirectory, InputFolderName);
    public static string OutputDirectory => Path.Combine(BaseDirectory, OutputFolderName);
    
    [AssemblyInitialize]
    public static void AssemblyInit(TestContext context)
    {
        CreateDirectoryIfNotExists(InputDirectory);
        CreateDirectoryIfNotExists(OutputDirectory);
    }

    private static void CreateDirectoryIfNotExists(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }
}