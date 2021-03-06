using SnotelService.Parameters;

namespace SnotelService.Responses
{
    public class HourlyDataResponse : IDataResponse
    {
        private ElementType _type;
        public DataPoint[] DataPoints;

        public HourlyDataResponse(NRCS.hourlyData[] data, ElementType type)
        {
            _type = type;
            DataPoints = new DataPoint[data[0].values.Length];
            for (int i = 0; i < DataPoints.Length; i++)
            {
                DataPoints[i] = new DataPoint(data[0].values[i].value, i, data[0].values[i].dateTime);
            }
        }

        public DataPoint[] GetDataPoints()
        {
            return DataPoints;
        }

        public override string ToString()
        {
            var response = String.Format("{0}\n", _type.ToString());
            foreach (var item in DataPoints)
            {
                response += String.Format("{0} {1} {2}\n", item.Label, item.Value, ElementTypeExtensions.GetUnitsString(_type));
            }
            return response;
        }
    }
}
