using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListServer.Models.Dtos
{
    public record ToDoListDto
    (
        int id,
        string caption,
        string description,
        string image,
        string color,
        string userId
    );
}
