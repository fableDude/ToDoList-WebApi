using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListServer.Entities
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Color { get; set; }
        public List<ToDoItem> Items { get; set; }
        public string userId { get; set; }

        public ToDoList()
        {
            Items = new ();
        }
    }
    
}
