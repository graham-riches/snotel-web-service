using SnotelService.Parameters;

namespace SnotelService.Responses
{
    public class DataResponse
    {
        private NRCS.data _data;
        private ElementType _type;

        public DataResponse(NRCS.data data, ElementType type)
        {
            _data = data;
            _type = type;            
        }

        public override string ToString() =>
            $"{_data.stationTriplet} - {_type.ToString()} - {_data.values[0].ToString()} {ElementTypeExtensions.GetUnitsString(_type)}";
    }
}
