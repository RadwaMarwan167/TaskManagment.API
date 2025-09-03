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
        // الغرض: ده بيجمع كل الريبو في مكان واحد عشان نسهل التعامل معاهم  // الهدف: عشان لو عندنا اكتر من ريبو نقدر نديرهم بسهولة
        public UnitOfWork(AppDbContext context, IRepository TaskRepository)
        {
            // بنستخدم الكونستركتور عشان نمرر الـ DbContext والريبو // بنخزن الـ DbContext في متغير خاص عشان نستخدمه بعدين
            // بنخزن الريبو في خاصية عشان نقدر نستخدمها من بره 
            // Dependency Injection: بنحقن الـ DbContext والريبو في الكونستركتور عشان نقدر نستخدمهم في الـ Unit of Work
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
