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
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
       
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
