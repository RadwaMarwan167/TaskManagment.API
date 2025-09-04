using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Application.DTOs
{
    public class TaskUpdateDTO
    {
        
        public string Title { get; set; } 
        public string Description { get; set; } 
        public DateTime DueDate { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
    }
}
