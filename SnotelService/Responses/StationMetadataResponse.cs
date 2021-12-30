
namespace SnotelService.Responses
{
    public class StationMetadataResponse : NRCS.stationMetaData
    {
        private NRCS.stationMetaData _stationMetaData;

        public StationMetadataResponse(NRCS.stationMetaData metaData)
        {
            _stationMetaData = metaData;
        }

        public override string ToString() => $"{nameof(StationMetadataResponse)}:\n"
                                           + $"Name: {_stationMetaData.name}\n"
                                           + $"State: {_stationMetaData.fipsStateNumber}\n"
                                           + $"County: {_stationMetaData.countyName}\n"
                                           + $"Location: {_stationMetaData.latitude.ToString()}, {_stationMetaData.longitude.ToString()}\n"
                                           + $"Elevation: {_stationMetaData.elevation.ToString()}\n";

    }
}
