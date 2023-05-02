using AutoMapper;
using MediatR;
using System.Net;
using ToDoList.Application.Interfaces;
using ToDoList.Application.Interfaces.Repositories;
using ToDoList.Domain.CategoryDomain.Dtos;
using ToDoList.Domain.ToDoTaskDomain.Dtos;
using ToDoList.Domain.CategoryDomain.Entities;

namespace ToDoList.Application.Features.Categorys.Commands
{
    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public IEnumerable<ToDoTaskDto>? ToDoTasks { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            var _obj = _mapper.Map<Category>(request);
            _categoryRepository.Add(_obj);

            var isSuccess = await _unitOfWork.CommitAsync();
            if (!isSuccess)
                throw new Exception("ER");

            return _mapper.Map<CategoryDto>(_obj);
        }
    }
}
