using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Interfaces;
using TaskManagment.Infrastructure.DBContext;
namespace TaskManagment.Infrastructure.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IRepository Tasks { get; }
        public UnitOfWork(AppDbContext context, IRepository TaskRepository)
        {
             _context = context;
            Tasks = TaskRepository;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
