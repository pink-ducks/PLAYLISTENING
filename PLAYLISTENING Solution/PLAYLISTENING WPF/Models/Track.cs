using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYLISTENING_WPF.Models
{
    public class Track: Model
    {
        private string authorID;
        private string lenght;

        public string AuthorID { get => authorID; set => authorID = value; }
        public string Lenght { get => lenght; set => lenght = value; }
    }
}
