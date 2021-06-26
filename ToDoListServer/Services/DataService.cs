using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ToDoListServer.Entities;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Configuration;
using ToDoListServer.Models.Dtos;

namespace ToDoListServer.Services
{
    public class DataService : IDataService
    {
        private string _path;
        static readonly HttpClient client = new HttpClient();

        public DataService(IConfiguration configuration)
        {
            _path = configuration["serverUrl"];
        }

        public async Task<IEnumerable<ToDoList>> GetAllLists()
        {
            var res = await client.GetAsync(_path + "lists");
            res.EnsureSuccessStatusCode();
            var resp = await res.Content.ReadAsStringAsync();
            var lists = JsonConvert.DeserializeObject<ToDoList[]>(resp);
            return  lists;
        }

        public async Task<ToDoList> GetListById(int id)
        {
            var res = await client.GetAsync(_path + "lists/" + id);
            res.EnsureSuccessStatusCode();
            var resp = await res.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<ToDoList>(resp);
            return list;
        }

        public async Task<ToDoItem> GetItemById(int id)
        {
            var res = await client.GetAsync(_path + "items/" + id);
            res.EnsureSuccessStatusCode();
            var resp = await res.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<ToDoItem>(resp);
            return item;
        }


        public async Task<IEnumerable<ToDoItem>> GetAllItems()
        {
            var res = await client.GetAsync(_path + "items");
            res.EnsureSuccessStatusCode();
            var resp = await res.Content.ReadAsStringAsync();
            var items = JsonConvert.DeserializeObject<ToDoItem[]>(resp);
            return items;
        }

        public async Task<IEnumerable<ToDoItem>> GetListItems(int listId)
        {
            var res = await client.GetAsync(_path + "items?listId=" + listId);
            res.EnsureSuccessStatusCode();
            var resp = await res.Content.ReadAsStringAsync();
            var items = JsonConvert.DeserializeObject<ToDoItem[]>(resp);
            return items;
        }

        public async Task<ToDoItem> AddNewItem(ToDoItemDto item)
        {
            var json = JsonConvert.SerializeObject(item);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PostAsync(_path + "items", data);
            var resp = await res.Content.ReadAsStringAsync();
            var newIten = JsonConvert.DeserializeObject<ToDoItem>(resp);
            return newIten;

        }

        public async Task<ToDoList> EditList(int listId, ToDoListDto list)
        {
            var json = JsonConvert.SerializeObject(list);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PatchAsync(_path + "lists/" + listId, data);
            var resp = await res.Content.ReadAsStringAsync();
            var newList = JsonConvert.DeserializeObject<ToDoList>(resp);
            return newList;
        }

        public async Task<ToDoList> AddNewList(ToDoListDto list)
        {
            var json = JsonConvert.SerializeObject(list);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PostAsync(_path + "lists", data);
            var resp = await res.Content.ReadAsStringAsync();
            var newList = JsonConvert.DeserializeObject<ToDoList>(resp);
            return newList;
        }

        public async Task<HttpResponseMessage> DeleteList(int listId)
        {
            await client.DeleteAsync(_path + "items?listId=" + listId);
            return await client.DeleteAsync(_path + "lists/" + listId);
        }

        public async Task<ToDoItem> CheckItem(int itemId)
        {
            var existingItem = await GetItemById(itemId);
            var obj = new JsonPatchDocument<ToDoItem>().Replace(o => o.isCompleted, true);
            obj.ApplyTo(existingItem);
            var stringify = JsonConvert.SerializeObject(existingItem);
            var data = new StringContent(stringify, Encoding.UTF8, "application/json");
            var res = await client.PatchAsync(_path + "items/" + itemId, data);
            var resp = await res.Content.ReadAsStringAsync();
            var newItem= JsonConvert.DeserializeObject<ToDoItem>(resp);
            return newItem;
        }

        public async Task<int> CountItems()
        {
            var res = await GetAllItems();
            return res.Count();
        }

        public async Task<int> CountActiveItems()
        {
            var res = await GetAllItems();
            return res
                    .Where(item => item.isCompleted == false)
                    .Count();
        }

        public async Task<int> CountLists()
        {
            var res = await GetAllLists();
            return res.Count();
        }



    }
}
