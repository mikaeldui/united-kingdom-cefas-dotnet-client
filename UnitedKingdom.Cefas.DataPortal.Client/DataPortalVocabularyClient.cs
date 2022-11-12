using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace UnitedKingdom.Cefas.DataPortal
{
    /// <summary>
    /// Data for populating auto suggest fields.
    /// </summary>
    public class DataPortalVocabularyClient
    {
        private readonly HttpClient _httpClient;
        internal DataPortalVocabularyClient(HttpClient httpClient) => _httpClient = httpClient;

        /// <summary>
        /// Obtain a list of vocabulary names that match the criteria. 
        /// </summary>
        public async Task<string[]?> GetAutoSuggestAsync(string match) =>
            await _httpClient.GetFromJsonAsync<string[]>("autosuggest/vocabularies?match=" + match);

        /// <summary>
        /// Returns all of the defined vocabularies in the system.
        /// </summary>
        public async Task<Vocabulary[]?> GetVocabulariesAsync() =>
            await _httpClient.GetFromJsonAsync<Vocabulary[]>("vocabularies");

        #region Get Vocabulary

        /// <summary>
        /// Returns the specified vocabulary.
        /// </summary>
        /// <param name="vocabulary">The name of the vocabulary to return.</param>
        public async Task<Vocabulary?> GetVocabularyAsync(string vocabulary) =>
            await _httpClient.GetFromJsonAsync<Vocabulary>("vocabularies/" + vocabulary);

        /// <summary>
        /// Returns the specified vocabulary.
        /// </summary>
        /// <param name="vocabulary">The name of the vocabulary to return.</param>
        public async Task<Vocabulary?> GetVocabularyAsync(Vocabulary vocabulary) =>
            await GetVocabularyAsync(vocabulary.Name);

        #endregion Get Vocabulary

        #region Get Vocabulary Keyword

        /// <summary>
        /// Returns the specified keyword from the specified vocabulary.
        /// </summary>
        /// <param name="vocabulary">The name of the vocabulary to use.</param>
        /// <param name="keyword">The keyword to return</param>
        public async Task<Keyword?> GetVocabularyKeywordAsync(string vocabulary, string keyword) =>
            await _httpClient.GetFromJsonAsync<Keyword>($"vocabularies/{vocabulary}/{keyword}");

        /// <summary>
        /// Returns the specified keyword from the specified vocabulary.
        /// </summary>
        /// <param name="vocabulary">The name of the vocabulary to use.</param>
        /// <param name="keyword">The keyword to return</param>
        public async Task<Keyword?> GetVocabularyKeywordAsync(Vocabulary vocabulary, string keyword) =>
            await GetVocabularyKeywordAsync(vocabulary.Name, keyword);

        /// <summary>
        /// Returns the specified keyword from the specified vocabulary.
        /// </summary>
        /// <param name="vocabulary">The name of the vocabulary to use.</param>
        /// <param name="keyword">The keyword to return</param>
        public async Task<Keyword?> GetVocabularyKeywordAsync(Vocabulary vocabulary, Keyword keyword) =>
            await GetVocabularyKeywordAsync(vocabulary.Name, keyword.Name);

        /// <summary>
        /// Returns the specified keyword from the specified vocabulary.
        /// </summary>
        /// <param name="vocabulary">The name of the vocabulary to use.</param>
        /// <param name="keyword">The keyword to return</param>
        public async Task<Keyword?> GetVocabularyKeywordAsync(string vocabulary, Keyword keyword) =>
            await GetVocabularyKeywordAsync(vocabulary, keyword.Name);

        #endregion Get Vocabulary Keyword
    }
}
