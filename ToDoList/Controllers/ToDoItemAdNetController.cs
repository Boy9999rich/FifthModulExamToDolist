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

    }
}
