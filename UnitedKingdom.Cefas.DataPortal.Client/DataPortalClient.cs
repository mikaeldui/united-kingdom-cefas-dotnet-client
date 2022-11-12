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

        #region Export

        /// <summary>
        /// Performs a download of a recordset.
        /// </summary>
        /// <param name="recordsetId">The Recordset to Download.</param>
        /// <param name="format">The format in which the download should be provided, only CSV is supported at this time. If this parameter is omitted, CSV is assumed.</param>
        public async Task<Stream> GetResultsetExportAsync(int recordsetId, string format = "csv") =>
            await _httpClient.GetStreamAsync($"export/{recordsetId}?format={format}");

        /// <summary>
        /// Performs a download of a recordset.
        /// </summary>
        /// <param name="recordset">The Recordset to Download.</param>
        /// <param name="format">The format in which the download should be provided, only CSV is supported at this time. If this parameter is omitted, CSV is assumed.</param>
        public async Task<Stream> GetResultsetExportAsync(Recordset recordset, string format = "csv") =>
            await GetResultsetExportAsync(recordset.Id, format);

        #endregion Export

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
