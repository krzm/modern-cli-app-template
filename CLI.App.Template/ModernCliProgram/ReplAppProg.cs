using CommandDotNet;
using CommandDotNet.Repl;
using CommandDotNet.Unity.Helper;
using Config.Wrapper;
using Serilog;

namespace Modern.CLI.App.Template;

public class ReplAppProg 
    : AppProgUnity<ReplAppProg>
{
	private static bool inSession;

    [Subcommand]
    public AppCommands? AppCommands { get; set; }

    public ReplAppProg(
        ILogger log
        , IConfigReader config) 
            : base(log, config)
    {
    }

    [DefaultCommand()]
    public void StartSession(
        CommandContext context,
        ReplSession replSession)
    {
        if (inSession == false)
        {
            context.Console.WriteLine("start session");
            inSession = true;
            replSession.Start();
        }
        else
        {
            context.Console.WriteLine($"no session {inSession}");
            context.ShowHelpOnExit = true;
        }
    }
}