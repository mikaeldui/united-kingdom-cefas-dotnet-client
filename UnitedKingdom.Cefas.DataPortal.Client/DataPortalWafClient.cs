using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace UnitedKingdom.Cefas.DataPortal
{
    /// <summary>
    /// Data for populating auto suggest fields.
    /// </summary>
    public class DataPortalWafClient
    {
        private readonly HttpClient _httpClient;
        internal DataPortalWafClient(HttpClient httpClient) => _httpClient = httpClient;

        /// <summary>
        /// Get a list of all valid WAF endpoints defined from the holding data publish metadata to field.
        /// </summary>
        public async Task<string[]?> GetWafEndpointsAsync() =>
            await _httpClient.GetFromJsonAsync<string[]>("waf");

        /// <summary>
        /// Generates a WAF for export to a particular destination.
        /// This call is primarily for use by harvesters to replicate metadata onto external systems.
        /// In order for a holding to be included in the output, it must be set to export its metadata to the destination specified.
        /// In order for the links to work, there must be an XSLT set up for the destination.
        /// </summary>
        /// <param name="destination">The destination for which the AF should be generated. You can get this from <see cref="GetWafEndpointsAsync"/>.</param>
        /// <param name="date">The date for which the WAF should be ganarated. If omitted the current WAF is generated.</param>
        public async Task<Stream> GetWafAsync(string destination, DateTime? date = null)
        {
            var url = $"waf/{destination}/index.html";
            if (date != null) url += "?date=" + date;
            return await _httpClient.GetStreamAsync(url);
        }

        /// <summary>
        /// Get list of holdings included in the specified WAF endpoint.
        /// </summary>
        /// <param name="destination">You can get this from <see cref="GetWafEndpointsAsync"/>.</param>
        public async Task<WafHolding[]?> GetWafHoldingsAsync(string destination) =>
            await _httpClient.GetFromJsonAsync<WafHolding[]>($"waf/{destination}/validate");

        #region Get Holding WAF

        /// <summary>
        /// Generates an export for a particular holding. 
        /// This call is primarily for use by harvesters to replicate metadata onto external systems. 
        /// The output will always be an XML document, regardless of the other request options.
        /// </summary>
        /// <param name="destination">The destination for which the WAF should be generated. You can get this from <see cref="GetWafEndpointsAsync"/>.</param>
        /// <param name="holdingId">The Holding to export.</param>
        /// <param name="asOfdate">Specify this to get a historic holding record, emit it for the current one.</param>
        public async Task<Stream> GetHoldingWafAsync(string destination, int holdingId, DateTime? asOfdate = null)
        {
            var url = $"waf/{destination}/{holdingId}.xml";
            if (asOfdate != null) url += "?asOfDate=" + asOfdate;
            return await _httpClient.GetStreamAsync(url);
        }

        /// <summary>
        /// Generates an export for a particular holding. 
        /// This call is primarily for use by harvesters to replicate metadata onto external systems. 
        /// The output will always be an XML document, regardless of the other request options.
        /// </summary>
        /// <param name="destination">The destination for which the WAF should be generated. You can get this from <see cref="GetWafEndpointsAsync"/>.</param>
        /// <param name="holding">The Holding to export.</param>
        /// <param name="asOfdate">Specify this to get a historic holding record, emit it for the current one.</param>
        public async Task<Stream> GetHoldingWafAsync(string destination, Holding holding, DateTime? asOfdate = null) =>
            await GetHoldingWafAsync(destination, holding.Id, asOfdate);

        /// <summary>
        /// Generates an export for a particular holding. 
        /// This call is primarily for use by harvesters to replicate metadata onto external systems. 
        /// The output will always be an XML document, regardless of the other request options.
        /// </summary>
        /// <param name="destination">The destination for which the WAF should be generated. You can get this from <see cref="GetWafEndpointsAsync"/>.</param>
        /// <param name="holding">The Holding to export.</param>
        /// <param name="asOfdate">Specify this to get a historic holding record, emit it for the current one.</param>
        public async Task<Stream> GetHoldingWafAsync(string destination, WafHolding holding, DateTime? asOfdate = null) =>
            await GetHoldingWafAsync(destination, holding.HoldingId, asOfdate);

        #endregion Get Holding WAF

        ///// <summary>
        ///// Validate a specific holding.
        ///// </summary>
        ///// <param name="destination">You can get this from <see cref="GetWafEndpointsAsync"/>.</param>
        ///// <param name="holdingId">The holding ID to validate.</param>
        //public async Task<WafHolding?> GetWafHoldingAsync(string destination, int holdingId) =>
        //    await _httpClient.GetFromJsonAsync<WafHolding>($"waf/{destination}/validate/{holdingId}");

        ///// <summary>
        ///// Validate a specific holding.
        ///// </summary>
        ///// <param name="destination">You can get this from <see cref="GetWafEndpointsAsync"/>.</param>
        ///// <param name="holding">The holding to validate.</param>
        //public async Task<WafHolding_> GetWafHoldingAsync(string destination, Holding holding) =>
        //    await GetWafHoldingAsync(destination, holding.Id);

        ///// <summary>
        ///// Validate a specific holding.
        ///// </summary>
        ///// <param name="destination">You can get this from <see cref="GetWafEndpointsAsync"/>.</param>
        ///// <param name="holding">The holding to validate.</param>
        //public async Task<WafHolding_> GetWafHoldingAsync(string destination, WafHolding holding) =>
        //    await GetWafHoldingAsync(destination, holding.HoldingId);
    }
}
