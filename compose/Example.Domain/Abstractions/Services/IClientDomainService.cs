using Example.Domain.Models;
using System.Threading.Tasks;

namespace Example.Domain.Abstractions.Services
{
    public interface IClientDomainService
    {
        Task<Client> GetByIdAsync(int clientId);

        Task<Client> AddAsync(Client client);
        Task<Client> UpdateAsync(int clientId, Client client);
        Task DeleteAsync(Client client);
    }
}
