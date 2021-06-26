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
    public class ToDoListsController : ControllerBase
    {
        private IDataService _service;

        public ToDoListsController(IDataService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoListDto>>> GetAllLists()
        {
            var res = await _service.GetAllLists();
            var response = res.Select(list => ToDoListMapper.Map(list)).ToList();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoListDto>> GetListById(int id)
        {
            var res = await _service.GetListById(id);
            var response = ToDoListMapper.Map(res);
            return Ok(response);
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetListsCount()
        {
            var res = await _service.CountLists();
            return Ok(res);

        }

        [HttpPost]
        public async Task<ActionResult<ToDoListDto>> AddNewList([FromBody] ToDoList newList)
        {
            var res = await _service.AddNewList(newList);
            var response = ToDoListMapper.Map(res);
            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ToDoListDto>> EditList(int id,[FromBody] ToDoList newList)
        {
            var res = await _service.EditList(id,newList);
            var response = ToDoListMapper.Map(res);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task DeleteList(int id)
        {
            await _service.DeleteList(id);
            return ;
        }

    }
}
