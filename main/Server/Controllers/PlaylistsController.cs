using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using SharedPlaylist = music_manager_starter.Shared.Playlist;

namespace music_manager_starter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly DataDbContext _context;

        public PlaylistsController(DataDbContext context)
        {
            _context = context;
        }

        // fetch all playlists from the database
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SharedPlaylist>>> GetPlaylists()
        {
            var dbPlaylists = await _context.Playlists
                .Include(p => p.Songs)
                .ToListAsync();

            return Ok(dbPlaylists.Select(p => new SharedPlaylist
            {
                Id = p.Id,
                Name = p.Name,
                SongIds = p.Songs.Select(s => s.Id).ToList()
            }));
        }

        // fetch a single playlist from the database
        [HttpGet("{id}")]
        public async Task<ActionResult<SharedPlaylist>> GetPlaylist(Guid id)
        {
            var dbPlaylist = await _context.Playlists
                .Include(p => p.Songs)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (dbPlaylist == null)
            {
                return NotFound();
            }

            return new SharedPlaylist
            {
                Id = dbPlaylist.Id,
                Name = dbPlaylist.Name,
                SongIds = dbPlaylist.Songs.Select(s => s.Id).ToList()
            };
        }

        // create a new playlist
        [HttpPost]
        public async Task<ActionResult<SharedPlaylist>> CreatePlaylist(SharedPlaylist playlist)
        {
            var dbPlaylist = new Playlist
            {
                Id = playlist.Id,
                Name = playlist.Name,
                Songs = new List<Song>()
            };

            _context.Playlists.Add(dbPlaylist);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlaylist), new { id = playlist.Id }, playlist);
        }

        // update a playlist
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlaylist(Guid id, SharedPlaylist playlist)
        {
            if (id != playlist.Id)
            {
                return BadRequest();
            }

            var dbPlaylist = await _context.Playlists
                .Include(p => p.Songs)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (dbPlaylist == null)
            {
                return NotFound();
            }

            dbPlaylist.Name = playlist.Name;
            
            // update songs
            var songs = await _context.Songs
                .Where(s => playlist.SongIds.Contains(s.Id))
                .ToListAsync();
            
            dbPlaylist.Songs.Clear();
            dbPlaylist.Songs.AddRange(songs);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // delete a playlist
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(Guid id)
        {
            var playlist = await _context.Playlists.FindAsync(id);
            
            if (playlist == null)
            {
                return NotFound();
            }

            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
} 