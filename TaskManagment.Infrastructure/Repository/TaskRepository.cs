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
            // 1. بتجيب المهمة من الداتا بيز بناءً على الـ Id
            // 2. بتتأكد إن المهمة مش متحذوفة (IsDeleted = false) 
            // 3. بترجع المهمة لو لقتها، أو null لو مش لقتها
            // 4. بتستخدم EF Core عشان تتعامل مع الداتا بيز بطريقة سهلة وفعالة

            return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id && !t.IsDeleted);
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync(string title, TasksStatus? Status, int page, int pageSize)
        { // شرح الفانكشن دي:
            // 1. بتاخد باراميترز للفلترة والصفحة والحجم  الفلترة بتشمل العنوان والحالة
            // 2. بتبني استعلام ديناميكي بناءً على الفلترة اللي اتقدمت
            // 3. بتستخدم الـ Skip و Take عشان تعمل Pagination
            // 4. بترجع ليستة من TaskItem اللي بتطابق الفلترة
            var query = _context.Tasks.AsQueryable(); // مهم AsQueryable
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
