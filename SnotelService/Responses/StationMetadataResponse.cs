
namespace SnotelService.Responses
{
    public class StationMetadataResponse : NRCS.stationMetaData
    {
        private NRCS.stationMetaData _stationMetaData;

        public string Name { get; }
        public string State { get; }
        public string County { get; }
        public string Location { get; }
        public Decimal Elevation { get;  }

        public StationMetadataResponse(NRCS.stationMetaData metaData)
        {
            _stationMetaData = metaData;
            Name = metaData.name;
            State = metaData.fipsStateNumber;
            County = metaData.countyName;
            Location = String.Format("{0},{1}", metaData.latitude.ToString(), metaData.longitude.ToString());
            Elevation = metaData.elevation;
        }

        public override string ToString() => $"{nameof(StationMetadataResponse)}:\n"
                                           + $"Name: {Name}\n"
                                           + $"State: {State}\n"
                                           + $"County: {County}\n"
                                           + $"Location: {Location}\n"
                                           + $"Elevation: {Elevation}\n";

    }
}
