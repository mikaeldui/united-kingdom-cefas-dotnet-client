using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace UnitedKingdom.Cefas.DataPortal
{
    public class DataPortalClient : IDisposable
    {
        private HttpClient _httpClient;
        private DataPortalAutoSuggestClient? _autoSuggestClient;
        private DataPortalRecordsetClient? _recordsetClient;

        public DataPortalClient()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://data-api.cefas.co.uk/api/", UriKind.Absolute)
            };
            _httpClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
        }

        /// <summary>
        /// Data for populating auto suggest fields.
        /// </summary>
        public DataPortalAutoSuggestClient AutoSuggest => _autoSuggestClient ??= new DataPortalAutoSuggestClient(_httpClient);
        
        /// <summary>
        /// Actions related to recordsets and data.
        /// </summary>
        public DataPortalRecordsetClient Recordsets => _recordsetClient ??= new DataPortalRecordsetClient(_httpClient);

        public void Dispose() => ((IDisposable)_httpClient).Dispose();
    }
}
