using AutoMapper;
using Example.Application.Abstractions;
using Example.Application.InOut.Clients;
using Example.Domain.Abstractions.Services;
using Example.Domain.Models;
using System.Threading.Tasks;

namespace Example.Application.Implementations
{
    public class ClientApplicationService : IClientApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IClientDomainService _domainServiceBase;
        public ClientApplicationService(IMapper mapper, IClientDomainService domainServiceBase)
        {
            _mapper = mapper;
            _domainServiceBase = domainServiceBase;
        }

        public async Task<ClientResponse> GetByIdAsync(int clientId)
        {
            return _mapper.Map<ClientResponse>(await _domainServiceBase.GetByIdAsync(clientId));
        }

        public async Task<ClientResponse> AddAsync(ClientRequest entity)
        {
            var entityObject = _mapper.Map<Client>(entity);
            return _mapper.Map<ClientResponse>(await _domainServiceBase.AddAsync(entityObject));
        }

        public async Task<ClientResponse> UpdateAsync(int entityId, ClientRequest entity)
        {
            var entityObject = _mapper.Map<Client>(entity);
            return _mapper.Map<ClientResponse>(await _domainServiceBase.UpdateAsync(entityId, entityObject));
        }

        public async Task DeleteAsync(int clientId)
        {
            await _domainServiceBase.DeleteAsync(await _domainServiceBase.GetByIdAsync(clientId));
        }
    }
}
