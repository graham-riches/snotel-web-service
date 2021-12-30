using SnotelService.Parameters;

namespace SnotelService.Responses
{
    public class DataResponse
    {
        private NRCS.data _data;
        private ElementType _type;
        public Decimal Value { get; }

        public DataResponse(NRCS.data data, ElementType type)
        {
            _data = data;
            _type = type;
            Value = data.values[0] ?? 0;
        }

        public override string ToString() =>
            $"{_data.stationTriplet} - {_type.ToString()} - {_data.values[0].ToString()} {ElementTypeExtensions.GetUnitsString(_type)}";
    }
}
