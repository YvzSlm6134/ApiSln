using ApiSln.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.İnterface.Repositories
{
    public interface IWriteRepository<T> where T : class, IEntityBase,  new()
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IList<T> entitites);

        Task<T> UpdateAsync(T entity); // Veriyi update etmeye yarar.
        Task<T> HardDeleteAsync (T entity); // veriyi tamaamen silmeye yarar.
        Task<T> HardDeleteRangeAsync (IList<T> entity); 

    }
}
