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
    public class DataPortalWafTests
    {
        [TestMethod]
        public async Task GetWafEndpointsAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Holdings.Wafs.GetWafEndpointsAsync();
            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.First().Length > 0);
        }

        [TestMethod]
        public async Task GetWafAsync()
        {
            using DataPortalClient client = new();
            var endpoints = await client.Holdings.Wafs.GetWafEndpointsAsync();
            using var result = await client.Holdings.Wafs.GetWafAsync(endpoints.First());
            Assert.IsTrue(result.CanRead);
        }

        [TestMethod]
        public async Task GetWafHoldingsAsync()
        {
            using DataPortalClient client = new();
            var endpoints = await client.Holdings.Wafs.GetWafEndpointsAsync();
            var result = await client.Holdings.Wafs.GetWafHoldingsAsync(endpoints.First());
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First().Title);
        }

        [TestMethod]
        public async Task GetHoldingWafAsync()
        {
            using DataPortalClient client = new();
            var endpoints = await client.Holdings.Wafs.GetWafEndpointsAsync();
            var holdings = await client.Holdings.Wafs.GetWafHoldingsAsync(endpoints.First());
            var result = await client.Holdings.Wafs.GetHoldingWafAsync(endpoints.First(), holdings.First());
            Assert.IsTrue(result.CanRead);
        }
    }
}
