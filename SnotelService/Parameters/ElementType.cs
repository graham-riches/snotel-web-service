namespace SnotelService.Parameters
{
    public enum ElementType
    {
        AirTemperatureAverage,
        AirTemperatureMinimum,
        AirTemperatureMaximum,
        AirTemperature,
        PrecipitationAccumulation,
        SnowDepth,
        SnowWaterEquivalent,
    }

    public static class ElementTypeExtensions
    {
        public static string ToFriendlyString(ElementType type) =>
            type switch
            {
                ElementType.AirTemperatureAverage => "TAVG",
                ElementType.AirTemperatureMinimum => "TMIN",
                ElementType.AirTemperatureMaximum => "TMAX",
                ElementType.AirTemperature => "TOBS",
                ElementType.PrecipitationAccumulation => "PREC",
                ElementType.SnowDepth => "SNWD",
                ElementType.SnowWaterEquivalent => "WTEQ",
                _ => throw new NotImplementedException("Invalid element type")
            };

        public static String GetUnitsString(ElementType type) =>
            type switch
            {
                ElementType.AirTemperatureAverage => "Fahrenheit",
                ElementType.AirTemperatureMinimum => "Fahrenheit",
                ElementType.AirTemperatureMaximum => "Fahrenheit",
                ElementType.AirTemperature => "Fahrenheit",
                ElementType.PrecipitationAccumulation => "Inches",
                ElementType.SnowDepth => "Inches",
                ElementType.SnowWaterEquivalent => "Inches",
                _ => throw new NotImplementedException("Invalid element type")
            };
    }
}
