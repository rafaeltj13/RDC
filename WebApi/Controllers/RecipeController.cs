using System;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class RecipeController : Controller
    {
        private readonly IRecipeAppService _recipeAppService;

        public RecipeController(IRecipeAppService recipeAppService)
        {
            _recipeAppService = recipeAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _recipeAppService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var recipe = await _recipeAppService.FindAsync(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RecipeDTO recipe)
        {
            throw new NotImplementedException();
        }
    }
}