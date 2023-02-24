General: Please create a DB and feed initial records using SQL file, added in root directory. 

API Solution:
This Api has three endpoints

1. GetWeatherStats , This endpoint will return weather stats against any city and return records for last two hours since latest inserted record.
2. HighestWindSpeed, This endpoint will return data for highest windspeed graph for all the records that were fetched in the latest api call response, in descending order.
2. MinimumTemperature, This endpoint will return data for minimum temperature graph for all the records that were fetched in the latest api call response, in ascending order.


Configurations:

There are three config settings that we can change depending upon the azure storage we want it to connect.
		1. MaxWeatherRecords                              : <For retrieving no of records needed for graphs, by default its set to 10>
		2. WindTemperatureStatsOffsetInSeconds            : <buffer time for inserting the batch for the api call >
		3. DefaultConnection		                    : <Connection string for databse>

Architecture:
We have used Clean Architecture Microservices Patteren in this Api.
Logging using serilog for exceptions logging.
Mediatr for achieving CQRS.


Currently Timestamp is in UTC. It can be localized when implementing localization i.e. browser based etc.
Database is storing in UTC and Api is returning 


Azure Function:
Required storage account (Cloud or Local Storage Emulator) as it uses Blob and Table Storage.
	
Before start the Function (on cloud enoinment or on debug mode) please modify setting file
   ...\SecondTaskWeather\SecondTaskWeather\local.settings.json
* Storage Endpoints Connection (AzureWebJobsStorage) 
* Database Connection string (DataBaseConnectionString)
	



