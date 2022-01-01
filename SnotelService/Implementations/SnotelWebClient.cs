using SnotelService.Interfaces;
using SnotelService.Responses;
using SnotelService.Parameters;
using System.Linq;

namespace SnotelService.Implementations
{
    public class SnotelWebClient : ISnotelWebClient
    {
        private NRCS.AwdbWebServiceClient _client;

        public SnotelWebClient()
        {
            _client = new NRCS.AwdbWebServiceClient();
        }

        public async Task<StationMetadataResponse> GetStationMetadataAsync(string stationTriplet)
        {
            var result = await _client.getStationMetadataAsync(stationTriplet);
            return new StationMetadataResponse(result.@return);
        }

        public async Task<DataResponse> GetCurrentDataAsync(string stationTriplet, ElementType dataType)
        {
            var now = DateTime.Now.ToString("MM/dd/yyyy");
            var result = await _client.getDataAsync(new string[] {stationTriplet}, ElementTypeExtensions.ToFriendlyString(dataType), 1, new NRCS.heightDepth(),
                NRCS.duration.DAILY, false, now, now, true);
            return new DataResponse(result.@return[0], dataType);
        }

        public async Task<HourlyDataResponse> GetHourlyDataAsync(string stationTriplet, ElementType dataType, DateTime start, DateTime? end)
        {
            var endTime = end ?? DateTime.Now.AddDays(1);
            var result = await _client.getHourlyDataAsync(new string[] { stationTriplet }, ElementTypeExtensions.ToFriendlyString(dataType), 1, new NRCS.heightDepth(),
                start.ToString("MM/dd/yyyy"), endTime.ToString("MM/dd/yyyy"), 0, 24); 
            return new HourlyDataResponse(result.@return, dataType);
        }

        public async Task<DailyDataResponse> GetDailyDataAsync(string stationTriplet, ElementType dataType, DateTime start, DateTime? end = null)
        {
            var endTime = end ?? DateTime.Now;
            var result = await _client.getDataAsync(new string[] { stationTriplet }, ElementTypeExtensions.ToFriendlyString(dataType), 1, new NRCS.heightDepth(),
                NRCS.duration.DAILY, false, start.ToString("MM/dd/yyyy"), endTime.ToString("MM/dd/yyyy"), true);
            var values = result.@return;
            return new DailyDataResponse(values[0], dataType);
        }

        public async Task<StationMetadataResponse[]> GetStationsAsync(string[]? states = null, string[]? counties = null, int minElevation = 0, int maxElevation = 100000)
        {
            var matchAll = new string[] { "*" };
            states = states ?? matchAll;
            counties = counties ?? matchAll;
            var stations = await _client.getStationsAsync(matchAll, states, new string[] { "SNTL" }, matchAll, counties,
                -180, 180, -180, 180, minElevation, maxElevation, matchAll, new int[] { 1 }, new NRCS.heightDepth[] { }, true);            
            var metadata = await _client.getStationMetadataMultipleAsync(stations.@return);
            return metadata.@return.Select(m => new StationMetadataResponse(m)).ToArray();                     
        }
    }
}
