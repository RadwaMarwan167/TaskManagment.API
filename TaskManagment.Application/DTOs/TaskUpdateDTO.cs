using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Application.DTOs
{
    public class TaskUpdateDTO
    {
        /* الغرض: ده الـ DTO اللي بيستقبل البيانات من العميل (Client → API) لما عايزين يحدثوا مهمة موجودة
         * بيحتوي على الخصائص الأساسية اللي بنحتاجها لتحديث مهمة
         * فيه Id عشان نعرف إحنا بنحدث أي مهمة
         * Title: عنوان المهمة (مثلاً "شراء لبن").
         * Description: وصف إضافي(مثلاً "2 لتر من السوبرماركت").
         * DueDate: التاريخ المطلوب إنجاز المهمة فيه.
         * Status: حالة المهمة (0 = Pending, 1 = InProgress, 2 = Completed).
         * Priority: مستوى الأولوية(0 = Low, 1 = Medium, 2 = High).
         * هنا معمول كـ int عشان يسهل إرساله من الـ API، لكن الأفضل تربطه بالـ Enum.
         */
        public string Title { get; set; } 
        public string Description { get; set; } 
        public DateTime DueDate { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
    }
}
