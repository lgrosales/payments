# Payments API

## Requirements

[.NET Core 2.0.0 SDK](https://www.microsoft.com/net/core)

## How to run

1. cd /src/Payments.API
2. dotnet run 
3. navigate to /swagger
4. have fun!


## IDE

Can use VS Code or Visual Studio 2017


## Things to change to make this code production ready

* Monitoring
* Authentication
* Replace in-memory database for a real one
* Add DTOs to avoid coupling the API contract and the DB schema

## Dependencies

* xUnit
* moq
* swagger
* Microsoft EntityFramework