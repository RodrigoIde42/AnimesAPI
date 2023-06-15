using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourAnimeList;

namespace YourAnimeList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeListController : ControllerBase
    {
        private readonly AnimeLists _context;

        public AnimeListController(AnimeLists context)
        {
            _context = context;
        }

        // GET: api/AnimeList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimeList>>> GetAnimeList()
        {
            return await _context.AnimeList.ToListAsync();
        }

        // GET: api/AnimeList/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimeList>> GetAnimeList(int id)
        {
            var animeList = await _context.AnimeList.FindAsync(id);

            if (animeList == null)
            {
                return NotFound();
            }

            return animeList;
        }

        // PUT: api/AnimeList/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimeList(int id, AnimeList animeList)
        {
            if (id != animeList.AnimeListId)
            {
                return BadRequest();
            }

            _context.Entry(animeList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimeListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AnimeList
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnimeList>> PostAnimeList(AnimeList animeList)
        {
            _context.AnimeList.Add(animeList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimeList", new { id = animeList.AnimeListId }, animeList);
        }

        // DELETE: api/AnimeList/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimeList(int id)
        {
            var animeList = await _context.AnimeList.FindAsync(id);
            if (animeList == null)
            {
                return NotFound();
            }

            _context.AnimeList.Remove(animeList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimeListExists(int id)
        {
            return _context.AnimeList.Any(e => e.AnimeListId == id);
        }
    }
}
