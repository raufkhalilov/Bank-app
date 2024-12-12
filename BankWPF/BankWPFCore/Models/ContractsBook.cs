using BankWPF.Services;
using BankWPF.Services.ApiServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Models
{
    internal class ContractsBook
    {

        IContractsProvider _contractsProvider;

        IContractCreator _contractCreator;

        //private readonly List<Contract> _contracts;

        public ContractsBook(IContractCreator contractCreator, IContractsProvider contractsProvider)
        {
            //_contracts = new List<Contract>();
            _contractCreator = contractCreator;
            _contractsProvider = contractsProvider;
        }

        /*public IEnumerable<Contract> GetContractsByClientID(int clientId)
        {
            return _contracts.Where(x => x.ClientID == clientId);
        }
*/
        public async Task<IEnumerable<Contract>> GetAllContracts()
        {
            return await _contractsProvider.GetAllContracts();
        }

        public async Task AddContract(Contract contract) 
        {
            // checking conflict logic 
            
            await _contractCreator.AddContract(contract);
        }
    }
}
