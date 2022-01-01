namespace SnotelService.Responses
{
    public class DataPoint
    {
        public Decimal Value;
        public int Index;
        public string Label;

        public DataPoint(Decimal value, int index, string label)
        {
            Value = value;
            Index = index;
            Label = label;
        }
    }
}
