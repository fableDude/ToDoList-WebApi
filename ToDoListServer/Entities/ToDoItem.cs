using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListServer.Entities
{
    public record ToDoItem(
        Guid id,
        string caption,
        Guid listId,
        Boolean isCompleted,
        ToDoList list)
        ;
}
