using SnotelService.Interfaces;
using SnotelService.Responses;
using SnotelService.Parameters;

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

        public async Task<DataResponse> GetCurrentData(string stationTriplet, ElementType dataType)
        {
            var now = DateTime.Now.ToString("MM/dd/yyyy");
            var result = await _client.getDataAsync(new string[] {stationTriplet}, ElementTypeExtensions.ToFriendlyString(dataType), 1, new NRCS.heightDepth(),
                new NRCS.duration(), false, now, now, true);
            return new DataResponse(result.@return[0], dataType);
        }
    }
}
