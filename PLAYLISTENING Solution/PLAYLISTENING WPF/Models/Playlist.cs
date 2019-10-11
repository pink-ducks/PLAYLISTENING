using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYLISTENING_WPF.Models
{
    public class Playlist: Model
    {
        private ArrayList tracksIDs;

        public ArrayList TracksIDs { get => tracksIDs; set => tracksIDs = value; }

        public Playlist(string id)
        {
            Id = id;

        }
    }
}
