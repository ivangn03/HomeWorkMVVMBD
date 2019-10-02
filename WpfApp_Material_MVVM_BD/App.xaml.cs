using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Ninject;
using WpfApp_Material_MVVM_BD.Moduls;

namespace WpfApp_Material_MVVM_BD
{
    public partial class App : Application
    {
        private IKernel kernel;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureKernal();
            ComposeObjects();
            Current.MainWindow.Show();
        }
        private void ConfigureKernal()
        {
            this.kernel = new StandardKernel(new MyModule());
        }
        private void ComposeObjects()
        {
            Current.MainWindow = this.kernel.Get<MainWindow>();
        }

    }
}
