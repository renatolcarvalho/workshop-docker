using Example.Domain.Abstractions.Repositories;
using Example.Domain.Models;
using Example.Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Example.Infra.Repository.Implementations
{
    public class ClientRepository : IClientRepository
    {
        public DbSet<Client> DbSet;
        public ClientManagementContext DbContext;
        public ClientRepository(ClientManagementContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<Client>();
        }

        public async Task<Client> GetByIdAsync(int entityId)
        {
            return await DbSet.FindAsync(entityId).ConfigureAwait(false);
        }

        public async Task AddAsync(Client entity)
        {
            await DbSet.AddAsync(entity).ConfigureAwait(false);
        }

        public async Task UpdateAsync(int entityId, Client newEntity)
        {
            var trackedEntity=  await DbSet.SingleOrDefaultAsync(register => register.Id == entityId);
            DbContext.Entry(trackedEntity).CurrentValues.SetValues((Client)newEntity.WithId(entityId));
        }

        public Task RemoveAsync(Client entity)
        {
            DbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
