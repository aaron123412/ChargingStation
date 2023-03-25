# ChargingStation
> Simple website showing some information of Charging Station like there's name, province and there's address.

## Table of Contents
* [Technologies Used](#technologies-used)
* [Features](#features)
* [Getting Started](#getting-started)

## Technologies Used
- Platform: .NET Core 3.1
- Web Framework: ASP.NET Web API and ASP.NET Core MVC
- ORM Framework: Entity Framework Core
- Programming Language: C#

## Features
- CRUD ChargingStation
- Search ChargingStation
- Home page with Charging Stations grouped by there's province.

## Getting Started 
I only tested the projects on Visual Studio 2022 and Microsoft SQL Server 2019.
- Download Zip this repo and extract it
- In Visual Studio 
	- Open with Visual Studio
	- In _ChargingStationAPI/appsettings.json_, edit `DefaultConnection` to your database connection string ([_tutorial link_](https://www.c-sharpcorner.com/article/get-connectionstring-for-sql-server/))
	- Add migration and create database using Entity Framework ([_tutorial link_](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=vs))
      ```
      add-migration "Add ChargingStation To Db"
      update-database
      ```
	- Configure Multiple startup projects for this solution ([_tutorial link_](https://learn.microsoft.com/en-us/visualstudio/ide/how-to-set-multiple-startup-projects?view=vs-2022))
  - Click Start button or press F5 button to run.
# ChargingStation
