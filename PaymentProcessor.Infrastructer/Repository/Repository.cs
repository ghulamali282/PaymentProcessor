using Microsoft.EntityFrameworkCore;
using PaymentProcessor.Domain.Repository;
using System.Threading.Tasks;

namespace PaymentProcessor.Infrastructer.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly PaymentProcessorDbContext _context;
        private readonly DbSet<TEntity> _entities;
        public Repository(PaymentProcessorDbContext context)
        {
            _context = context;
            _entities=_context.Set<TEntity>();

        }
        public async Task InsertAsync(TEntity entity)
        {
           await  _entities.AddRangeAsync(entity);
        }
    }
}
