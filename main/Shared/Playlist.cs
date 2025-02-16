using System;
using System.Collections.Generic;

namespace music_manager_starter.Shared
{
    // this is the playlist class that is used to create a playlist
    public class Playlist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> SongIds { get; set; } = new List<Guid>();
    }
} 