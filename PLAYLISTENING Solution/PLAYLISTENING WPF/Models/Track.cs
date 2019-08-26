using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYLISTENING_WPF.Models
{
    class Track
    {
        private string id;
        private string name;
        private string imageURL;
        private string authorID;
        private string lenght;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string ImageURL { get => imageURL; set => imageURL = value; }
        public string AuthorID { get => authorID; set => authorID = value; }
        public string Lenght { get => lenght; set => lenght = value; }
    }
}
