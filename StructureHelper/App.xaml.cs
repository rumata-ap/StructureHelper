using StructureHelper.Services.Primitives;
using StructureHelper.UnitSystem;
using StructureHelper.Windows.MainWindow;
using StructureHelperLogics.Services.NdmCalculations;
using System.Windows;
using System.Threading;
using System.Globalization;
using Autofac;

namespace StructureHelper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IContainer Container { get; private set; }
        public static ILifetimeScope Scope { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            // Set culture to Russian (or detect from system)
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
            
            var builder = new ContainerBuilder();
            builder.RegisterType<PrimitiveRepository>().As<IPrimitiveRepository>().SingleInstance();
            builder.RegisterType<UnitSystemService>().AsSelf().SingleInstance();
            builder.RegisterType<CalculationService>().AsSelf().SingleInstance();
            builder.RegisterType<MainModel>().AsSelf().SingleInstance();
            builder.RegisterType<MainViewModel>().AsSelf().SingleInstance();

            builder.RegisterType<MainView>().AsSelf();

            Container = builder.Build();
            Scope = Container.Resolve<ILifetimeScope>();

            var window = Scope.Resolve<MainView>();
            window.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Scope.Dispose();
            base.OnExit(e);
        }
    }
}
