using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Domain.Repository
{
    public interface IRepository<TEntity> where TEntity:class
    {
        Task InsertAsync(TEntity entity);
    }
}
