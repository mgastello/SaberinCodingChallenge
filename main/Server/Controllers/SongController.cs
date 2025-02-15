using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using System;

namespace music_manager_starter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly DataDbContext _context;

        public SongsController(DataDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return await _context.Songs.ToListAsync();
        }

        // Get a single song by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(Guid id)
        {
            // uses the id from the params to search for the song in the database
            var song = await _context.Songs.FindAsync(id);

            if (song == null)
            {
                return NotFound();
            }

            return song;
        }

        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            if (song == null)
            {
                return BadRequest("Song cannot be null.");
            }


            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // add controller route for search

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Song>>> SearchSongs(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return await _context.Songs.ToListAsync();

            query = query.ToLower();
            
            // _context provides access to the database context
            // _context.Songs provides access to the Songs table in the database
            return await _context.Songs
                .Where(s => 
                    s.Title.ToLower().Contains(query) || 
                    s.Artist.ToLower().Contains(query) ||
                    (s.Album != null && s.Album.ToLower().Contains(query)))
                .ToListAsync();
        }
    }
}
