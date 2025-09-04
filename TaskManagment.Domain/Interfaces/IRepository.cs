using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Entities;
using TaskManagment.Domain.Enums;

namespace TaskManagment.Domain.Interfaces
{
    public interface IRepository
    {
        Task AddAsync(TaskItem task) ;

        void UpdateAsync(TaskItem task);
        void DeleteAsync(TaskItem task);
        Task<TaskItem?> GetByIdAsync(int id);
        
        Task<IEnumerable<TaskItem>> GetAllAsync(string Title , TasksStatus ? Status , int PageNumber , int PageSize) ;
    }
}
