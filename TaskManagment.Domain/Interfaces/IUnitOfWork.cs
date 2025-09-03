using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // الغرض: ده بيجمع كل الريبو في مكان واحد عشان نسهل التعامل معاهم
        // الهدف: عشان لو عندنا اكتر من ريبو نقدر نديرهم بسهولة
        // بيساعد في تحقيق مبدأ ال Single Responsibility Principle (SRP) من مبادئ SOLID
       
        IRepository Tasks { get; }

        // SaveChangesAsync: بتستخدم عشان نحفظ التغييرات في الداتا
        Task<int> SaveChangesAsync();
    }
}
