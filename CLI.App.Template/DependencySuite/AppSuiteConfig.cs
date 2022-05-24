using CommandDotNet.Helper;
using Config.Wrapper;
using DIHelper;
using Unity;

namespace Modern.CLI.App.Template;

public class AppSuiteConfig
{
    private readonly IConfigReader configReader;

    public AppSuiteConfig(
        IConfigReader configReader
    )
    {
        this.configReader = configReader;
    }

    public IDependencySuite GetSuite(IUnityContainer unity)
    {
        var settings = configReader.GetConfigSection<CommandDotNetSettings>(nameof(CommandDotNetSettings));
        ArgumentNullException.ThrowIfNull(settings);
        if(settings.UseRepl)
            return new CliReplAppSuite(unity);
        else
            return new CliAppSuite(unity);
    }
}