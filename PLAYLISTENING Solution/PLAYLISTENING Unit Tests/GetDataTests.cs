using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLAYLISTENING_WPF.Web;
using PLAYLISTENING_WPF.Models;

namespace PLAYLISTENING_Unit_Tests
{
    [TestClass]
    public class GetDataTests
    {
        [TestMethod]
        public async System.Threading.Tasks.Task GetCorrectUsernameTest()
        {
            APIConnector Connector = new APIConnector();
            APIDataGrabber Grabber = new APIDataGrabber(); // download data from API
            User User = new User("213pado37eomvngbs4vac5qra"); // Paweł Tomaszewski

            await Connector.ConnectWithAPI();
            Connector.GiveSpotifyAccessFor(Grabber);
            Grabber.UploadUserData(User);

            Assert.IsNotNull(User.Name);
            string expected = "Paweł Tomaszewski";
            Assert.AreEqual(expected, User.Name);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task GetEmptyUsernameTest()
        {
            APIConnector Connector = new APIConnector();
            APIDataGrabber Grabber = new APIDataGrabber(); // download data from API
            User EmptyUser = new User("");

            await Connector.ConnectWithAPI();
            Connector.GiveSpotifyAccessFor(Grabber);
            Grabber.UploadUserData(EmptyUser);

            Assert.IsNull(EmptyUser.Name);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task GetPlaylistIDTest()
        {
            APIConnector Connector = new APIConnector();
            APIDataGrabber Grabber = new APIDataGrabber(); // download data from API
            User User = new User("213pado37eomvngbs4vac5qra"); // Paweł Tomaszewski

            await Connector.ConnectWithAPI();
            Connector.GiveSpotifyAccessFor(Grabber);
            Grabber.UploadUserData(User);

            string expectedID = "7vyoQ7H2r5rblUR42a6I4t";

            Assert.AreEqual(expectedID, User.Playlists[1].Id);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task GetPlaylistsNamesTest()
        {
            APIConnector Connector = new APIConnector();
            APIDataGrabber Grabber = new APIDataGrabber(); // download data from API
            User User = new User("213pado37eomvngbs4vac5qra"); // Paweł Tomaszewski

            await Connector.ConnectWithAPI();
            Connector.GiveSpotifyAccessFor(Grabber);
            Grabber.UploadUserData(User);
            
            string expectedName1 = "Music";

            Assert.AreEqual(expectedName1, User.Playlists[1].Name);
        }
    }
}
