using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Web;

namespace UnitedKingdom.Cefas.DataPortal
{
    /// <summary>
    /// Actions related to recordsets and data.
    /// </summary>
    public class DataPortalRecordsetClient
    {
        private readonly HttpClient _httpClient;
        internal DataPortalRecordsetClient(HttpClient httpClient) => _httpClient = httpClient;

        /// <summary>
        /// Returns a list of all recordsets.
        /// </summary>
        public async Task<Recordset[]?> GetRecordsetsAsync() =>
            await _httpClient.GetFromJsonAsync<Recordset[]>("recordsets");

        /// <summary>
        /// Gets the list of recent published recordsets.
        /// </summary>
        /// <param name="count">The number of recordsets that should be returned. Maximum of 100.</param>
        /// <exception cref="ArgumentOutOfRangeException">Maximum of 100.</exception>
        public async Task<Recordset[]?> GetRecentRecordsetsAsync(int count = 12) => 
            count > 100
                ? throw new ArgumentOutOfRangeException(nameof(count), "Maximum of 100.")
                : await _httpClient.GetFromJsonAsync<Recordset[]>("recordsets?count=" + count);

        #region Get Recordset

        /// <summary>
        /// Returns a recordset with a particular ID. 
        /// When run in internal mode, the user must have VIEW permission for the holding the recordset is attached to. 
        /// The fields and filters parameters are populated through to the data/export links which are generated in the response.
        /// </summary>
        /// <param name="id">The ID of the recordset to return.</param>
        /// <param name="filters">The filter conditions which should be used in the subsequent data link.</param>
        /// <param name="fields">The fields which should be displayed in the subsequent data link.</param>
        /// <param name="editMode">Default value: false.</param>
        public async Task<Recordset?> GetRecordsetAsync(int id, string? filters = null, string? fields = null, bool editMode = false)
        {
            var query = HttpUtility.ParseQueryString("");
            if (filters != null) query.Add("filters", filters);
            if (fields != null) query.Add("fields", fields);
            if (editMode != false) query.Add("editMode", "true");
            var queryString = query.ToString();
            if (queryString.Length > 0) queryString = "?" + queryString;
            return await _httpClient.GetFromJsonAsync<Recordset>("recordsets/" + id + queryString);
        }

        /// <summary>
        /// Returns a particular recordset. 
        /// When run in internal mode, the user must have VIEW permission for the holding the recordset is attached to. 
        /// The fields and filters parameters are populated through to the data/export links which are generated in the response.
        /// </summary>
        /// <param name="recordset">The recordset to return.</param>
        /// <param name="filters">The filter conditions which should be used in the subsequent data link.</param>
        /// <param name="fields">The fields which should be displayed in the subsequent data link.</param>
        /// <param name="editMode">Default value: false.</param>
        public async Task<Recordset?> GetRecordsetAsync(Recordset recordset, string? filters = null, string? fields = null, bool editMode = false) =>
            await GetRecordsetAsync(recordset.Id, filters, fields, editMode);

        #endregion Get Recordset

        #region Get Records

        /// <summary>
        /// Returns a single page of records from a recordset.
        /// </summary>
        /// <param name="recordsetId">The recordset to present data from.</param>
        /// <param name="page">The page of results that should be returned, if not specified, 1 is assumed.</param>
        /// <param name="resultsPerPage">The number of entries that should be used for each page of results, if not specified 20 is assumed.</param>
        /// <param name="filters">The filter which define the records that should be returned from the recordset. If not specified all records are returned.</param>
        /// <param name="fields">The fields for which data should be returned as a HTTP string-encoded JSON object. If not specified all fields are returned.</param>
        /// <param name="asAt">Get a specific version of the recordset by date, if not specified, then return the latest version.</param>
        public async Task<Page<Record>?> GetRecordsAsync(int recordsetId, int page = 1, int resultsPerPage = 20, string? filters = null, string? fields = null, DateTime? asAt = null)
        {
            var query = HttpUtility.ParseQueryString("");
            query.Add("page", page.ToString());
            query.Add("resultsPerPage", resultsPerPage.ToString());
            if (filters != null) query.Add("filters", filters);
            if (fields != null) query.Add("fields", fields);
            if (asAt != null) query.Add("asAt", fields);
            return await _httpClient.GetFromJsonAsync<Page<Record>>($"recordsets/{recordsetId}/data?{query}");
        }

