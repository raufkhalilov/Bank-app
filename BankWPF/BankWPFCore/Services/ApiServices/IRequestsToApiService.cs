using System.Threading.Tasks;

namespace BankWPFCore.Services.ApiServices
{
    interface IRequestsToApiService
    {
        Task<string> GetDataFromApi(string url);

        Task<string> PostDataToApi/*<T>*/(string url, object dataForPost);

        Task<string> UpdateDataFromApi(string url, object updatedData);
    }
}
