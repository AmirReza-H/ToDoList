using ToDoList.Domain.CategoryDomain.Entities;
using ToDoList.Domain.ToDoTaskDomain.Enums;

namespace ToDoList.Domain.ToDoTaskDomain.Entities
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public EnmImportanceLvl ImportanceLvl { get; set; }

        #region [ Navigations ]
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        #endregion
    }
}
