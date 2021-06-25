using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ToDoListServer.Entities;
using Newtonsoft.Json;
using System.Text;

namespace ToDoListServer.Services
{
    public class DataService
    {
        private const string _path = "http://localhost:3000/";
        static readonly HttpClient client = new HttpClient();

        public async Task<IEnumerable<ToDoList>> GetAllLists()
        {
            var res = await client.GetAsync(_path+"lists");
            res.EnsureSuccessStatusCode();
            var resp = await res.Content.ReadAsStringAsync();
            var lists = JsonConvert.DeserializeObject<ToDoList[]>(resp);
            return lists;
        }

        public async Task<ToDoList> GetListById(Guid id)
        {
            var res = await client.GetAsync(_path + "lists/"+id);
            res.EnsureSuccessStatusCode();
            var resp = await res.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<ToDoList>(resp);
            return list;
        }

        public async Task<IEnumerable<ToDoItem>> GetAllItems()
        {
            var res = await client.GetAsync(_path + "items");
            res.EnsureSuccessStatusCode();
            var resp = await res.Content.ReadAsStringAsync();
            var items = JsonConvert.DeserializeObject<ToDoItem[]>(resp);
            return items;
        }

        public async Task<IEnumerable<ToDoItem>> GetListItems(Guid listId)
        {
            var res = await client.GetAsync(_path + "items?listId="+listId);
            res.EnsureSuccessStatusCode();
            var resp = await res.Content.ReadAsStringAsync();
            var items = JsonConvert.DeserializeObject<ToDoItem[]>(resp);
            return items;
        }

        public async Task<ToDoItem> AddNewItem(ToDoItem item)
        {
            var json = JsonConvert.SerializeObject(item);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PostAsync(_path + "items", data);
            var resp = await res.Content.ReadAsStringAsync();
            var newIten = JsonConvert.DeserializeObject<ToDoItem>(resp);
            return newIten;

        }

        public async Task<ToDoList> EditList(Guid listId,ToDoList list)
        {
            var json = JsonConvert.SerializeObject(list);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PostAsync(_path + "lists/"+listId, data);
            var resp = await res.Content.ReadAsStringAsync();
            var newList = JsonConvert.DeserializeObject<ToDoList>(resp);
            return newList;
        }

        public async Task<ToDoList> AddNewList(ToDoList list)
        {
            var json = JsonConvert.SerializeObject(list);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PostAsync(_path + "lists", data);
            var resp = await res.Content.ReadAsStringAsync();
            var newList = JsonConvert.DeserializeObject<ToDoList>(resp);
            return newList;
        }

        public async Task<HttpResponseMessage> DeleteList(Guid listId)
        {
            await client.DeleteAsync(_path + "items?listId=" + listId);
            return await client.DeleteAsync(_path + "lists/" + listId); 
        }

        public async Task<HttpResponseMessage> CheckItem(Guid itemId)
        {
            var data = new StringContent("isComplited=true", Encoding.UTF8, "application/json");
            var res = await client.PatchAsync(_path + "items/" + itemId, data);
            return res;
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
                    .Where(item => item.isCompleted == true)
                    .Count();
        }

        public async Task<int> CountLists()
        {
            var res = await GetAllLists();
            return res.Count();
        }



    }
}
