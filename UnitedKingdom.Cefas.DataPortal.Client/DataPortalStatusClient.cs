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

        /// <summary>
        /// Information about availability of other service endpoints.
        /// This call hits a number of other service endpoints to see that they are running correctly.
        /// This call can be made to run asynchronously. Hitting the services asynchronously will return faster, but the response times will be less useful.
        /// </summary>
        /// <param name="async">Whether to make the service calls asynchronously. If not specified, false is assumed.</param>
        public async Task<ServiceStatus[]?> GetServiceStatusAsync(bool async = false) =>
            await _httpClient.GetFromJsonAsync<ServiceStatus[]>("status/services?async=" + async);

        /// <summary>
        /// Information about the storage databases that are configured.
        /// This call contacts all of the storage databases to determine if any of the recordsets declared for them are missing, 
        /// or if there are any data tables that are not being included in recordsets.
        /// </summary>
        public async Task<LocationStatus[]?> GetLocationStatusAsync() =>
            await _httpClient.GetFromJsonAsync<LocationStatus[]>("status/locations");
    }

    public class LocationStatus
    {
        /// <summary>
        /// E.g. "Smartbuoy".
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// E.g. "Microsoft.Data.SqlClient".
        /// </summary>
        public string Type { get; set; }
        public bool AbleToConnect { get; set; }
        public bool ExternallyAccessible { get; set; }
        public Dictionary<string, int>? RecordsetNumbers { get; set; }
        public string[]? BrokenRecordsets { get; set; }
        public string[]? MissingTables { get; set; }
        public string[]? OrphanedTables { get; set; }
    }

    public class ServiceStatus
    {
        public Uri Location { get; set; }
        public int ResponseCount { get; set; }
        public TimeSpan ResponseTime { get; set; }
        public int ResponseSize { get; set; }
        public int ResponseCode { get; set; }
        public string ResponseStatus { get; set; }
        public bool AbleToConnect { get; set; }
    }
}
