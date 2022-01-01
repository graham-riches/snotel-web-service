using SnotelService.Parameters;

namespace SnotelService.Responses
{
    public class DailyDataResponse : IDataResponse
    {
        private ElementType _type;
        public DataPoint[] DataPoints;

        public DailyDataResponse(NRCS.data data, ElementType type)
        {
            _type = type;
            DataPoints = new DataPoint[data.values.Length];
            var start = DateTime.Parse(data.beginDate);
            for (int i = 0; i < DataPoints.Length; i++)
            {
                var timestamp = start.AddDays(i);
                DataPoints[i] = new DataPoint(data.values[i] ?? 0, i, timestamp.ToString("MM/dd/yyyy HH:mm:ss"));
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
