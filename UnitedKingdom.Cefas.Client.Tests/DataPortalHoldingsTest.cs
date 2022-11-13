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
    public class DataPortalHoldingsTests
    {
        [TestMethod]
        public async Task GetHoldingAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Holdings.GetHoldingAsync(5);
            Assert.IsTrue(result.Properties.Any());
            Assert.IsNotNull(result.Title);
        }

        [TestMethod]
        public async Task GetHoldingTitleAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Holdings.GetHoldingTitleAsync(5);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public async Task GetHoldingSiblingsAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Holdings.GetHoldingSiblingsAsync(5);
            Assert.Inconclusive("Haven't found any holding with siblings, so can't test this.");
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public async Task GetHoldingIdByMedinIdAsync()
        {
            using DataPortalClient client = new();
            await client.Holdings.GetHoldingIdByMedinIdAsync("78edae85-c899-409b-ac05-1b5f6c1f68ae");
            await client.Holdings.GetHoldingIdByMedinIdAsync(Guid.Parse("78edae85-c899-409b-ac05-1b5f6c1f68ae"));
        }

        [TestMethod]
        public async Task GetHoldingRecordsetsAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Holdings.GetHoldingRecordsetsAsync(149);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First().Name);
        }

        [TestMethod]
        public async Task GetHoldingTypesAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Holdings.GetHoldingTypesAsync();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First().Name);
        }

        [TestMethod]
        public async Task GetHoldingTypeAsync()
        {
            using DataPortalClient client = new();
            var holdingTypes = await client.Holdings.GetHoldingTypesAsync();
            var result = await client.Holdings.GetHoldingTypeAsync(holdingTypes.First());
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Name);
        }

        [TestMethod]
        public async Task GetKeywordsAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Holdings.GetKeywordsAsync();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First().Value);
        }

        [TestMethod]
        public async Task GetKeywordAsync()
        {
            using DataPortalClient client = new();
            var keywords = await client.Holdings.GetKeywordsAsync();
            var result = await client.Holdings.GetKeywordAsync(keywords.First());
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.DisplayName);
        }

        [TestMethod]
        public async Task GetDatePropertiesAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Holdings.GetDatePropertiesAsync();
            Assert.IsNotNull(result.Any());
            Assert.IsNotNull(result.First().LongName);
        }

        [TestMethod]
        public async Task GetPropertiesAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Holdings.GetPropertiesAsync();
            Assert.IsNotNull(result.Any());
            Assert.IsNotNull(result.First().LongName);
        }

        [TestMethod]
        public async Task GetPropertyAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Holdings.GetPropertyAsync("AddInfoSource");
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.LongName);
        }

        [TestMethod]
        public async Task GetHoldingXmlExportAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Holdings.GetHoldingXmlExportAsync(5);
            Assert.IsTrue(result.CanRead);
        }
    }
}
