using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Persistence
{
    public interface IAsyncRepository<T>
    {
        Task<T> GetByIdAsync(Guid id);

        Task<IReadOnlyCollection<T>> ListAllAsync();

        Task<T> AddAsync(T Entity);

        Task UpdateAcync(T entity);

        Task DeleteAsync(T entity);
    }
}
