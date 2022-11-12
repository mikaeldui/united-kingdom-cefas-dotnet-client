﻿using System;
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

        #endregion Get Holding ID by Medin ID
    }
}
