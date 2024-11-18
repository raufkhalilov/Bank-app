using BankWPF.Services;
using BankWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BankWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
       protected override void OnStartup(StartupEventArgs e)
       {
            base.OnStartup(e);

            var dialogService = new DialogService();
            var mainViewModel = new ApplicationViewModel(dialogService);
            var mainWindow = new MainWindow { DataContext = mainViewModel };
            mainWindow.Show();
       }
    }
}