        /// <summary>
        /// Returns a single page of records from a recordset.
        /// </summary>
        /// <param name="recordset">The recordset to present data from.</param>
        /// <param name="page">The page of results that should be returned, if not specified, 1 is assumed.</param>
        /// <param name="resultsPerPage">The number of entries that should be used for each page of results, if not specified 20 is assumed.</param>
        /// <param name="filters">The filter which define the records that should be returned from the recordset. If not specified all records are returned.</param>
        /// <param name="fields">The fields for which data should be returned as a HTTP string-encoded JSON object. If not specified all fields are returned.</param>
        /// <param name="asAt">Get a specific version of the recordset by date, if not specified, then return the latest version.</param>
        public async Task<Page<Record>?> GetRecordsAsync(Recordset recordset, int page = 1, int resultsPerPage = 20, string? filters = null, string? fields = null, DateTime? asAt = null) =>
            await GetRecordsAsync(recordset.Id, page, resultsPerPage, filters, fields, asAt);

        #endregion Get Records

        #region Get Record

        /// <summary>
        /// Returns a single record from a recordset which matches the key value. When called against a binary recordset this returns the binary object as an http attachment. When called against a tabular recordset the object that is returned is dynamically typed using the field definitions for the recordset.
        /// </summary>
        /// <param name="recordsetId">The recordset to acquire a record from.</param>
        /// <param name="keyvalue">The value of the key for the desired record. Can be record ID.</param>
        public async Task<Stream> GetRecordAsync(int recordsetId, string keyvalue) =>
            await _httpClient.GetStreamAsync($"recordsets/{recordsetId}/data/{keyvalue}");

        /// <summary>
        /// Returns a single record from a recordset which matches the key value. When called against a binary recordset this returns the binary object as an http attachment. When called against a tabular recordset the object that is returned is dynamically typed using the field definitions for the recordset.
        /// </summary>
        /// <param name="recordset">The recordset to acquire a record from.</param>
        /// <param name="keyvalue">The value of the key for the desired record. Can be record ID.</param>
        public async Task<Stream> GetRecordAsync(Recordset recordset, string keyvalue) =>
            await GetRecordAsync(recordset.Id, keyvalue);

        /// <summary>
        /// Returns a single record from a recordset which matches the key value. When called against a binary recordset this returns the binary object as an http attachment. When called against a tabular recordset the object that is returned is dynamically typed using the field definitions for the recordset.
        /// </summary>
        /// <param name="recordset">The recordset to acquire a record from.</param>
        /// <param name="record">The desired record.</param>
        public async Task<Stream> GetRecordAsync(Recordset recordset, Record record) =>
            await GetRecordAsync(recordset.Id, record.Id.ToString());


        /// <summary>
        /// Returns a single record from a recordset which matches the key value. When called against a binary recordset this returns the binary object as an http attachment. When called against a tabular recordset the object that is returned is dynamically typed using the field definitions for the recordset.
        /// </summary>
        /// <param name="recordsetId">The recordset to acquire a record from.</param>
        /// <param name="record">The desired record.</param>
        public async Task<Stream> GetRecordAsync(int recordsetId, Record record) =>
            await GetRecordAsync(recordsetId, record.Id.ToString());

        #endregion Get Record

        #region Get Files

        /// <summary>
        /// Returns a list of files associated with a recordset. 
        /// Files which were uploaded, but which were subsequently deleted, will not be returned by this call. 
        /// Files which have already been added to their recordset will have an 'importversion'.
        /// </summary>
        /// <param name="recordsetId">The recordset for which file information should be returned.</param>
        public async Task<File[]?> GetRecordsetFilesAsync(int recordsetId) =>
            await _httpClient.GetFromJsonAsync<File[]>($"recordsets/{recordsetId}/files");


        /// <summary>
        /// Returns a list of files associated with a recordset. 
        /// Files which were uploaded, but which were subsequently deleted, will not be returned by this call. 
        /// Files which have already been added to their recordset will have an 'importversion'.
        /// </summary>
        /// <param name="recordset">The recordset for which file information should be returned.</param>
        public async Task<File[]?> GetRecordsetFilesAsync(Recordset recordset) =>
            await GetRecordsetFilesAsync(recordset.Id);

        #endregion Get Files

        #region Get Export

        /// <summary>
        /// Performs a download of a recordset.
        /// </summary>
        /// <param name="recordsetId">The Recordset to Download.</param>
        /// <param name="format">The format in which the download should be provided, only CSV is supported at this time. If this parameter is omitted, CSV is assumed.</param>
        public async Task<Stream> GetExportAsync(int recordsetId, string format = "csv") =>
            await _httpClient.GetStreamAsync($"export/{recordsetId}?format={format}");

        /// <summary>
        /// Performs a download of a recordset.
        /// </summary>
        /// <param name="recordset">The Recordset to Download.</param>
        /// <param name="format">The format in which the download should be provided, only CSV is supported at this time. If this parameter is omitted, CSV is assumed.</param>
        public async Task<Stream> GetExportAsync(Recordset recordset, string format = "csv") =>
            await GetExportAsync(recordset.Id, format);

        #endregion Export

        #region Get  Fields

