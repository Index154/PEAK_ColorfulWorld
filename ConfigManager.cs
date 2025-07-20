using BepInEx.Configuration;

namespace ColorfulWorld;

public class ConfigManager()
{
    internal ConfigEntry<bool> sample = null!;

    internal void Setup(ConfigFile configFile)
    {
        sample = configFile.Bind("1. General", "Sample", false, new ConfigDescription("Sample setting"));
    }
}