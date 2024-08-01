using ApiSln.Application.İnterface.Repositories;
using ApiSln.Application.İnterface.UnitOfWorks;
using ApiSln.Persistence.Context;
using ApiSln.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // => işaretini return yerine kullanıp kodumuzu tek bir satırda yazabiliriz.
        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();

        public int Save() => dbContext.SaveChanges();
        
        public async Task<int> SaveAsync() => await dbContext.SaveChangesAsync();
        
        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(dbContext);
      
    }
}
