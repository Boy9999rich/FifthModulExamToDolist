using ToDolist.Bll.Dtos;

namespace ToDolist.Bll.Services
{
    public interface IToDoItemServiceAdoNet
    {
        Task<long> AddToDoItemAsync(ToDoItemCreateDto toDoItemCreateDto);
        Task DeleteToDoItemByIDAsync(long Id);
        Task UpdateToDoitemAsync(ToDoItemUpdateDto toDoItemUpdateDto);
        Task<List<ToDoItemGetDto>> GetAlltoDoItemsAsync(int skip = 0, int take = 0);
        Task<ToDoItemGetDto> GetToDoItemByIdAsync(long id);
        Task<List<ToDoItemGetDto>> GetByDueDateAsync(DateTime dateTime);
        Task<List<ToDoItemGetDto>> GetCompletedAsync(int skip = 0, int take = 0);
        Task<List<ToDoItemGetDto>> GetInCompletedAsync(int skip = 0, int take = 0);
    }
}