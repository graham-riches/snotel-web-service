using SnotelService.Responses;
using SnotelService.Parameters;

namespace SnotelService.Interfaces
{
    public interface ISnotelWebClient
    {
        /// <summary>
        /// Get station metadata for a station
        /// </summary>
        /// <param name="stationTriplet">The station triplet string: i.e. "787:MT:SNTL"</param>
        /// <returns>MetadataResponse</returns>
        public Task<StationMetadataResponse> GetStationMetadataAsync(string stationTriplet);

        /// <summary>
        /// Get current station data for a single data type
        /// </summary>
        /// <param name="stationTriplet">The station triplet string: i.e. "787:MT:SNTL"</param>
        /// <param name="dataType">Data type to retrieve</param>
        /// <returns>Data response</returns>
        public Task<DataResponse> GetCurrentDataAsync(string stationTriplet, ElementType dataType);

        /// <summary>
        /// Get hourly station data for a single data type
        /// </summary>
        /// <param name="stationTriplet">The station triplet string: i.e. "787:MT:SNTL</param>
        /// <param name="dataType">Data type to retrieve</param>
        /// <param name="start">Start time</param>
        /// <param name="end">End time</param>
        /// <returns></returns>
        public Task<HourlyDataResponse> GetHourlyDataAsync(string stationTriplet, ElementType dataType, DateTime start, DateTime? end = null);

        /// <summary>
        /// Get daily site data over a time range for a single data type
        /// </summary>
        /// <param name="stationTriplet">The station triplet string: i.e. "787:MT:SNTL"</param>
        /// <param name="dataType">Data type to retrieve</param>
        /// <param name="start">Start date</param>
        /// <param name="end">End date</param>
        /// <returns></returns>
        public Task<DailyDataResponse> GetDailyDataAsync(string stationTriplet, ElementType dataType, DateTime start, DateTime? end = null);

        /// <summary>
        /// Get snotel stations. If no arguments are passed, the default is to return all stations
        /// </summary>
        /// <param name="states">Array of states, can include wildcard patterns</param>
        /// <param name="counties">Array of counties, can include wildcard patterns</param>
        /// <param name="minElevation">Minimum site elevation</param>
        /// <param name="maxElevation">Maximum site elevation</param>
        /// <returns></returns>
        public Task<StationMetadataResponse[]> GetStationsAsync(string[]? states = null, string[]? counties = null, int minElevation = 0, int maxElevation = 100000);
    }
}
