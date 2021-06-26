using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListServer.Models.Dtos
{
    public record ToDoItemDto
    (
        int id,
        string caption,
        int listId,
        bool isCompleted
    );
}
