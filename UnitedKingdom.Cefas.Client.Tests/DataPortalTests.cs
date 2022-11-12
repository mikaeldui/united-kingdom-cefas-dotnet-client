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
        public async Task GetRecordsetsAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Recordsets.GetRecordsetsAsync();
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First());
        }

        [TestMethod]
        public async Task GetRecentRecordsetsAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Recordsets.GetRecentRecordsetsAsync();
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First());
        }

        [TestMethod]
        public async Task GetRecordsetAsync()
        {
            using DataPortalClient client = new();
            var recordsets = await client.Recordsets.GetRecordsetsAsync();
            var result = await client.Recordsets.GetRecordsetAsync(recordsets.First());
            Assert.IsNotNull(result.Name);
            Assert.IsTrue(result.Versions.Any());
            Assert.IsTrue(result.Fields.Any());
        }

        [TestMethod]
        public async Task GetRecordsAsync()
        {
            using DataPortalClient client = new();
            var recordsets = await client.Recordsets.GetRecordsetsAsync();
            var result = await client.Recordsets.GetRecordsAsync(recordsets.First());
            Assert.IsTrue(result.Items.Any());
            Assert.IsNotNull(result.Items.First());
        }

        [TestMethod]
        public async Task GetRecordAsync()
        {
            using DataPortalClient client = new();
            var recordsets = await client.Recordsets.GetRecordsetsAsync();
            var recordsPage = await client.Recordsets.GetRecordsAsync(recordsets.First());
            using var result = await client.Recordsets.GetRecordAsync(recordsets.First(), recordsPage.Items.First());
            Assert.IsTrue(result.CanRead);
        }

        [TestMethod]
        public async Task GetFilesAsync()
        {
            using DataPortalClient client = new();
            var recordsets = await client.Recordsets.GetRecordsetsAsync();
            var result = await client.Recordsets.GetFilesAsync(recordsets.First());
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First().Filename);
        }
    }
}
