using AutoMapper;
using FluentValidation;
using ToDolist.Bll.Dtos;
using ToDolist.Bll.Mapper;
using ToDolist.Dal.Entity;
using ToDoList.StorageBroker.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ToDolist.Bll.Services;

public class ToDoItemServiceAdoNet : IToDoItemServiceAdoNet
{
    private readonly IToDoItemRepositoryAdoNet repository;
    private readonly IMapper mapper;
    private readonly IValidator<ToDoItemCreateDto> validator;

    public ToDoItemServiceAdoNet(IToDoItemRepositoryAdoNet repository, IMapper mapper = null, IValidator<ToDoItemCreateDto> validator = null)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.validator = validator;
    }

    public async Task<long> AddToDoItemAsync(ToDoItemCreateDto toDoItemCreateDto)
    {
        var status = validator.Validate(toDoItemCreateDto);
        if (!status.IsValid)
        {
            throw new Exception("toDoList is not Valid");
        }
        var entity = mapper.Map<ToDoItem>(toDoItemCreateDto);
        entity.CreatedAt = DateTime.Now;
        entity.IsCompleted = false;
        return await repository.InsertToDoItemAsync(entity);

        //return await repository.InsertToDoItemAsync(mapper.Map<ToDoItem>(toDoItemCreateDto));
    }

    public async Task DeleteToDoItemByIDAsync(long Id)
    {
        await repository.DeleteToDoItemByIdAsync(Id);
    }

    
    public async Task<List<ToDoItemGetDto>> GetAlltoDoItemsAsync(int skip = 0, int take = 0)
    {
        var res = await repository.SelectToDoItemsAsync(skip, take);
        return res.Select(x => mapper.Map<ToDoItemGetDto>(x)).ToList();
    


        //var count = repository.GetToDoListCount();
        //var res = await repository.SelectToDoItemsAsync(skip, take);
        //return new ToDoItemUpdateDto() { Count = count, Dtos = res.Select(b => mapper.Map<ToDoItemGetDto>(b)).ToList() };
    }

    public async Task<List<ToDoItemGetDto>> GetByDueDateAsync(DateTime dateTime)
    {
        var res = await repository.SelectByDueDateAsync(dateTime);
        return res.Select(x => mapper.Map<ToDoItemGetDto>(x)).ToList();


        //var count = repository.GetToDoListCount();
        //var toDoItems = await repository.SelectByDueDateAsync(dateTime);
        //return new ToDoItemUpdateDto() { Count = count, Dtos = toDoItems.Select(x => mapper.Map<ToDoItemGetDto>(x)).ToList() };
    }

    public async Task<List<ToDoItemGetDto>> GetCompletedAsync(int skip = 0, int take = 0)
    {
        var res = await repository.SelectCompletedAsync(skip, take);
        return res.Select(x => mapper.Map<ToDoItemGetDto>(x)).ToList();
    }

    public async Task<List<ToDoItemGetDto>> GetInCompletedAsync(int skip = 0, int take = 0)
    {
        var res = await repository.SelectInCompletedAsync(skip, take);
        return res.Select(x => mapper.Map<ToDoItemGetDto>(x)).ToList();
    }

    public async Task<ToDoItemGetDto> GetToDoItemByIdAsync(long id)
    {
        var res = await repository.SelectToDoItemByIdAsync(id);
        return mapper.Map<ToDoItemGetDto>(res);
    }

    public async Task UpdateToDoitemAsync(ToDoItemUpdateDto toDoItemUpdateDto)
    {
        await repository.UpdateToDoItemAsync(mapper.Map<ToDoItem>(toDoItemUpdateDto));
    }
}
