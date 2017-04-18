using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeRandomizer
{
    public class YouTubeVideo
    {
        public string query;

        public YouTubeVideo(string searchQuery)
        {
            this.query = searchQuery;
            YouTubeApi.GetVideoInfo(this);
        }
    }
}
