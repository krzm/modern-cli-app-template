using CommandDotNet;
using CommandDotNet.Helper;
using CommandDotNet.Repl;
using Unity;

namespace Modern.CLI.App.Template;

public class AppProgram 
    : AppProgramUnity<AppProgram>
{
	private static bool inSession;

    [Subcommand]
    public AppCommands? AppCommands { get; set; }

    public AppProgram(
        IUnityContainer container) 
            : base(container)
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