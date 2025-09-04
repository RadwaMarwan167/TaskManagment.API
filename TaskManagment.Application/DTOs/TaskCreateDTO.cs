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
       
        public string Title { get; set; } 
        public string Description { get; set; } 
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
    }
}
