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
    }
}
