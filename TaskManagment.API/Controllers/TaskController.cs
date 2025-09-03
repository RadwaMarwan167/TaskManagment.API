using Microsoft.AspNetCore.Mvc;
using TaskManagment.Application.DTOs;
using TaskManagment.Application.Servises;
using TaskManagment.Domain.Enums;
namespace TaskManagment.API.Controllers



{
    public class TaskController : ControllerBase
    {

        private readonly TaskServices _taskService;

        public TaskController(TaskServices taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskCreateDTO dto)
        {
            var message = await _taskService.CreateTaskAsync(dto);
            return Ok(new { message });
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string? title, TasksStatus? status, int page = 1, int pageSize = 10)
        {
            var tasks = await _taskService.GetTaskAsync(title, status, page, pageSize);
            return Ok(tasks);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaskUpdateDTO dto)
        {
            var message = await _taskService.UpdateTaskAsync(id, dto);
            return Ok(new { message });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var message = await _taskService.DeleteTaskAsync(id);
            return Ok(new { message });
        }

    }
}
