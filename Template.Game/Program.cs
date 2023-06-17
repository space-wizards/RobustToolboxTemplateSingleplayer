using Robust.Client;

namespace Template.Game;

internal static class Program
{
    public static void Main(string[] args)
    {
        ContentStart.StartLibrary(args, new GameControllerOptions()
        {
            // DEVNOTE: Your options here!
                
            // We disable sandboxing given we're using RobustToolbox as a library, and we won't be on the hub.
            Sandboxing = false,
                
            // Projects with this prefix will be loaded by the engine.
            ContentModulePrefix = "Template.",
                
            // Name of the folder where the game will be built in. Also check Template.Game.csproj:9!
            ContentBuildDirectory = "Template.Game",
                
            // Default window name. This can also be changed on runtime with the IClyde service.
            DefaultWindowTitle = "RobustToolbox Template Game",
                
            // Name of the folder where the user's data (config, etc) will be stored.
            UserDataDirectoryName = "Template Game",
                
            // Name of the configuration file in the user's data directory.
            ConfigFileName = "config.toml",
                
            //SplashLogo = new ResourcePath("/path/to/splash/logo.png"),
                
            // Check "RobustToolbox/Resources/Textures/Logo/icon" for an example window icon set.
            //WindowIconSet = new ResourcePath("/path/to/folder/with/window/icon/set"),
                
            // There are a few more options, be sure to check them all!
        });
    }
}