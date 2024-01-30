# Oracle-To-Dataverse

This project is a simple console application that reads data from an Oracle database and imports it into Microsoft's Dataverse.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- .NET 8.0 or later
- Oracle Database
- Microsoft Dataverse

### Installing

1. Clone the repository
2. Open the solution in Visual Studio
3. Build the solution

## Usage

The application requires the Oracle database password to be set in the environment variables under the key "OPS_NET". If the password is not found, the application will prompt for it.

The application is currently set to read from the `OPSNET.CENTER_DAY` table where `LOCID = 'ZTL'`. This can be modified in the `Program.cs` file.

The data is then imported into the `crff9_centerday` entity in Dataverse.

## Built With

- .NET 8.0
- Oracle Managed Data Access Client
- Microsoft PowerPlatform.Dataverse.Client