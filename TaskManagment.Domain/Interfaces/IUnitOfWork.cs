using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        
        IRepository Tasks { get; }

        Task<int> SaveChangesAsync();
    }
}
