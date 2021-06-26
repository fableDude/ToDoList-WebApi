using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        public async Task<ToDoItem> AddNewItem(ToDoItem item)
        {
            var res = await _sqlDataContext.ToDoItems.AddAsync(item);
            await _sqlDataContext.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<ToDoList> AddNewList(ToDoList list)
        {
            var res = await _sqlDataContext.ToDoLists.AddAsync(list);
            await _sqlDataContext.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<ToDoItem> CheckItem(int itemId)
        {
            var existingItem = _sqlDataContext.ToDoItems.Where(item => item.Id == itemId).First();
            var obj = new JsonPatchDocument<ToDoItem>().Replace(o => o.IsCompleted, true);
            obj.ApplyTo(existingItem);
            var res = _sqlDataContext.ToDoItems.Update(existingItem);
            await _sqlDataContext.SaveChangesAsync();
            return res.Entity;
        }

        public Task<int> CountActiveItems()
        {
            var count = _sqlDataContext.ToDoItems.Where(item => item.IsCompleted == false).Count();
            return Task.FromResult(count);
        }

        public Task<int> CountItems()
        {
            var count = _sqlDataContext.ToDoItems.Count();
            return Task.FromResult(count);
        }

        public  Task<int> CountLists()
        {
            var count = _sqlDataContext.ToDoLists.Count();
            return Task.FromResult(count);
        }

        public async Task DeleteList(int listId)
        {
            _sqlDataContext.ToDoItems.RemoveRange(_sqlDataContext.ToDoItems.Where(item => item.ListId == listId));
            _sqlDataContext.ToDoLists.Remove(_sqlDataContext.ToDoLists.Where(list => list.Id == listId).First());
            await _sqlDataContext.SaveChangesAsync();
            return;
        }

        public async Task<ToDoList> EditList(int listId, ToDoList list)
        {
            var res =_sqlDataContext.ToDoLists.Update(list);
            await _sqlDataContext.SaveChangesAsync();
            return res.Entity;
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

        public  Task<ToDoList> GetListById(int id)
        {
            var lists =  _sqlDataContext.ToDoLists.Where(list => list.Id == id).First();
            return Task.FromResult(lists);
        }

        public async Task<IEnumerable<ToDoItem>> GetListItems(int listId)
        {
            var items = await  _sqlDataContext.ToDoItems.Where(item => item.ListId == listId).ToListAsync();
            return items;
        }
    }
}
