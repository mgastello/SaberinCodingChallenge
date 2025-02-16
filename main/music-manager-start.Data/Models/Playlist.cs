using System;
using System.Collections.Generic;

namespace music_manager_starter.Data.Models
{
    // this is the playlist class that is used to create a playlist
    public class Playlist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();
    }
} 