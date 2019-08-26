using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYLISTENING_WPF.Models
{
    class Playlist
    {
        private string id;
        private string name;
        private string imageURL;
        private string ownerID;
        private ArrayList tracksIDs;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string ImageURL { get => imageURL; set => imageURL = value; }
        public string OwnerID { get => ownerID; set => ownerID = value; }
        public ArrayList TracksIDs { get => tracksIDs; set => tracksIDs = value; }
    }
}
