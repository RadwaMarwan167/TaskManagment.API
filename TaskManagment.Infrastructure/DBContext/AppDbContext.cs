using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace TaskManagment.Infrastructure.DBContext
{
    public class AppDbContext : DbContext
    {
        // الغرض: ده الـ DbContext اللي بيتعامل مع قاعدة البيانات
        // بنورث من DbContext اللي هي جزء من Entity Framework Core
        // بنستخدم الكونستركتور عشان نمرر الخيارات (Options) بتاعت الاتصال بقاعدة البيانات
        // بنمرر الخيارات دي للـ DbContext الأب (Base)
        // بنستخدم الـ DbSet عشان نعرف الجداول اللي في قاعدة البيانات
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // هنا بنعرف الـ DbSet لكل Entity في الدومين
        // DbSet دي بتمثل جدول في قاعدة البيانات
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
