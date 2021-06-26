using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListServer.Entities;
using ToDoListServer.Models.Dtos;

namespace ToDoListServer.Mappers
{
    public class ToDoListMapper
    {
        public static ToDoListDto Map(ToDoList list)
        {
            ToDoListDto dto = new ToDoListDto
            (
                id : list.id,
                caption : list.caption,
                description : list.description,
                image : list.image,
                color : list.color
            );

            return dto;
        }
    }
}
