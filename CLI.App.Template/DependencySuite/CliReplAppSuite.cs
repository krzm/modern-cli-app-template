using CommandDotNet.Unity.Helper;
using DIHelper.Unity;
using Unity;

namespace Modern.CLI.App.Template;

public class CliReplAppSuite 
    : UnityDependencySuite
{
    public CliReplAppSuite(
        IUnityContainer container) 
        : base(container) 
    {
    }

    protected override void RegisterCommands() => 
        RegisterSet<AppCommandSet>();

    protected override void RegisterProgram() =>
        RegisterSet<AppProgSet<ReplAppProg>>();
}