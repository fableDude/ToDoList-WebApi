using Microsoft.EntityFrameworkCore;
using System;
using ToDoListServer.Entities;

namespace ToDoListServer
{
    public class SqlDataContext:DbContext
    {
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public SqlDataContext()
        {

        }

        public SqlDataContext(DbContextOptions<SqlDataContext> options):base(options)
        {

        }
    }
}
