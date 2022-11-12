using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace UnitedKingdom.Cefas.DataPortal
{
    /// <summary>
    /// Actions related to holdings.
    /// </summary>
    public class DataPortalHoldingsClient
    {
        private readonly HttpClient _httpClient;
        internal DataPortalHoldingsClient(HttpClient httpClient) => _httpClient = httpClient;

        #region Get Holding

        /// <summary>
        /// Returns a single holding.
        /// Specifying a date causes the properties (and their values), the holding status and the extent to be returned at the date specified.
        /// The parent/child relationships are not versioned, and the current state is returned, as is the current list of associated recordsets.
        /// </summary>
        /// <param name="id">The Holding ID to return.</param>
        /// <param name="date">If specified, returns the holding as it was at that date, if unspecified returns the current state of the holding.</param>
        public async Task<Holding?> GetHoldingAsync(int id, DateTime? date = null)
        {
            var url = "holdings/" + id;
            if (date != null) url += "?date=" + date;
            return await _httpClient.GetFromJsonAsync<Holding>(url);
        }

        /// <summary>
        /// Returns a single holding.
        /// Specifying a date causes the properties (and their values), the holding status and the extent to be returned at the date specified.
        /// The parent/child relationships are not versioned, and the current state is returned, as is the current list of associated recordsets.
        /// </summary>
        /// <param name="holding">The Holding to return.</param>
        /// <param name="date">If specified, returns the holding as it was at that date, if unspecified returns the current state of the holding.</param>
        public async Task<Holding?> GetHoldingAsync(Holding holding, DateTime? date = null) =>
            await GetHoldingAsync(holding.Id, date);

        #endregion Get Holding

        #region Get Holding Title

        /// <summary>
        /// Returns the current title of the specified holding.
        /// </summary>
        /// <param name="holdingId">The Holding ID to return.</param>
        public async Task<string?> GetHoldingTitleAsync(int holdingId) =>
            await _httpClient.GetFromJsonAsync<string>($"holdings/{holdingId}/title");

        /// <summary>
        /// Returns the current title of the specified holding.
        /// </summary>
        /// <param name="holding">The Holding to return.</param>
        public async Task<string?> GetHoldingTitleAsync(Holding holding) =>
            await GetHoldingTitleAsync(holding.Id);

        #endregion Get Holding Title

        #region Get Holding Siblings

        /// <summary>
        /// Returns a list of sbling holdings that share a common parent holding to the given holding.
        /// </summary>
        /// <param name="holdingId">The ID of the holding to find siblings of.</param>
        public async Task<Holding[]?> GetHoldingSiblingsAsync(int holdingId) =>
            await _httpClient.GetFromJsonAsync<Holding[]>($"holdings/{holdingId}/siblings");

        /// <summary>
        /// Returns a list of sbling holdings that share a common parent holding to the given holding.
        /// </summary>
        /// <param name="holding">The holding to find siblings of.</param>
        public async Task<Holding[]?> GetHoldingSiblingsAsync(Holding holding) =>
            await GetHoldingSiblingsAsync(holding.Id);

        #endregion Get Holding Siblings

        #region Get Holding ID by Medin ID

        /// <summary>
        /// Returns the holding ID for the given Medin ID.
        /// </summary>
        /// <param name="medinId">E.g. "78edae85-c899-409b-ac05-1b5f6c1f68ae".</param>
        public async Task<int> GetHoldingIdByMedinIdAsync(string medinId)
        {
            var result = int.Parse(await _httpClient.GetStringAsync("holdings/medin/" + medinId));
            if (result == -1) throw new HttpRequestException("The user doesn't have access to the holding or the holding doesn't exist");
            return result;
        }

        /// <summary>
        /// Returns the holding ID for the given Medin ID.
        /// </summary>
        /// <param name="medinId">E.g. "78edae85-c899-409b-ac05-1b5f6c1f68ae".</param>
        public async Task<int> GetHoldingIdByMedinIdAsync(Guid medinId) =>
            await GetHoldingIdByMedinIdAsync(medinId.ToString());

        #endregion Get Holding ID by Medin ID

        #region Get Holding Recordsets

        /// <summary>
        /// Returns a list of the recordsets attached to the specified holding.
        /// </summary>
        /// <param name="holdingID">The holding to list recordsets for.</param>
        public async Task<Recordset[]?> GetHoldingRecordsetsAsync(int holdingID) =>
            await _httpClient.GetFromJsonAsync<Recordset[]>($"holdings/{holdingID}/recordsets");

        /// <summary>
        /// Returns a list of the recordsets attached to the specified holding.
        /// </summary>
        /// <param name="holding">The holding to list recordsets for.</param>
        public async Task<Recordset[]?> GetHoldingRecordsetsAsync(Holding holding) =>
            await GetHoldingRecordsetsAsync(holding.Id);

        #endregion Get Holding Recordsets

        #region Get Holding Types

        /// <summary>
        /// Returns all of the holding types in the system.
        /// The information returned for each holding type is the same as when that holding type is selected individually with editmode=true.
        /// </summary>
        public async Task<HoldingType[]?> GetHoldingTypesAsync() =>
            await _httpClient.GetFromJsonAsync<HoldingType[]>("holdingtypes");

        /// <summary>
        /// Returns a single holding type.
        /// The amount of detail returned for the holding type varies depending on the value of editmode.
        /// </summary>
        /// <param name="id">The holding type to retrieve</param>
        public async Task<HoldingType?> GetHoldingTypeAsync(int id, bool editmode = false) =>
            await _httpClient.GetFromJsonAsync<HoldingType>($"holdingtypes/{id}?editmode=" + editmode);

        /// <summary>
        /// Returns a single holding type.
        /// The amount of detail returned for the holding type varies depending on the value of editmode.
        /// </summary>
        /// <param name="id">The holding type to retrieve</param>
        public async Task<HoldingType?> GetHoldingTypeAsync(HoldingType holdingtype, bool editmode = false) =>
            await GetHoldingTypeAsync(holdingtype.Id, editmode);

        #endregion Get Holding Types
    }
}
