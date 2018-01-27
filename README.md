# Payments API

## Requirements

[.NET Core 2.0.0 SDK](https://www.microsoft.com/net/core)

## How to run

1. cd {checkout_dir}/src/Payments.API
2. dotnet run
3. navigate to http://localhost:{port}/swagger
4. hit it!

## How to run the tests

1. cd {checkout_dir}/
2. dotnet test

## Persistence

A local SqLite DB is created in the first run and a seed function is executed to populate initial data.

The integration tests run an in-memory database.

## IDE

Can use VS Code or Visual Studio 2017

## A few things that are missing

* Authentication
* DTOs to avoid coupling the API contract with the DB schema
* A service layer with buisiness logic between the controller and repository
* Monitoring

## Dependencies

* xUnit
* moq
* swagger
* Microsoft.EntityFrameworkCore.Sqlite
* Microsoft.AspNetCore.TestHost