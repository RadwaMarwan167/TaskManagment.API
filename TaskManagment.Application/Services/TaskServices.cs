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
        // الغرض: ده السيرفس اللي بيتعامل مع اللوجيك بتاع المهام (Tasks)
        // بيستخدم الـ Unit of Work عشان يتعامل مع الريبو (Repository) بتاع المهام
        // هنا ممكن نضيف ميثودز زي CreateTask, UpdateTask, DeleteTask, GetTaskById, GetAllTasks

        public readonly IUnitOfWork _unitOfWork;
        public TaskServices(IUnitOfWork unitOfWork)
        {
            // الغرض: بنستخدم الـ Unit of Work عشان نقدر نتعامل مع الريبو بتاع المهام
            // Dependency Injection: بنحقن الـ Unit of Work في الكونستركتور عشان نقدر نستخدمه في السيرفس
            // الهدف: عشان نفصل بين اللوجيك بتاع الابلكيشن وازاي بنخزن البيانات
            // كده بنخلي الكود انظف واسهل في الصيانة
            _unitOfWork = unitOfWork;
        }
        public async Task<string>  CreateTaskAsync(TaskCreateDTO dto)
        {
            var task = new Domain.Entities.TaskItem
            {
                // شرح الفانكشن دي:
                // 1. بتاخد TaskCreateDTO كمدخل (اللي بيحتوي على بيانات المهمة الجديدة)
                // 2. بتعمل مابينج من الـ DTO للـ Entity (TaskItem)
                // مابينج : يعني بنحول البيانات من شكل لشكل تاني
                // ليه بعملها كده ؟ عشان الـ DTO بيحتوي على البيانات اللي جايه من العميل (Client → API)
                // والـ Entity هو الشكل اللي بنخزن بيه البيانات في الداتا بيز
                // 3. بتستخدم الريبو عشان تضيف المهمة الجديدة في الداتا
                // 4. بتسيف التغييرات في الداتا بيز
                // 5. بترجع رسالة بتأكد إن المهمة اتعملت
                // مفيش Id هنا لأن الـ Id بيتولد تلقائي في قاعدة البيانات
                // الحالة الافتراضية بتكون new
                Title = dto.Title,
                Description = dto.Description,
                DueDate = dto.DueDate,
                Priority = (TasksPriority)dto.Priority,
                Status = TasksStatus.New // الحالة الافتراضية بتكون new


            };

            await _unitOfWork.Tasks.AddAsync(task);
            await _unitOfWork.SaveChangesAsync();
            return ResponseMesseges.TaskCreated;
        }

        public async Task<IEnumerable<TaskResponseDTO>> GetTaskAsync(string Title, TasksStatus? Status, int PageNumber, int PageSize)
        {
            // شرح الفانكشن دي:
            // 1. بتاخد باراميترز للفلترة والصفحة والحجم  الفلترة بتشمل العنوان والحالة
            // 2. بتستخدم الريبو عشان تجيب المهام اللي بتطابق الفلترة
            // 3. بتعمل مابينج من الـ Entity (TaskItem) للـ DTO (TaskResponseDTO)
            // مابينج : يعني بنحول البيانات من شكل لشكل تاني
            // ليه بعملها كده ؟ عشان الـ DTO بيحتوي على البيانات اللي بنرجعها للعميل (API → Client)
            // والـ Entity هو الشكل اللي بنخزن بيه البيانات في الداتا بيز
            // 4. بترجع ليستة من TaskResponseDTO للعميل
            // مشكلة priority 
            //  لازم تتحول من enum ل string
            // عشان لما ترجعها في الـ API تبقى واضحة وسهلة القراءة
            // بدل ما ترجع رقم زي 0, 1, 2
            // فبترجع Low, Medium, High
            // ده بيخلي الـ API أسهل في الاستخدام والفهم
            // كده بنخلي الكود انظف واسهل في الصيانة


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


