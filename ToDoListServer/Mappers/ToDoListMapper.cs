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
                id : list.Id,
                caption : list.Caption,
                description : list.Description,
                image : list.Image,
                color : list.Color
            );

            return dto;
        }
    }
}
