using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userAppService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userAppService.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserDTO user)
        {
            var createdUser = await _userAppService.InsertAsync(user);

            if (createdUser == null)
            {
                return BadRequest();
            }

            return Ok(createdUser);
        }

        [Authorize("Bearer")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody]UserDTO user)
        {
            var updatedUser = await _userAppService.UpdateAsync(id, user);

            if (updatedUser == null)
            {
                return BadRequest();
            }

            return Ok(updatedUser);
        }

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userAppService.DeleteAsync(id);
            return Ok();
        }
    }
}