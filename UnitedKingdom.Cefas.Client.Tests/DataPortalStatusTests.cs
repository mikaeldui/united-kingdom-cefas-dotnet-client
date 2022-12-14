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
    public class DataPortalStatusTests
    {
        [TestMethod]
        public async Task GetStatusAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Status.GetStatusAsync();
            Assert.IsNotNull(result.Version);
            Assert.IsTrue(result.Options.Any());
        }

        [TestMethod]
        public async Task GetServiceStatusAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Status.GetServiceStatusAsync(true);
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First().ResponseStatus);
        }

        [TestMethod]
        public async Task GetLocationStatusAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Status.GetLocationStatusAsync();
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First().Type);
        }

        [TestMethod]
        public async Task GetDatabaseStatusAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Status.GetDatabaseStatusAsync();
            Assert.IsTrue(result.Counts.Any());
            Assert.IsNotNull(result.Counts.First().Type);
            Assert.IsNotNull(result.Counts.First().Count > 0);
        }

        [TestMethod]
        public async Task GetCollectionStatusAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Status.GetcollectionStatusAsync();
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First().Name);
        }
    }
}
