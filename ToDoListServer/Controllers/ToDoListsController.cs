using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListServer.Entities;
using ToDoListServer.Services;

namespace ToDoListServer.Controllers
{
    [Route("lists")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private IDataService _service;

        public ToDoListsController(IDataService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoList>>> GetAllLists()
        {
            IEnumerable<ToDoList> res = await _service.GetAllLists();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoList>> GetListById(int id)
        {
            ToDoList res = await _service.GetListById(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<ToDoList> AddNewList([FromBody]ToDoList newList)
        {
            ToDoList res = await _service.AddNewList(newList);
            return res;
        }

        [HttpPatch("{id}")]
        public async Task<ToDoList> EditList(int id,[FromBody] ToDoList newList)
        {
            ToDoList res = await _service.EditList(id,newList);
            return res;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteList(int id)
        {
            var res = await _service.DeleteList(id);
            return Ok(res);
        }

    }
}
