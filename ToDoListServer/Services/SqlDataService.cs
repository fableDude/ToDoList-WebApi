using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ToDoListServer.Entities;
using ToDoListServer.Models.Dtos;

namespace ToDoListServer.Services
{
    public class SqlDataService : IDataService
    {
        private SqlDataContext _sqlDataContext;
        public SqlDataService(SqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }
        public Task<ToDoItem> AddNewItem(ToDoItemDto item)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoList> AddNewList(ToDoListDto list)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoItem> CheckItem(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountActiveItems()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountItems()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountLists()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> DeleteList(int listId)
        {
            throw new NotImplementedException();
        }

        public Task<ToDoList> EditList(int listId, ToDoListDto list)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ToDoItem>> GetAllItems()
        {
            var items = await _sqlDataContext.ToDoItems.ToListAsync();
            return items;
        }

        public async Task<IEnumerable<ToDoList>> GetAllLists()
        {
            var lists = await _sqlDataContext.ToDoLists.ToListAsync();
            return lists;
        }

        public Task<ToDoList> GetListById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToDoItem>> GetListItems(int listId)
        {
            throw new NotImplementedException();
        }
    }
}
