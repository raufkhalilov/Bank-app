using BankWPFCore.Models.Helpers;
using BankWPFCore.Services;
using BankWPFCore.Services.ApiServices.Creators;
using BankWPFCore.Services.ApiServices.Providers;
using BankWPFCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BankWPFCore.Commands
{
    internal class ChangeApiCommand : BaseCommand
    {

        private ApiSettingsService _settingsService;
        private SettingsManager _settingsManager;
        private ApiConfiguration _configuration;

        private SettingsViewModel _settingsViewModel;

        IClientsProvider _clientsProvider;
        IContractsProvider _contractsProvider;
        IClientCreator _clientCreator;
        IContractCreator _contractCreator;
        string _newKey;

        public ChangeApiCommand(ApiSettingsService apiSettingsService,
            ApiConfiguration configuration,
            SettingsManager settingsManager,
           SettingsViewModel settingsViewModel,
        IClientsProvider clientsProvider,
            IContractsProvider contractsProvider,
            IClientCreator clientCreator,
            IContractCreator contractCreator) 
        { 
           
            _settingsService = apiSettingsService;
            _settingsManager = settingsManager;
            _settingsViewModel = settingsViewModel;
            _clientsProvider = clientsProvider;
            _contractsProvider = contractsProvider;
            _clientCreator = clientCreator;
            _contractCreator = contractCreator;

            _configuration = configuration;

            

            //_newKey = newKey;
        }

        public override void Execute(object parameter)
        {
            Urls urls = _settingsService.findApi(_settingsViewModel.SelectedItem.Name);

            _configuration.CurrentSettings.CurrentApiKey = _settingsViewModel.SelectedItem.Name;


            _settingsManager.SaveSettings(_configuration);

            _clientsProvider.Url = urls.url1;
            _contractsProvider.Url = urls.url2;
            _clientCreator.Url = urls.url3;

        }
    }
}
