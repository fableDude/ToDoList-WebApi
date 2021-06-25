using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListServer.Entities;
using ToDoListServer.Services;

namespace ToDoListServer.Controllers
{
    [Route("items")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private IDataService _service;

        public ToDoItemsController(IDataService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetAllItems()
        {
            var res = await _service.GetAllItems();
            return Ok(res);
        }

        [HttpGet("{listId=listId}")]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetItemsById(int listId)
        {
            var res = await _service.GetListItems(listId);
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItem>> AddNewItem(ToDoItem item)
        {
            var res = await _service.AddNewItem(item);
            return Ok(res);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ToDoItem>> CheckItem(int id)
        {
            var res = await _service.CheckItem(id);
            return Ok(res);
        }
    }
}
