using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListServer.Entities;
using ToDoListServer.Mappers;
using ToDoListServer.Models.Dtos;
using ToDoListServer.Services;

namespace ToDoListServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private IDataService _service;

        public ToDoItemsController(IDataService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoItemDto>>> GetAllItems()
        {
            var res = await _service.GetAllItems();
            var response = res.Select(item => ToDoItemMapper.Map(item)).ToList();
            return Ok(response);
        }

        [HttpGet("bylist/{listId}")]
        public async Task<ActionResult<List<ToDoItemDto>>> GetItemsById(int listId)
        {
            var res = await _service.GetListItems(listId);
            var response = res.Select(item => ToDoItemMapper.Map(item)).ToList();
            return Ok(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetItemsCount()
        {
            var res = await _service.CountItems();
            return Ok(res);
        }

        [HttpGet("count/active")]
        public async Task<ActionResult<int>> GetActiveItemsCount()
        {
            var res = await _service.CountActiveItems();
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItemDto>> AddNewItem(ToDoItem item)
        {
            var res = await _service.AddNewItem(item);
            var response = ToDoItemMapper.Map(res);
            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ToDoItemDto>> CheckItem(int id)
        {
            var res = await _service.CheckItem(id);
            var response = ToDoItemMapper.Map(res);
            return Ok(response);
        }
    }
}
