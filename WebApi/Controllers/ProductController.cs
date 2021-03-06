﻿using System;
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
    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productAppService.GetAllAsync());
        }

        [Authorize("Bearer")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productAppService.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [Authorize("Bearer")]
        [HttpGet("GetByFirstLetter/{letter}")]
        public async Task<IActionResult> GetByFirstLetter([FromRoute] char letter)
        {
            return Ok(await _productAppService.GetByFirstLetterAsync(letter));
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductDTO product)
        {
            var createdProduct = await _productAppService.InsertAsync(product);

            if (createdProduct == null)
            {
                return BadRequest();
            }

            return Ok(createdProduct);
        }

        [Authorize("Bearer")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ProductDTO product)
        {
            var updatedProduct = await _productAppService.UpdateAsync(id, product);

            if (updatedProduct == null)
            {
                return BadRequest();
            }

            return Ok(updatedProduct);
        }

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productAppService.DeleteAsync(id);
            return Ok();
        }
    }
}