using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagment.Application.DTOs;
using TaskManagment.Application.Messeges;
using TaskManagment.Domain.Entities;
using TaskManagment.Domain.Enums;
using TaskManagment.Domain.Interfaces;


namespace TaskManagment.Application.Servises
{
    public class TaskServices
    {

        public readonly IUnitOfWork _unitOfWork;
        public TaskServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string>  CreateTaskAsync(TaskCreateDTO dto)
        {
            var task = new Domain.Entities.TaskItem
            {
                
                Title = dto.Title,
                Description = dto.Description,
                DueDate = dto.DueDate,
                Priority = (TasksPriority)dto.Priority,
                Status = TasksStatus.New 


            };

            await _unitOfWork.Tasks.AddAsync(task);
            await _unitOfWork.SaveChangesAsync();
            return ResponseMesseges.TaskCreated;
        }

        public async Task<IEnumerable<TaskResponseDTO>> GetTaskAsync(string Title, TasksStatus? Status, int PageNumber, int PageSize)
        {
           

            var Tasks = await _unitOfWork.Tasks.GetAllAsync(Title, Status, PageNumber, PageSize);
            return Tasks.Select(t => new TaskResponseDTO
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
                Priority = (int)t.Priority,
                Status = (int)t.Status
            });
        }
        public async Task<string> UpdateTaskAsync(int id, TaskUpdateDTO dto)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(id);
            if (task == null) return ResponseMesseges.TaskNotFound;

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.DueDate = dto.DueDate;
            task.Priority = (TasksPriority)dto.Priority;
            task.Status = (TasksStatus)dto.Status;

            _unitOfWork.Tasks.UpdateAsync(task);
            await _unitOfWork.SaveChangesAsync();
            return ResponseMesseges.TaskUpdated;
        }

        public async Task<string> DeleteTaskAsync(int id)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(id);
            if (task == null) return ResponseMesseges.TaskNotFound;

            task.IsDeleted = true;
            _unitOfWork.Tasks.UpdateAsync(task);
            await _unitOfWork.SaveChangesAsync();
            return ResponseMesseges.TaskDeleted;
        }
    }


}


