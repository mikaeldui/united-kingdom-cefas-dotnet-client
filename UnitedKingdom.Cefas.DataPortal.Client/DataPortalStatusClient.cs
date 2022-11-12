using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace UnitedKingdom.Cefas.DataPortal
{
    /// <summary>
    /// Data for populating auto suggest fields.
    /// </summary>
    public class DataPortalStatusClient
    {
        private readonly HttpClient _httpClient;
        internal DataPortalStatusClient(HttpClient httpClient) => _httpClient = httpClient;

        /// <summary>
        /// Obtain a list of vocabulary names that match the criteria. 
        /// </summary>
        public async Task<Status?> GetStatusAsync() =>
            await _httpClient.GetFromJsonAsync<Status>("status");
    }
}
