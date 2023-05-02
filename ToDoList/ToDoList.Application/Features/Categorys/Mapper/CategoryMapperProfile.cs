using AutoMapper;
using ToDoList.Application.Features.Categorys.Commands;
using ToDoList.Domain.CategoryDomain.Dtos;
using ToDoList.Domain.CategoryDomain.Entities;
using ToDoList.Domain.ToDoTaskDomain.Dtos;
using ToDoList.Domain.ToDoTaskDomain.Entities;

namespace ToDoList.Application.Features.Categorys.Mapper
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<Category,CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ToDoTask, ToDoTaskDto>().ReverseMap();
        }
    }
}
