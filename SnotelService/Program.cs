using SnotelService.Parameters;

var service = SnotelService.Service.Client;
var meta = await service.GetStationMetadataAsync("787:MT:SNTL");
Console.WriteLine(meta.ToString());

var depth = await service.GetCurrentData("787:MT:SNTL", ElementType.SnowDepth);
Console.WriteLine(depth.ToString());

var temperature = await service.GetCurrentData("787:MT:SNTL", ElementType.AirTemperature);
Console.WriteLine(temperature.ToString());

var hourlyTemperature = await service.GetHourlyData("787:MT:SNTL", ElementType.AirTemperature, DateTime.Now.AddHours(-24));
Console.WriteLine(hourlyTemperature.ToString());

var montanaStations = await service.GetStations(new string[] {"MT"} );
foreach (var station in montanaStations)
{
    Console.WriteLine(station.ToString());
}