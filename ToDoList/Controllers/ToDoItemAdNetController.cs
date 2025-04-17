using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDolist.Bll.Dtos;
using ToDolist.Bll.Services;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemAdNetController : ControllerBase
    {
        private readonly IToDoItemServiceAdoNet service;

        public ToDoItemAdNetController(IToDoItemServiceAdoNet controller)
        {
            this.service = controller;
        }

        [HttpPost("AddToDoItem")]

        public async Task<long> InsertToDoItem(ToDoItemCreateDto toDoItem)
        {
            return await service.AddToDoItemAsync(toDoItem);
        }

        [HttpDelete("DeleteToDoItem")]
        public async Task  DeleteToDoItem(long Id)
        {
             await service.DeleteToDoItemByIDAsync(Id);
        }

        [HttpGet("GetToDoItemById")]
        public async Task<ToDoItemGetDto> GetToDoItemById(long Id)
        {
            return await service.GetToDoItemByIdAsync(Id);
        }

        [HttpPost("UpdateToDoItem")]
        public async Task UpdateToDoItem(ToDoItemUpdateDto toDoItemUpdateDto)
        {
             await service.UpdateToDoitemAsync(toDoItemUpdateDto);
        }

        [HttpGet("GetCompletedToDoItem")]
        public async Task<List<ToDoItemGetDto>> GetCompletedToDoItem(int skip = 0, int take = 0)
        {
            return await service.GetCompletedAsync(skip, take);
        }

        [HttpGet("GetInCompletedToDoItem")]
        public async Task<List<ToDoItemGetDto>> GetInCompletedToDoItem(int skip = 0, int take = 0)
        {
            return await service.GetInCompletedAsync(skip, take);
        }

        [HttpGet("GetDueDate")]

        public async Task<List<ToDoItemGetDto>> GetDueDate(DateTime dateTime)
        {
            return await service.GetByDueDateAsync(dateTime);
        }

        [HttpGet("GetAllToDoItems")]

        public async Task<List<ToDoItemGetDto>> GetAllToDoItems(int skip, int take)
        {
            return await service.GetAlltoDoItemsAsync(skip, take);
        }
    }
}
