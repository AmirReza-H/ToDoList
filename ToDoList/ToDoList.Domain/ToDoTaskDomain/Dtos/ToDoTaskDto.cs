using ToDoList.Domain.ToDoTaskDomain.Enums;

namespace ToDoList.Domain.ToDoTaskDomain.Dtos
{
    public class ToDoTaskDto
    {
        public string Name { get; set; }
        public EnmImportanceLvl ImportanceLvl { get; set; }
        public bool IsDone { get; set; }
    }
}
