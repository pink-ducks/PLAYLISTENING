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
        private string BaseAddress = "https://api.spotify.com";
        private string tokenData;

        /// <summary>
        /// Serialize RootObject
        /// </summary>
        /// <returns></returns>
        public async Task<RootObject> MakeStringGreatAgain()
        {
            RootObject root = new RootObject();
            try
            {
                root = JsonConvert.DeserializeObject<RootObject>(await GetFromHttp());
            }
            catch (Exception ex)
            {
                var a = ex.Message.ToString();
            }
            return root;
        }

        /// <summary>
        /// Get test data from http
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetFromHttp()
        {
            string testRequest = "";
            try
            {
                GetToken();

                string endPoint = "/v1/artists/1Yox196W7bzVNZI7RBaPnf"; // change address here 
                string fullAddress = BaseAddress + endPoint;

                HttpWebRequest request = HttpWebRequest.CreateHttp(fullAddress); 
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

            return testRequest; // our JSON in String
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
    }
}
