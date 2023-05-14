using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SF.WPF.EmployeeManagement.Models;
using SF.WPF.EmployeeManagement.ViewModels;
using SF.WPF.EmployeeManagement.Views;
using Unity;

namespace SF.WPF.EmployeeManagement
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer unityContainer = new UnityContainer();

            unityContainer.RegisterType<IEmployeeRepository, EmployeeRepository>();
            unityContainer.RegisterType<IEmployeesViewModel, EmployeesViewModel>();
            unityContainer.RegisterType<ILogger, Logger>();
            unityContainer.RegisterType<IEmployeeViewModel, EmployeeViewModel>();

            unityContainer.Resolve<EmployeesView>().Show();
        }
    }
}
