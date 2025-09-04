using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Application.DTOs;
using TaskManagment.Domain.Entities;
using TaskManagment.Domain.Enums;
using TaskManagment.Domain.Interfaces;
using TaskManagment.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;


namespace TaskManagment.Infrastructure.Repository
{
    public class TaskRepository : IRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {

            return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync(string title, TasksStatus? Status, int page, int pageSize)
        { 
            var query = _context.Tasks.AsQueryable(); 
            query = query.Where(t => !t.IsDeleted);

            if (!string.IsNullOrEmpty(title))
                query = query.Where(t => t.Title.Contains(title));

            if (Status.HasValue)
                query = query.Where(t => t.Status == Status);

            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task AddAsync(TaskItem task) => await _context.Tasks.AddAsync(task);

        public void UpdateAsync(TaskItem task) => _context.Tasks.Update(task);

        public void DeleteAsync(TaskItem task) => task.IsDeleted = true;
    }
}
