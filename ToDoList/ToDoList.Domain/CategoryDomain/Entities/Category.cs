using ToDoList.Domain.Common;
using ToDoList.Domain.ToDoTaskDomain.Entities;

namespace ToDoList.Domain.CategoryDomain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }

        #region [ Navigations ]
        public virtual ICollection<ToDoTask>? ToDoTasks { get; set; }
        #endregion
    }
}
