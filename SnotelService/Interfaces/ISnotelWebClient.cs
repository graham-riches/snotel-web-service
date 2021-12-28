using SnotelService.Responses;
using SnotelService.Parameters;

namespace SnotelService.Interfaces
{
    public interface ISnotelWebClient
    {
        public Task<StationMetadataResponse> GetStationMetadataAsync(string stationTriplet); 

        public Task<DataResponse> GetCurrentData(string stationTriplet, ElementType dataType);
    }
}
