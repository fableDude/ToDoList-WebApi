using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ToDoListServer.Entities;
using ToDoListServer.Models.Dtos;

namespace ToDoListServer.Services
{
    public interface IDataService
    {
        Task<ToDoItem> AddNewItem(ToDoItemDto item);
        Task<ToDoList> AddNewList(ToDoListDto list);
        Task<ToDoItem> CheckItem(int itemId);
        Task<int> CountActiveItems();
        Task<int> CountItems();
        Task<int> CountLists();
        Task<HttpResponseMessage> DeleteList(int listId);
        Task<ToDoList> EditList(int listId, ToDoListDto list);
        Task<IEnumerable<ToDoItem>> GetAllItems();
        Task<IEnumerable<ToDoList>> GetAllLists();
        Task<ToDoList> GetListById(int id);
        Task<IEnumerable<ToDoItem>> GetListItems(int listId);
    }
}