using static System.Environment;

namespace e2e.infra;

public static class Config
{
    public static Uri ApiBaseAddress => new(ReadEnvVar("API_BASE_ADDRESS"));

    public static TimeSpan ApiTimeout => TimeSpan.FromSeconds(int.Parse(ReadEnvVar("API_TIMEOUT_SECS")));

    private static string ReadEnvVar(string name)
    {
        var value = GetEnvironmentVariable(name);

        if (value == null)
            throw new ArgumentOutOfRangeException(nameof(name), $"Environment variable {name} is missing or null");

        return value;
    }
}