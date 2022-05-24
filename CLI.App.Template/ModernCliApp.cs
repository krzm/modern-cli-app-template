using Config.Wrapper;
using DIHelper;
using Unity;

namespace Modern.CLI.App.Template;

public class ModernCliApp
{
    private IDependencySuite? suite;

    public IDependencySuite? Suite => suite;

    public void Run(string[] args)
    {
        var unity = new UnityContainer()
            .AddExtension(new Diagnostic());
        var serviceSuite = new ServiceSuite(unity);
        serviceSuite.Register();
        suite = new AppSuiteConfig(
            unity.Resolve<IConfigReader>())
                .GetSuite(unity);
        IBootstraper booter = new Bootstraper(suite);
        booter.Boot(args);
    }
}