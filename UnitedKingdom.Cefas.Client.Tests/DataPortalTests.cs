using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitedKingdom.Cefas.DataPortal;

namespace UnitedKingdom.Cefas.Tests
{
    [TestClass]
    public class DataPortalTests
    {
        [TestMethod]
        public async Task GetAutoSuggestVocabulariesAsync()
        {
            using DataPortalClient client = new();
            var result = await client.AutoSuggest.GetVocabulariesAsync("a");
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First());
        }

        [TestMethod]
        public async Task GetGridsAsync()
        {
            using DataPortalClient client = new();
            var result = await client.GetGridsAsync(51, 49, 1, -1);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public async Task GetLocationsAsync()
        {
            using DataPortalClient client = new();
            var result = await client.GetLocationsAsync();
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First().Name);
        }

        [TestMethod]
        public async Task GetLocationAsync()
        {
            using DataPortalClient client = new();
            var locations = await client.GetLocationsAsync();
            await client.GetLocationAsync(locations.First());
        }

        [TestMethod]
        public async Task GetMapOverlaysAsync()
        {
            using DataPortalClient client = new();
            var result = await client.GetMapOverlaysAsync();
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First().Name);
        }
    }
}
