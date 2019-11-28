using Example.Domain.Models;
using System.Threading.Tasks;

namespace Example.Domain.Abstractions.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(int clientId);

        Task AddAsync(Client client);
        Task UpdateAsync(int clientId, Client client);
        Task RemoveAsync(Client client);
        Task SaveChangesAsync();
    }
}
