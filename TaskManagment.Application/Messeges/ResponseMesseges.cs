using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagment.Application.Messeges
{
    public static class ResponseMesseges
    {
        public const string TaskCreated = "Task created successfully.";
        public const string TaskUpdated = "Task updated successfully.";
        public const string TaskDeleted = "Task deleted successfully.";
        public const string TaskNotFound = "Task not found.";
        public const string InvalidTaskData = "Invalid task data.";
        public const string InternalServerError = "An internal server error occurred.";
    }
}
