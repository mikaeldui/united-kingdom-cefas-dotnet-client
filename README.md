# United Kingdom CEFAS .NET Client
[![.NET](https://github.com/mikaeldui/united-kingdom-cefas-dotnet-client/actions/workflows/dotnet.yml/badge.svg)](https://github.com/mikaeldui/united-kingdom-cefas-dotnet-client/actions/workflows/dotnet.yml)
[![CodeQL Analysis](https://github.com/mikaeldui/united-kingdom-cefas-dotnet-client/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/mikaeldui/united-kingdom-cefas-dotnet-client/actions/workflows/codeql-analysis.yml)

The [Centre for Environment, Fisheries and Aquaculture Science](https://github.com/CefasRepRes) is an executive agency of the United Kingdom government Department for Environment, Food and Rural Affairs. 
It carries out a wide range of research, advisory, consultancy, monitoring and training activities for a large number of customers around the world.

You can install it using the following **.NET CLI** command:

    dotnet add package MikaelDui.UnitedKingdom.Cefas.Client --version *

## Data Portal
API for handling the complete dataset and data life-cycle through the Cefas Data Portal.

Namespace: `UnitedKingdom.Cefas.DataPortal`. Main clsas: `DataPortalClient`.

## Environment
An Environmental Data Retrieval (EDR) API provides a family of lightweight interfaces to access Environmental Data resources, as per the standard defined by the Open Geospatial Consortium. 
Only a limited number of Cefas recordsets are available via this API.

Namespace: `UnitedKingdom.Cefas.Environment`. Main class: `EnvironmentClient`.
