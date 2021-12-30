using SnotelService.Parameters;

namespace SnotelService.Responses
{
    public class HourlyDataResponse
    {
        private NRCS.hourlyData[] _data;
        private ElementType _type;

        public HourlyDataResponse(NRCS.hourlyData[] data, ElementType type)
        {
            _data = data;
            _type = type;
        }

        public override string ToString()
        {
            var response = String.Format("{0} - {1}\n", _data[0].stationTriplet, _type.ToString());
            foreach (var item in _data[0].values)
            {
                response += String.Format("{0} {1} {2}\n", item.dateTime, item.value, ElementTypeExtensions.GetUnitsString(_type));
            }
            return response;
        }
            
    }
}
