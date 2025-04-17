using ToDolist.Dal.Entity;

namespace ToDoList.StorageBroker.Services
{
    public interface IToDoItemRepositoryAdoNet
    {
        Task<long> InsertToDoItemAsync(ToDoItem toDoItem);
        Task DeleteToDoItemByIdAsync(long Id);
        Task UpdateToDoItemAsync(ToDoItem pdateToDoItem);
        Task<List<ToDoItem>> SelectToDoItemsAsync(int skip = 0, int take = 10);
        Task<ToDoItem> SelectToDoItemByIdAsync(long Id);
        Task<List<ToDoItem>> SelectByDueDateAsync(DateTime DateTime);
        Task<List<ToDoItem>> SelectCompletedAsync(int skip = 0, int take = 10);
        Task<List<ToDoItem>> SelectInCompletedAsync(int skip = 0, int take = 10);
    }
}