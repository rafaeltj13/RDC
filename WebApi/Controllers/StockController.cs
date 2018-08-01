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
    public class StockController : Controller
    {
        private readonly IStockAppService _stockAppService;

        public StockController(IStockAppService stockAppService)
        {
            _stockAppService = stockAppService;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _stockAppService.GetAllAsync());
        }

        [Authorize("Bearer")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var stock = await _stockAppService.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock);
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]StockDTO stock)
        {
            var createdStock = await _stockAppService.InsertAsync(stock);

            if (createdStock == null)
            {
                return BadRequest();
            }

            return Ok(createdStock);
        }

        [Authorize("Bearer")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]StockDTO stock)
        {
            var updatedStock = await _stockAppService.UpdateAsync(id, stock);

            if (updatedStock == null)
            {
                return BadRequest();
            }

            return Ok(updatedStock);
        }

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _stockAppService.DeleteAsync(id);
            return Ok();
        }
    }
}