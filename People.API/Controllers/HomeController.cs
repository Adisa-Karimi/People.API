using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using People.Domain.DTOs;
using People.Provider;

namespace People.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMyProvider _provider;

        public HomeController(IMyProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// Get all Students.
        /// </summary>

        /// <returns code="200">a list of Students</returns>

        [HttpGet("GetStudent")]
        public async Task<IActionResult> Get()
        {
            var dtOs = await _provider.GetAllStudents();
            return Ok(dtOs);
        }

        /// <summary>
        /// Creates a new Student.
        /// </summary>

        /// <response code="201">Returns the newly created item</response>
        /// <response code="500">If the dto is null or the ModelState is invalid</response> 
        /// 

        [HttpPost]
        public IActionResult Post([FromBody]StudentDto dto)
        {
            if (dto == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = _provider.AddStudent(dto);
            return result == null ? StatusCode(500, "A problem occurred while handling your request.")
                : CreatedAtRoute("GetStudent", result);
        }
    }
}