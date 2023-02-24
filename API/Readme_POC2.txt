This Api has three endpoints

1. WeatherStats , This endpoint will return weather stats against any city and return records for last two hours since latest inserted record.
2. HighestWindSpeedRecord, This endpoint will return data for highest windspeed graph for all the records that were fetched in the latest api call response, in descending order.
2. MinTempRecord, This endpoint will return data for minimum temperature graph for all the records that were fetched in the latest api call response, in ascending order.


Configurations:

There are three config settings that we can change depending upon the connectivity requirement.
		1. MaxWeatherRecords                              : <For retrieving no of records needed for graphs, by default its set to 10>
		2. WindTemperatureStatsOffsetInSeconds            : <buffer time for inserting the batch for the api call,  by default its set to 30>
		3. DefaultConnection		                    : <Connection string for SQL Server database>

Architecture:
We have used Clean Architecture in this Api.
Logging using serilog for exceptions logging.
Mediatr for achieving CQRS.


Currently Timestamp is in UTC. It can be localized when implementing localization i.e. browser based etc.
Database is storing datetime in UTC and Api is returning in the same format.



