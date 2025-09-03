using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Application.DTOs
{
    public class TaskResponseDTO
    {
        // الغرض: ده الـ DTO اللي بيرجع البيانات للعميل (API → Client) لما يطلبوا معلومات عن مهمة
        // بيحتوي على كل الخصائص المهمة اللي العميل ممكن يحتاجها
        // الغرض: ده اللي بيرجع من الـ API للـ Client بعد ما يعملوا Create / Get / Update
       public string Title { get; set; }
       public string Description { get; set; }    
       public DateTime DueDate { get; set; }
       public int Priority { get; set; }
       public int Status { get; set; }
       public int Id { get; set; }

    }
}
