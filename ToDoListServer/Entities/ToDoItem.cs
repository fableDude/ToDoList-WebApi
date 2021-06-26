using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListServer.Entities
{
    public class ToDoItem {
        public int Id { get; set; }
        public string Caption { get; set; }
        public int ListId{ get; set; }
        public bool IsCompleted{ get; set; }
        public ToDoList List{ get; set; }
    }
}
