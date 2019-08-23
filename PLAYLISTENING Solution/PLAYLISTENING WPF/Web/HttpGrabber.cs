using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PLAYLISTENING_WPF.Model;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;

namespace PLAYLISTENING_WPF.Web
{
    public class HttpGrabber
    {
        private string BaseAddress = "https://api.spotify.com/v1/";
        private string tokenData;

        public async Task MakeStringGreatAgain()
        {
            //List<NaszTyp>
            try
            {
                var getData = JsonConvert.DeserializeObject<List<SpotifyData>>(await TestGet());
            }
            catch (Exception ex)
            {
                var a = ex.Message.ToString();
            }

        }

        public void GetToken()
        {
            string spotifyClient = "2726b49d5bf540e2ab307852eb45a438";
            string spotifySecret = "5b453a702f944aaeb40d23077aea2d16";

            WebClient webClient = new WebClient();

            NameValueCollection postparams = new NameValueCollection();
            postparams.Add("grant_type", "client_credentials");

            string authHeader = Convert.ToBase64String(Encoding.Default.GetBytes($"{spotifyClient}:{spotifySecret}"));
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Basic " + authHeader);

            byte[] tokenResponse = webClient.UploadValues("https://accounts.spotify.com/api/token", postparams);

            string textResponse = Encoding.UTF8.GetString(tokenResponse);
            this.tokenData = textResponse.Substring(17, 83);
        }

        public async Task<string> TestGet()
        {
            string testRequest = "";
            try
            {
                GetToken();
                HttpWebRequest request = HttpWebRequest.CreateHttp(BaseAddress + "artists/1Yox196W7bzVNZI7RBaPnf"); // change address here 
                request.Method = WebRequestMethods.Http.Get;
                request.ContentType = "application/json; charset=utf-8";
                request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + this.tokenData);


                await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null)
                    .ContinueWith(task => {
                        var response = (HttpWebResponse)task.Result;

                        if(response.StatusCode == HttpStatusCode.OK)
                        {
                            StreamReader responseReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                            string responseData = responseReader.ReadToEnd();

                            testRequest = responseData.ToString();
                            responseReader.Close();
                        }
                        response.Close();
                });
            }
            catch (Exception ex)
            {
                var a = ex.Message.ToString();
            }

            return testRequest;
        }
    }
}
