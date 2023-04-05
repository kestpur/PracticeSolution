using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Prism.Ioc;
using Prism.Unity;


namespace PracticeGUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // this registers via interface a class into the container
            // containerRegistry.Register<Services.ICustomerStore, Services.DbCustomerStore>();
            // register other needed services here
        }
        protected override Window CreateShell()
        {
            var win = Container.Resolve<Views.MainWindow>();
            return win;
        }
    }
}