        /// <summary>
        /// Returns the Fields associated with the recordset. Difinition recordset fields.
        /// </summary>
        /// <param name="recordsetId">The recordset to return filters for. (Note from library developer: endpoint says fields, comment says filters).</param>
        public async Task<Field[]?> GetRecordsetFieldsAsync(int recordsetId) =>
            await _httpClient.GetFromJsonAsync<Field[]>($"recordsets/{recordsetId}/fields");

        /// <summary>
        /// Returns the Fields associated with the recordset. Difinition recordset fields.
        /// </summary>
        /// <param name="recordsetId">The recordset to return filters for. (Note from library developer: endpoint says fields, comment says filters).</param>
        public async Task<Field[]?> GetRecordsetFieldsAsync(Recordset recordset) =>
            await GetRecordsetFieldsAsync(recordset.Id);

        #endregion Get Fields

        #region Get Field Types

        /// <summary>
        /// Returns all of the field types which are recognized by the system. Definition of type of fields that can be included in recordsets.
        /// </summary>
        public async Task<FieldType[]?> GetFieldTypesAsync() =>
            await _httpClient.GetFromJsonAsync<FieldType[]>("fieldtypes");

        /// <summary>
        /// Returns the details of a single field type. Definition of type of fields that can be included in recordsets.
        /// </summary>
        /// <param name="id">The field type to return.</param>
        public async Task<FieldType?> GetFieldTypeAsync(string id) =>
            await _httpClient.GetFromJsonAsync<FieldType>("fieldtypes/" + id);

        /// <summary>
        /// Returns the details of a single field type. Definition of type of fields that can be included in recordsets.
        /// </summary>
        /// <param name="fieldType">The field type to return.</param>
        public async Task<FieldType?> GetFieldTypeAsync(FieldType fieldType) =>
            await GetFieldTypeAsync(fieldType.Name);

        #endregion Get Field Types

        #region Get Recordset Filters

        /// <summary>
        /// Returns filters for the specified recordset. Filter for data in recordsets.
        /// </summary>
        /// <param name="recordsetId">The recordset to return filters for.</param>
        public async Task<Filter[]?> GetRecordsetFiltersAsync(int recordsetId) =>
            await _httpClient.GetFromJsonAsync<Filter[]>($"recordsets/{recordsetId}/filters");

        /// <summary>
        /// Returns filters for the specified recordset. Filter for data in recordsets.
        /// </summary>
        /// <param name="recordset">The recordset to return filters for.</param>
        public async Task<Filter[]?> GetRecordsetFiltersAsync(Recordset recordset) =>
            await GetRecordsetFiltersAsync(recordset.Id);

        #endregion Get Recordset Filters

        #region Get Filter Types

        /// <summary>
        /// Returns filter types which are recognized by the system.
        /// </summary>
        /// <param name="fieldType">If specified, only those filter types which apply to the selected field are returned.</param>
        public async Task<FilterType[]?> GetFilterTypesAsync(string? fieldType = null)
        {
            var url = "filtertypes";
            if (fieldType != null) url += "?fieldType=" + fieldType;
            return await _httpClient.GetFromJsonAsync<FilterType[]>(url);
        }

        /// <summary>
        /// Returns filter types which are recognized by the system.
        /// </summary>
        /// <param name="fieldType">If specified, only those filter types which apply to the selected field are returned.</param>
        public async Task<FilterType[]?> GetFilterTypesAsync(FieldType fieldType) =>
            await GetFilterTypesAsync(fieldType.Name);

        #endregion Get Filter Types

        #region Get WMS

        /// <summary>
        /// Return <see cref="Stream"/> because unknown return type. Returns WMS for a given recordset.
        /// </summary>
        public async Task<Stream> GetRecordsetWmsAsync(int recordsetId) =>
            await _httpClient.GetStreamAsync($"recordsets/{recordsetId}/wms");

        /// <summary>
        /// Return <see cref="Stream"/> because unknown return type. Returns WMS for a given recordset.
        /// </summary>
        public async Task<Stream> GetRecordsetWmsAsync(Recordset recordset) =>
            await GetRecordsetWmsAsync(recordset.Id);

        #endregion Get WMS

        #region Get WFS

        /// <summary>
        /// Return <see cref="Stream"/> because unknown return type. Returns WFS for a given recordset.
        /// </summary>
        public async Task<Stream> GetRecordsetWfsAsync(int recordsetId) =>
            await _httpClient.GetStreamAsync($"recordsets/{recordsetId}/wfs");

        /// <summary>
        /// Return <see cref="Stream"/> because unknown return type. Returns WFS for a given recordset.
        /// </summary>
        public async Task<Stream> GetRecordsetWfsAsync(Recordset recordset) =>
            await GetRecordsetWfsAsync(recordset.Id);

        #endregion Get WFS

    }

    /// <summary>
    /// Haven't found any definition for this yet.
    /// </summary>
    public class Filter
    {
    }
}
