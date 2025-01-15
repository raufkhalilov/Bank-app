using BankWPFCore.Exceptions;
using BankWPFCore.Models;
using BankWPFCore.Stores;
using BankWPFCore.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Windows.Themes;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace BankWPFCore.Commands
{
    internal class LoadClientsCommand : BaseAsyncCommand
    {
        private readonly ClientsListingViewModel _clientViewModel;
        //private readonly IRequestsToApiService _requestsToApiService;
        private BankStore _bankStore;

        public LoadClientsCommand(ClientsListingViewModel clientsViewModel, BankStore bankStore)
        {
            _bankStore = bankStore;
            _clientViewModel = clientsViewModel;
        }

        public override async Task ExecuteAsync()
        {

            _clientViewModel.IsLoading = true;
            _clientViewModel.ErrorMessage = string.Empty;

            try
            {

                await _bankStore.LoadClients();
                await _bankStore.LoadContracts();

                var Clients_ = new List<Client>(_bankStore.Clients).Select(c => new { c.ClientId, c.ClientName });
                var Amounts = new List<Contract>(_bankStore.Contracts);
                var list1 = Amounts.Select(Cid => new { Cid.ClientID, Cid.ContractAmount, Cid.Description });

                var list2 = list1.Join(Clients_, a => a.ClientID, c => c.ClientId, (a, c) => new { c.ClientName, a.Description, a.ContractAmount }).ToList();

                var list3 = list2.GroupBy(list2 => list2.ClientName);

                list3 = list3.OrderBy(c => c.Key);





                _clientViewModel.SeriesCollection = new SeriesCollection()
                {
                    new StackedColumnSeries
                    {
                        Values = new ChartValues<float> {},
                        StackMode = StackMode.Values, // this is not necessary, values is the default stack mode
                        DataLabels = true,
                        Title="Credits"


                    },
                    new StackedColumnSeries
                    {
                        Values = new ChartValues<float> {},
                        StackMode = StackMode.Values,
                        DataLabels = true,
                        Title="Debts"
                    },
                    new StackedColumnSeries
                    {
                        Values = new ChartValues<float> {},
                        StackMode = StackMode.Values,
                        DataLabels = true,
                        Title = "Cards"
                    }
                };



                _clientViewModel.Labels = new string[list3.Count()];

                int i = 0;
                foreach (var item in list3)
                {

                    _clientViewModel.SeriesCollection[0].Values.Add((float)0);
                    _clientViewModel.SeriesCollection[1].Values.Add((float)0);
                    _clientViewModel.SeriesCollection[2].Values.Add((float)0);

                    _clientViewModel.Labels[i] = item.Key;
                    i++;
                }



                


                //_clientViewModel.SeriesCollection[1].Values[0]=((float)10);

                //_clientViewModel.SeriesCollection[2].Values[3] = ((float)10);

                var list5 = list2.OrderBy(c => c.ClientName);



                i = -1;
                string name = string.Empty;
                foreach (var item in list5)
                {

                    
                    if (!name.Equals(item.ClientName))
                    {
                        i++;
                    }
                    name = item.ClientName;

                    switch (item.Description)
                    {
                        case "Card":
                            _clientViewModel.SeriesCollection[2].Values[i] = item.ContractAmount;


                            break;
                        case "Credit":
                            _clientViewModel.SeriesCollection[0].Values[i] = item.ContractAmount;



                            break;
                        case "Deposit":
                            _clientViewModel.SeriesCollection[1].Values[i] = item.ContractAmount;

                            break;



                    }

                }
                    /*

                                    _clientViewModel.SeriesCollection[0].Values.Add((float)5);

                                    var list5 = list2.OrderBy(c => c.ClientName);

                                    foreach (var item in list5)
                                    {

                                        switch (item.Description)
                                        {
                                            case "Card":
                                                _clientViewModel.SeriesCollection[2].Values.Add(item.ContractAmount);



                                                break;
                                            case "Credit":
                                                _clientViewModel.SeriesCollection[0].Values.Add(item.ContractAmount);



                                                break;
                                            case "Deposit":
                                                _clientViewModel.SeriesCollection[1].Values.Add(item.ContractAmount);

                                                break;
                                        }

                    */


                    /*var l1 = item.GroupBy(l => l.Description);


                    foreach (var item1 in item)
                    {
                        switch (item1.Description)
                        {
                            case "Card":
                                _clientViewModel.SeriesCollection[2].Values.Add(item1.ContractAmount);

                                switch (item.Count())
                                {
                                    case 1:
                                        _clientViewModel.SeriesCollection[1].Values.Add((float)0);
                                        _clientViewModel.SeriesCollection[0].Values.Add((float)0);
                                        break;
                                    case 0: {
                                            _clientViewModel.SeriesCollection[1].Values.Add((float)0);
                                            _clientViewModel.SeriesCollection[0].Values.Add((float)0);
                                            break;
                                        }




                                }

                                break;
                            case "Credit":
                                _clientViewModel.SeriesCollection[0].Values.Add(item1.ContractAmount);

                                switch (item.Count())
                                {
                                    case 1:
                                        _clientViewModel.SeriesCollection[1].Values.Add((float)0);
                                        _clientViewModel.SeriesCollection[2].Values.Add((float)0);
                                        break;
                                    case 0:
                                        {
                                            _clientViewModel.SeriesCollection[1].Values.Add((float)0);
                                            _clientViewModel.SeriesCollection[2].Values.Add((float)0);
                                            break;
                                        }


                                }

                                break;
                            case "Deposit":
                                _clientViewModel.SeriesCollection[1].Values.Add(item1.ContractAmount);

                                switch (item.Count())
                                {
                                    case 1:
                                        _clientViewModel.SeriesCollection[0].Values.Add((float)0);
                                        _clientViewModel.SeriesCollection[2].Values.Add((float)0);
                                        break;
                                    case 0:
                                        {
                                            _clientViewModel.SeriesCollection[0].Values.Add((float)0);
                                            _clientViewModel.SeriesCollection[2].Values.Add((float)0);
                                            break;
                                        }


                                }

                                break;

                        }
                    }*/

                    ///i++;

                //}


                foreach (var item in list3)
                    item.GroupBy(i => i.Description);


                _clientViewModel.UpdateClientsList(_bankStore.Clients);
            }
            catch (ApiConnectionException ex)
            {
                //MessageBox.Show(ex.Comment + "\n" + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                _clientViewModel.ErrorMessage = "При загрузке клиентов произошла ошибка!";
            }

            _clientViewModel.IsLoading = false;

            //TODO: add this code into try-catch block

        }
    }
}
