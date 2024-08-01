using Microsoft.EntityFrameworkCore.Query;
using ApiSln.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.İnterface.Repositories
{
    public interface IReadRepository<T> where T : class, IEntityBase, new()
    {
        Task<IList<T>> GettAllAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null,
            bool enableTracking = false);

        Task<IList<T>> GettAllAsyncByPaging(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null,
            bool enableTracking = false, int currentPage = 1, int pageSize = 3);

        Task<T> GettAsync(Expression<Func<T, bool>> predicate, 
            Func<IQueryable<T>, IIncludableQueryable<T, 
                object>>? include = null, bool enableTracking = false);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false);
        //Bir Entity nin yada Entity içindeki alanın sayısını bulmak için kullanılır.
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    }
}
