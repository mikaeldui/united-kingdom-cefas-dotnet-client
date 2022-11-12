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
    public class DataPortalRecordsetsTests
    {
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
        public async Task GetRecordestFilesAsync()
        {
            using DataPortalClient client = new();
            var recordsets = await client.Recordsets.GetRecordsetsAsync();
            var result = await client.Recordsets.GetRecordsetFilesAsync(recordsets.First());
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First().Filename);
        }

        [TestMethod]
        public async Task GetExportAsync()
        {
            using DataPortalClient client = new();
            var recordsets = await client.Recordsets.GetRecordsetsAsync();
            using var result = await client.Recordsets.GetExportAsync(recordsets.First());
            Assert.IsTrue(result.CanRead);
        }

        [TestMethod]
        public async Task GetRecordsetFieldsAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Recordsets.GetRecordsetFieldsAsync(8540);
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First().Name);
        }

        [TestMethod]
        public async Task GetFieldTypesAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Recordsets.GetFieldTypesAsync();
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First().Name);
        }

        [TestMethod]
        public async Task GetFieldTypeAsync()
        {
            using DataPortalClient client = new();
            var fieldTypes = await client.Recordsets.GetFieldTypesAsync();
            var result = await client.Recordsets.GetFieldTypeAsync(fieldTypes.First());
            Assert.IsNotNull(result.Name);
        }

        [TestMethod]
        public async Task GetRecordsetFiltersAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Recordsets.GetRecordsetFiltersAsync(8540);
            Assert.Inconclusive("I've yet to find a recordset with filters, so I can't test this.");
        }

        [TestMethod]
        public async Task GetFilterTypesAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Recordsets.GetFilterTypesAsync();
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First().LongName);
        }

        [TestMethod]
        public async Task GetTilterTypesForFieldTypeAsync()
        {
            using DataPortalClient client = new();
            var fieldTypes = await client.Recordsets.GetFieldTypesAsync();
            var result = await client.Recordsets.GetFilterTypesAsync(fieldTypes.First());
            Assert.IsNotNull(result.First().LongName);
        }

    }
}
