using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Domain.Enums;

namespace TaskManagment.Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime DueDate { get; set; }
        public TasksPriority Priority { get; set; } 
        public TasksStatus Status { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
