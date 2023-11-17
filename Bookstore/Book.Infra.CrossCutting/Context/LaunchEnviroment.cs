namespace Book.Infra.CrossCutting.Context;

public partial class LaunchEnvironment
{
    public LaunchEnvironment() { }
    
    public static string DbConnectionString { get => Environment.GetEnvironmentVariable("DB_CONNECTION");  }
    
}