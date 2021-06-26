﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListServer.Entities;
using ToDoListServer.Models.Dtos;

namespace ToDoListServer.Mappers
{
    public class ToDoItemMapper
    {
        public static ToDoItemDto Map(ToDoItem item)
        {
            ToDoItemDto dto = new ToDoItemDto
            (
                id: item.id,
                caption: item.caption,
                listId: item.listId,
                isCompleted: item.isCompleted
            );

            return dto;
        }
    }
}
