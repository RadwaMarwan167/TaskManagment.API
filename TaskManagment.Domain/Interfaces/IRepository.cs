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
        // CRUD Operations 'C'reate, 'R'ead, 'U'pdate, 'D'elete 
        // الغرض: ده الريبو اللي بيتعامل مع الـ TaskItem في الداتا
        // الهدف: عشان نفصل بين اللوجيك بتاع الابلكيشن وازاي بنخزن البيانات
        // كده بنخلي الكود انظف واسهل في الصيانة
        // بتساعد في تحقيق مبدأ ال Dependency Inversion Principle (DIP) من مبادئ SOLID
        Task AddAsync(TaskItem task) ;

        void UpdateAsync(TaskItem task);
        void DeleteAsync(TaskItem task);
        Task<TaskItem?> GetByIdAsync(int id);
        // شرح الفانكشن دي:
        // 1. بتاخد باراميترز للفلترة والصفحة والحجم  الفلترة بتشمل العنوان والحالة
        // 2. بترجع ليستة من TaskItem اللي بتطابق الفلترة
        Task<IEnumerable<TaskItem>> GetAllAsync(string Title , TasksStatus ? Status , int PageNumber , int PageSize) ;
    }
}
