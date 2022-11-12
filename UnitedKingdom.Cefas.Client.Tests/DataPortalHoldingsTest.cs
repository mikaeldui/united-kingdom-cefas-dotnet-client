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
    }
}
