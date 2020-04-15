using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using PublicApi;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;

namespace WpfMefPluginSpike
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var container = new WindsorContainer();

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            container.Register(Classes.FromThisAssembly()
                                       .IncludeNonPublicTypes()
                                       .Where(type => type.GetCustomAttributes(false)
                                                          .Any(attribute => attribute is ExportAttribute))
                                       .WithServiceSelf()
                                       .WithServiceAllInterfaces()
                                       .LifestyleSingleton());

            container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter("plugins"))
                                       .IncludeNonPublicTypes()
                                       .Where(type => type.GetCustomAttributes(false)
                                                          .Any(attribute => attribute is ExportAttribute))
                                       .WithServiceSelf()
                                       .WithServiceAllInterfaces()
                                       .LifestyleSingleton());
            
            var resourceDictionaries = container.ResolveAll<IResourceDictionary>();

            // Merge exported resource dictionaries from all composed sources into the application
            foreach (var resourceDictionary in resourceDictionaries)
            {
                var rd = LoadComponent(resourceDictionary.Uri) as ResourceDictionary;
                Resources.MergedDictionaries.Add(rd);
            }

            var window = container.Resolve<MainWindow>();

            MainWindow = window;


            MainWindow.Show();

        }
    }
}
