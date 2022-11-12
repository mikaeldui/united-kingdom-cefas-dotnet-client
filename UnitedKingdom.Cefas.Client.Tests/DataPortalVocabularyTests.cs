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
    public class DataPortalVocabularyTests
    {
        [TestMethod]
        public async Task GetAutoSuggestVocabulariesAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Vocabularies.GetAutoSuggestAsync("a");
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First());
        }

        [TestMethod]
        public async Task GetVocabulariesAsync()
        {
            using DataPortalClient client = new();
            var result = await client.Vocabularies.GetVocabulariesAsync();
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First().Name);
            Assert.IsTrue(result.First().Keywords.Any());
            Assert.IsNotNull(result.First().Keywords.First().Name);
        }

        [TestMethod]
        public async Task GetVocabularyAsync()
        {
            using DataPortalClient client = new();
            var vocabularies = await client.Vocabularies.GetVocabulariesAsync();
            var result = await client.Vocabularies.GetVocabularyAsync(vocabularies.First());
            Assert.IsNotNull(result.Name);
            Assert.IsTrue(result.Keywords.Any());
            Assert.IsNotNull(result.Keywords.First().Name);
        }

        [TestMethod]
        public async Task GetVocabularyKeywordAsync()
        {
            using DataPortalClient client = new();
            var vocabularies = await client.Vocabularies.GetVocabulariesAsync();
            var result = await client.Vocabularies.GetVocabularyKeywordAsync(vocabularies.First(), vocabularies.First().Keywords.First());
            Assert.IsNotNull(result.Name);
        }
    }
}
