using AutoMapper;
using FluentValidation;
using ToDolist.Bll.Dtos;
using ToDolist.Dal.Entity;
using ToDoList.StorageBroker.Services;

namespace ToDolist.Bll.Services;

public class ToDoItemServiceAdoNet : IToDoItemServiceAdoNet
{
    private readonly IToDoItemRepositoryAdoNet repository;
    private readonly IMapper mapper;
    private readonly IValidator validator;

    public ToDoItemServiceAdoNet(IToDoItemRepositoryAdoNet repository, IMapper mapper = null, IValidator validator = null)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.validator = validator;
    }

    public async Task<long> AddToDoItemAsync(ToDoItemCreateDto toDoItemCreateDto)
    {
        return await repository.InsertToDoItemAsync(mapper.Map<ToDoItem>(toDoItemCreateDto));
    }

    public async Task DeleteToDoItemByIDAsync(long Id)
    {
        await repository.DeleteToDoItemByIdAsync(Id);
    }

    public Task<List<ToDoItemGetDto>> GetAlltoDoItemsAsync(int skip = 0, int take = 0)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ToDoItemGetDto>> GetByDueDateAsync(DateTime dateTime)
    {
        return await repository.SelectByDueDateAsync(mapper.Map(To(dateTime)));
    }

    public Task<List<ToDoItemGetDto>> GetCompletedAsync(int skip = 0, int take = 0)
    {
        throw new NotImplementedException();
    }

    public Task<List<ToDoItemGetDto>> GetInCompletedAsync(int skip = 0, int take = 0)
    {
        throw new NotImplementedException();
    }

    public Task<ToDoItemGetDto> GetToDoItemByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateToDoitemAsync(ToDoItemUpdateDto toDoItemUpdateDto)
    {
        throw new NotImplementedException();
    }
}
