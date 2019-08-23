using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYLISTENING_WPF.Model
{
    //public class ExternalUrls
    //{
    //    public string spotify { get; set; }
    //}

    public class Followers
    {
        //public object href { get; set; }
        public int total { get; set; }
    }

    public class Image
    {
        //public int height { get; set; }
        public string url { get; set; }
       // public int width { get; set; }
    }

    public class RootObject
    {
        //public ExternalUrls external_urls { get; set; }
        public Followers followers { get; set; }
        //public List<string> genres { get; set; }
        //public string href { get; set; }
        //public string id { get; set; }
        public List<Image> images { get; set; }
        public string name { get; set; }
        //public int popularity { get; set; }
        public string type { get; set; }
        //public string uri { get; set; }
    }
}
