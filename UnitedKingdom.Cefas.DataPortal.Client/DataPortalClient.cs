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
        private DataPortalHoldingsClient? _holdingsClient;

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

        /// <summary>
        /// Actions related to holdings.
        /// </summary>
        public DataPortalHoldingsClient Holdings => _holdingsClient ??= new DataPortalHoldingsClient(_httpClient);

        #region Get Grids

        /// <summary>
        /// Returns the grid squares that a specified area overlaps.
        /// The parameters should be expressed in degrees between -180 and 180 East/West and -90 and 90 North/South.
        /// If the outer parameter is outside this range it will be clipped to it.
        /// Specifying a north coordinate which is less than the south coordinate is an error.
        /// Specifying an east coordinate which is less than the west coordinate is an error.
        /// </summary>
        /// <param name="north">The Northern Bound of the area.</param>
        /// <param name="south">The Southern Bound of the area.</param>
        /// <param name="east">The Eastern Bound of the area.</param>
        /// <param name="west">The Western Bound of the area.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If north is less than south, or east is less than west.</exception>
        public async Task<int[]?> GetGridsAsync(double north, double south, double east, double west)
        {
            if (north < south) throw new ArgumentException("North can't be less than south.");
            if (east < west) throw new ArgumentException("East can't be less than west.");
            return await _httpClient.GetFromJsonAsync<int[]>($"grids?north={north}&south={south}&east={east}&west={west}");
        }

        /// <summary>
        /// Returns the grid squares that a specified area overlaps.
        /// The parameters should be expressed in degrees between -180 and 180 East/West and -90 and 90 North/South.
        /// If the outer parameter is outside this range it will be clipped to it.
        /// Specifying a north coordinate which is less than the south coordinate is an error.
        /// Specifying an east coordinate which is less than the west coordinate is an error.
        /// </summary>
        /// <param name="area">The Bounds of the area.</param>
        /// <exception cref="ArgumentException">If north is less than south, or east is less than west.</exception>
        public async Task<int[]?> GetGridsAsync(Area area) =>
            await GetGridsAsync(area.NorthBoundLatitude, area.SouthBoundLatitude, area.EastBoundLongitude, area.WestBoundLongitude);

        #endregion

        public void Dispose() => ((IDisposable)_httpClient).Dispose();
    }
}
