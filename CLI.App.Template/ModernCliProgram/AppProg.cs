using CommandDotNet;
using CommandDotNet.Unity.Helper;
using Config.Wrapper;
using Serilog;

namespace Modern.CLI.App.Template;

public class AppProg 
    : AppProgUnity<AppProg>
{
    [Subcommand]
    public AppCommands? AppCommands { get; set; }

    public AppProg(
        ILogger log
        , IConfigReader config) 
            : base(log, config)
    {
    }
}