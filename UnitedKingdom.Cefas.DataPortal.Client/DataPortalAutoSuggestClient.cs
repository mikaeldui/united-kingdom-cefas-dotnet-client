using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace UnitedKingdom.Cefas.DataPortal
{
    /// <summary>
    /// Data for populating auto suggest fields.
    /// </summary>
    public class DataPortalAutoSuggestClient
    {
        private readonly HttpClient _httpClient;
        internal DataPortalAutoSuggestClient(HttpClient httpClient) => _httpClient = httpClient;

        /// <summary>
        /// Obtain a list of vocabulary names that match the criteria. 
        /// </summary>
        public async Task<string[]?> GetVocabulariesAsync(string match) =>
            await _httpClient.GetFromJsonAsync<string[]>("autosuggest/vocabularies?match=" + match);
    }
}
