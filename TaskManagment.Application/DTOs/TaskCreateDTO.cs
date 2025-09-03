using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Enums;
using TaskManagment.Domain.Entities;

namespace TaskManagment.Application.DTOs
{
    public class TaskCreateDTO
    {
        // الغرض: ده الـ DTO اللي بيستقبل البيانات من العميل (Client → API) لما عايزين يضيفوا مهمة جديدة
        // بيحتوي على الخصائص الأساسية اللي بنحتاجها لإنشاء مهمة جديدة
        // مفيش Id هنا لأن الـ Id بيتولد تلقائي في قاعدة البيانات
        // Title: عنوان المهمة (مثلاً "شراء لبن").
        // Description: وصف إضافي(مثلاً "2 لتر من السوبرماركت").
        // DueDate: التاريخ المطلوب إنجاز المهمة فيه.
        ///Priority: مستوى الأولوية(0 = Low, 1 = Medium, 2 = High).
        //هنا معمول كـ int عشان يسهل إرساله من الـ API، لكن الأفضل تربطه بالـ Enum.
        public string Title { get; set; } 
        public string Description { get; set; } 
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
    }
}
