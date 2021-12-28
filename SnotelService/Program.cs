using SnotelService.Parameters;

var service = SnotelService.Service.Client;
var meta = await service.GetStationMetadataAsync("787:MT:SNTL");
Console.WriteLine(meta.ToString());

var depth = await service.GetCurrentData("787:MT:SNTL", ElementType.SnowDepth);
Console.WriteLine(depth.ToString());

var temperature = await service.GetCurrentData("787:MT:SNTL", ElementType.AirTemperature);
Console.WriteLine(temperature.ToString());