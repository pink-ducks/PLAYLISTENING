using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYLISTENING_WPF.Models
{
    public class User: Model
    {
        private ArrayList playlistsIDs;

        public ArrayList PlaylistsIDs { get => playlistsIDs; set => playlistsIDs = value; }
        // constructor
        public User(string id) => this.id = id;
    }

    
}
