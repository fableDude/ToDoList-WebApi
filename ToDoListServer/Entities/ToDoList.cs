using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListServer.Entities
{
    public record ToDoList(
        Guid id, 
        string caption, 
        string description, 
        string image, 
        string color, 
        ToDoItem[] items
        );
}
