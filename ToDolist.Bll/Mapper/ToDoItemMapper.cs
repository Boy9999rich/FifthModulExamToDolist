using AutoMapper;
using ToDolist.Bll.Dtos;
using ToDolist.Dal.Entity;

namespace ToDolist.Bll.Mapper;

public class ToDoItemMapper : Profile
{
    public ToDoItemMapper()
    {
        CreateMap<ToDoItem, ToDoItemCreateDto>().ReverseMap();
        CreateMap<ToDoItem, ToDoItemGetDto>().ReverseMap();
        CreateMap<ToDoItem, ToDoItemUpdateDto>().ReverseMap();
    }
}
