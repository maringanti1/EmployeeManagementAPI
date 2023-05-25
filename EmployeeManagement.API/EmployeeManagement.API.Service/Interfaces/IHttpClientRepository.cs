using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Service.Interfaces
{
    public interface IHttpClientRepository
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
    }
}
