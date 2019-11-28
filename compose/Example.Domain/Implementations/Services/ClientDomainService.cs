using Example.Domain.Abstractions.Repositories;
using Example.Domain.Abstractions.Services;
using Example.Domain.Models;
using System.Threading.Tasks;

namespace Example.Domain.Implementations.Services
{
    public sealed class ClientDomainService : IClientDomainService
    {
        private readonly IClientRepository _entityRepository;
        public ClientDomainService(IClientRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<Client> GetByIdAsync(int entityId)
        {
            return await _entityRepository.GetByIdAsync(entityId);
        }

        public async Task<Client> AddAsync(Client entity)
        {
            await _entityRepository.AddAsync(entity);
            await _entityRepository.SaveChangesAsync();
            return entity;
        }

        public async Task<Client> UpdateAsync(int entityId, Client entity)
        {
            await _entityRepository.UpdateAsync(entityId, entity);
            await _entityRepository.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(Client entity)
        {
            await _entityRepository.RemoveAsync(entity);
            await _entityRepository.SaveChangesAsync();
        }
    }
}
