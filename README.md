# Paylocity Coding Exercise (October 2020)

This is a small web app that calculates an employer's cost for an employee's benefits per paycheck. Calculations are based on fictitious rules, and per the exercise instructions, the implementation is designed to be functional rather than production ready.

## Front End (<span>Paylocity.Web</span>)

I wrote this in Angular 10.1, and I used Bootstrap 4 for most of the syling.

Run the following commands from the root directory of Paylocity.Web to start the web app:

1. `npm install`
1. `ng serve --open`

The app will be available at `http://localhost:4200/`.

## Back End (Paylocity.Api)

I wrote this in .NET Core 3.1. To start the API, run the following command from the root directory: `dotnet run --project Paylocity.Api`. The API will be available at `http://localhost:5000` and `https://localhost:5001`.
