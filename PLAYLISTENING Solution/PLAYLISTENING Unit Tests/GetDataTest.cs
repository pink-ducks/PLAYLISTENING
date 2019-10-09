﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLAYLISTENING_WPF.Web;
using PLAYLISTENING_WPF.Models;

namespace PLAYLISTENING_Unit_Tests
{
    [TestClass]
    public class GetDataTest
    {
        [TestMethod]
        public async System.Threading.Tasks.Task DownloadUserInfoTestAsync()
        {
            APIConnector Connector = new APIConnector();
            APIDataGrabber Grabber = new APIDataGrabber(); // download data from API
            User User = new User("213pado37eomvngbs4vac5qra"); // app user ("user_id")

            await Connector.ConnectWithAPI();
            Connector.GiveSpotifyAccessFor(Grabber);
            Grabber.UploadUserData(User);

            Assert.IsNotNull(User.Name);
            string expected = "Paweł Tomaszewski";
            Assert.AreEqual(expected, User.Name);
        }
    }
}
