using ToDoList.Domain.ToDoTaskDomain.Entities;

namespace ToDoList.Domain.CategoryDomain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }

        #region [ Navigations ]
        public virtual ICollection<ToDoTask> ConfirmedOrgCustomers { get; set; }
        #endregion
    }
}
