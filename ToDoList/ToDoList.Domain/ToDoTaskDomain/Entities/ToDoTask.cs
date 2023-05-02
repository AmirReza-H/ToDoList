using ToDoList.Domain.CategoryDomain.Entities;
using ToDoList.Domain.Common;
using ToDoList.Domain.ToDoTaskDomain.Enums;

namespace ToDoList.Domain.ToDoTaskDomain.Entities
{
    public class ToDoTask : BaseEntity
    {
        public string Name { get; set; }
        public EnmImportanceLvl ImportanceLvl { get; set; }
        public bool IsDone { get; set; }

        #region [ Navigations ]
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        #endregion
    }
}
