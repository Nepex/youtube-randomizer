using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace YouTubeRandomizer
{
    public class YouTubeApi
    {
        private static YouTubeService ytService = Auth();

        private static YouTubeService Auth()
        {
            UserCredential creds;
            using (var stream = new FileStream("client_secret_593289801604-vjtncl79u2n1ivij32jrsbkvtno8mbf3.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read))
            {
                creds = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] { YouTubeService.Scope.YoutubeReadonly },
                        "user",
                        CancellationToken.None,
                        new FileDataStore("YouTubeAPI")
                ).Result;
            }

            var service = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = creds,
                ApplicationName = "YouTubeAPI"
            });

            return service;
        }

        public static void GetVideoInfo(YouTubeVideo searchQuery)
        {
            var videoRequest = ytService.Search.List("snippet");

            videoRequest.Q = searchQuery.query;
            videoRequest.MaxResults = 20;

            var response = videoRequest.Execute();
            if (response.Items.Count > 0)
            {
                Console.WriteLine(searchQuery.query);
                Random rnd = new Random();
                int rand = rnd.Next(0, 19);

                searchQuery.query = "https://www.youtube.com/v/" + response.Items[rand].Id.VideoId;
            }
            else
            {
                searchQuery.query = "No such video.";
            }
        }
    }
}
