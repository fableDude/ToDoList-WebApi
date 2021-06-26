using Microsoft.EntityFrameworkCore;
using System;


namespace DataAccess
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
