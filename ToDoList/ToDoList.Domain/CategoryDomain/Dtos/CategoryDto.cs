using ToDoList.Domain.ToDoTaskDomain.Dtos;

namespace ToDoList.Domain.CategoryDomain.Dtos
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }

        #region [ Navigations ]
        public IEnumerable<ToDoTaskDto>? ToDoTasks { get; set; }
        #endregion
    }
}
