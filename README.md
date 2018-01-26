# Payments API

## Requirements

[.NET Core 2.0.0 SDK](https://www.microsoft.com/net/core)

## How to run

1. cd {checkout_dir}/src/Payments.API
2. dotnet run
3. navigate to /swagger
4. hit it!

## How to run the tests

1. cd {checkout_dir}/
2. dotnet test

## IDE

Can use VS Code or Visual Studio 2017

## A few things to change:

* Authentication
* Add DTOs to avoid coupling the API contract with the DB schema
* Monitoring

## Dependencies

* xUnit
* moq
* swagger
* Microsoft.EntityFrameworkCore.Sqlite
* Microsoft.AspNetCore.TestHost