# wrldc_ts_datastore_ingestion_api
time series data store data ingestion api

## Basic authorization using HTTP authorize header
* https://github.com/dotnet-labs/ApiAuthDemo/blob/master/ApiAuthDemo/Infrastructure/BasicAuth/BasicAuthFilter.cs
* In this project apoiKey is being used instead of username and password. So if we want to test the api in browser, apikey can be entered in the username field and password can be left blank. 
* If API key is 'abcd:', username can be entered as 'abcd' and password can be sent as blank. Hence it is better to end the api key with ':', if we want to test the api in postman, swagger, browser with basic authentication.
