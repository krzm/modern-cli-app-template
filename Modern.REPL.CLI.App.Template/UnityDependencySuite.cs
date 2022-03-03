using DIHelper;
using Unity;

namespace Modern.CLI.App.Template;

public class UnityDependencySuite 
    : DIHelper.Unity.UnityDependencySuite
{
    public UnityDependencySuite(
        IUnityContainer container) 
        : base(container) 
    {
    }

    protected override void RegisterCommands() => 
        RegisterSet<AppCommandSet>();

    protected override void RegisterProgram() => 
        Container.RegisterSingleton<IAppProgram, AppProgram>();
}