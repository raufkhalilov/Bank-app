using BankWPFCore.Commands;
using BankWPFCore.Models.Helpers;
using BankWPFCore.Services;
using BankWPFCore.Services.ApiServices.Creators;
using BankWPFCore.Services.ApiServices.Providers;
using BankWPFCore.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankWPFCore.ViewModels
{
    internal class SettingsViewModel : BaseViewModel
    {
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; set; }

        public NavigationViewModel NavigationViewModel { get; }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ICommand ChangeApi {  get; }

        public SettingsViewModel(
            NavigationViewModel navigationViewModel,
            ApiConfiguration apiConfiguration,
            SettingsManager settingsManager,
            ApiSettingsService settingsService,
            IClientsProvider clientsProvider, 
            IContractsProvider contractsProvider, 
            IClientCreator clientCreator, 
            IContractCreator contractCreator)
        {
            // Инициализация данных
            Items = new ObservableCollection<Item>
            {

                new Item { Id = 1, Name = "localhost" },
                new Item { Id = 2, Name = "Timothy" }

            };

            SelectedItem = Items.FirstOrDefault();

            NavigationViewModel = navigationViewModel;

            ChangeApi = new ChangeApiCommand(settingsService, apiConfiguration, settingsManager,  this, clientsProvider, contractsProvider, clientCreator, contractCreator);
        }

        public static SettingsViewModel LoadViewModel(
            NavigationViewModel navigationViewModel,
            ApiConfiguration apiConfiguration,
            SettingsManager settingsManager,
            ApiSettingsService settingsService,
            IClientsProvider clientsProvider,
            IContractsProvider contractsProvider,
            IClientCreator clientCreator,
            IContractCreator contractCreator)
        {
            SettingsViewModel viewModel = new SettingsViewModel(navigationViewModel, apiConfiguration, settingsManager, settingsService, clientsProvider, contractsProvider, clientCreator, contractCreator);

            //viewModel.LoadContractsCommand.Execute(viewModel);
            //SettingsManager settingsManager = new SettingsManager("settings.json");
            string cap = settingsManager.LoadSettings().CurrentSettings.CurrentApiKey;//.CurrentApiKey["CurrentApiKey"];
            viewModel.SelectedItem = viewModel.Items.Where(item => item.Name == cap).FirstOrDefault();
            //viewModel.FilteredData = viewModel.Contracts;

            return viewModel;
        }

    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
