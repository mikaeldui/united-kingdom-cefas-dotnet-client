using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Web;

namespace UnitedKingdom.Cefas.DataPortal
{
    /// <summary>
    /// Actions related to holdings.
    /// </summary>
    public class DataPortalHoldingsClient
    {
        private readonly HttpClient _httpClient;
        private DataPortalWafClient? _wafClient;
        internal DataPortalHoldingsClient(HttpClient httpClient) => _httpClient = httpClient;

        /// <summary>
        /// WAF endpoints for data harvesters.
        /// </summary>
        public DataPortalWafClient Wafs => _wafClient ??= new DataPortalWafClient(_httpClient);

        #region Get Holdings

        /// <summary>
        /// Returns a page of holdings recognized by the system.
        /// There are multiple possible parameters to this call, but only some of them may be used at any time.
        /// When no parameters are specified, every holding in the system is returned.
        /// Searchterm and keyword behave independently, matches to either will cause a holding to be returned.
        /// If Searchterm is not specified then searchproperty will be ignored.
        /// If the keyword parameter is exactly the string "{searchterm}" then the searchterm is used to find
        /// matching keywords and matches to the keyword will be returned also
        /// and the FIRST matching keyword is used to identify holdings.
        /// Additionally, not more than one of the geographic options (gridid, region or the pair of regionclass and classitem) may be defined.
        /// If GridId is specified then region and regionclass/classitem will be ignored.
        /// If region is specified then regionclass/classitem willl be ignored
        /// If regionclass is specified, then the classitem must be specified also.
        /// Note that, as of this release, regionclass and classitem do not have any effect on the result set.
        /// </summary>
        /// <param name="page">The page number of the results to return.</param>
        /// <param name="resultsPerPage">The number of results to show on each page.</param>
        /// <param name="searchTerm">The word(s) that needs to appear in the holding for it to be included in the set of results.</param>
        /// <param name="keyword">
        /// The keyword(s) that needs to appear in one of the holdings properties in order for that holding to be included in the set of results. 
        /// Multiple keywords can be entered separated by whitespace.</param>
        /// <param name="gridId">The Grid Cell which holdings must be in to be returned.</param>
        /// <param name="region">A WKT representation of the area that a search should be conducted within.</param>
        /// <param name="regionClass">The typeo of region that should be searched for.</param>
        /// <param name="classItem">The object within the region class that search should be conducted on.</param>
        /// <param name="searchProperty">If Specified, the property on which a search should be performed, if not specified, then all properties are searched.</param>
        /// <param name="status">If specified, filter the results based on the status of the holding.</param>
        /// <param name="parent">Optionally limit the search results to holdings below the specified parent.</param>
        /// <param name="dateField">Optionally limit the search results to a specified date range based on the specific field.</param>
        /// <param name="start">If the date field is set, limit to records on or after this date.</param>
        /// <param name="end">If the date field is set, limit to records on or before this date.</param>
        /// <param name="types">If specified, filter the results based on the holding type. Multiple types can be entered separated by whitespace.</param>
        /// <param name="enableThesaurus">If <see langword="true"/>, search on a list of expansions or replacements for the search terms based on matches in the thesaurus.</param>
        public async Task<Page<Holding>?> GetHoldingsAsync(int page = 1, int resultsPerPage = 10, 
            string? searchTerm = null, string? keyword = null, int? gridId = null,
            string? region = null, string? regionClass = null, string? classItem = null,
            string? searchProperty = null, int? status = null, int? parent = null,
            string? dateField = null, string? start = null, string? end = null,
            string? types = null, bool enableThesaurus = false)
        {
            var query = HttpUtility.ParseQueryString("");
            query.Add("page", page.ToString());
            query.Add("resultsperpage", resultsPerPage.ToString());
            if (searchTerm != null) query.Add("searchterm", searchTerm);
            if (keyword != null) query.Add("keyword", keyword);
            if (gridId != null) query.Add("gridid", gridId.ToString());
            if (region != null) query.Add("region", region);
            if (regionClass != null) query.Add("regionclass", regionClass);
            if (classItem != null) query.Add("classitem", classItem);
            if (searchProperty != null) query.Add("searchproperty", searchProperty);
            if (status != null) query.Add("status", status.ToString());
            if (parent != null) query.Add("parent", parent.ToString());
            if (dateField != null) query.Add("datefield", dateField);
            if (start != null) query.Add("start", start);
            if (end != null) query.Add("end", end);
            if (types != null) query.Add("types", types);
            if (enableThesaurus != false) query.Add("enablethesaurus", "true");
            var queryString = query.ToString();
            if (queryString.Length > 0) queryString = "?" + queryString;
            return await _httpClient.GetFromJsonAsync<Page<Holding>>("holdings" + queryString);
        }

        #endregion Get Holdings

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

        #region Get Keywords

        /// <summary>
        /// Returns number of holdings which use each keyword.
        /// The results are sorted in descending order of the number of holdings using each keyword.
        /// </summary>
        public async Task<Keyword[]?> GetKeywordsAsync(bool includeAll = false) =>
            await _httpClient.GetFromJsonAsync<Keyword[]>("keywords?includeall=" + includeAll);

        /// <summary>
        /// Returns the details of an individual keyword. 
        /// This call may be used to acquire a more friendly display name for a keyword.
        /// </summary>
        public async Task<Keyword?> GetKeywordAsync(string id) =>
            await _httpClient.GetFromJsonAsync<Keyword>("keywords/" + id);

        /// <summary>
        /// Returns the details of an individual keyword. 
        /// This call may be used to acquire a more friendly display name for a keyword.
        /// </summary>
        public async Task<Keyword?> GetKeywordAsync(Keyword keyword) =>
            await GetKeywordAsync(keyword.Value ?? keyword.Name);

        #endregion Get Keywords

        #region Get Date Properties

        /// <summary>
        /// Gets a list of all date properties.
        /// Definition of properties that can be included in holding types.
        /// </summary>
        public async Task<DateProperty[]?> GetDatePropertiesAsync() =>
            await _httpClient.GetFromJsonAsync<DateProperty[]>("dateproperties");

        #endregion

        #region Get Properties

        /// <summary>
        /// Gets a list of all properties.
        /// </summary>
        public async Task<Property[]?> GetPropertiesAsync() =>
            await _httpClient.GetFromJsonAsync<Property[]>("properties");

        #endregion Get Properties

        #region Get Property

        /// <summary>
        /// Get property by short name.
        /// </summary>
        /// <param name="shortName">The short name of the property to find.</param>
        public async Task<Property?> GetPropertyAsync(string shortName) =>
            await _httpClient.GetFromJsonAsync<Property>("properties/" + shortName);

        #endregion Get Property

        #region Get XML Export

        /// <summary>
        /// Generates an XML representation of a holding as a step towards exporting to MEDIN format.
        /// This service call cascades from the holdings endpoint, and permissions pass down to there.
        /// </summary>
        /// <param name="holdingId">The holding to generate an XML representation of.</param>
        public async Task<Stream> GetHoldingXmlExportAsync(int holdingId) => 
            await _httpClient.GetStreamAsync($"holdings/{holdingId}/xmlexport");

        /// <summary>
        /// Generates an XML representation of a holding as a step towards exporting to MEDIN format.
        /// This service call cascades from the holdings endpoint, and permissions pass down to there.
        /// </summary>
        /// <param name="holding">The holding to generate an XML representation of.</param>
        public async Task<Stream> GetHoldingXmlExportAsync(Holding holding) =>
            await GetHoldingXmlExportAsync(holding.Id);

        #endregion
    }
}
