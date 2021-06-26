﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListServer.Entities
{
    public record ToDoItem(
        int id,
        string caption,
        int listId,
        bool isCompleted,
        ToDoList list
        );
}
