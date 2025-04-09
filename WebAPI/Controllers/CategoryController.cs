using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
namespace WebAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriesController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get() => await _context.Categories.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            var entity = await _context.Categories.FindAsync(id);
            return entity == null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Post(Category model)
        {
            _context.Categories.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Category model)
        {
            if (id != model.Id) return BadRequest();
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Categories.FindAsync(id);
            if (entity == null) return NotFound();
            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}