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
3. Update variables
4. Update CreateEntity logic
5. Build the solution

## Usage

The application requires several Oracle database credentials which can be found in the Oracle Variables region.
Amoung them is the Oracle database password to be set in the environment variables under the key "OPS_NET". If the password is not found, the application will prompt for it.

The application also requires two Dataverse variables: the environment url and the entity you will be writing to.
Make sure to add your own method to the CreateRecord class to handle the construction of your entity.
After that change the references in Program.cs

## Built With

- .NET 8.0
- Oracle Managed Data Access Client
- Microsoft PowerPlatform.Dataverse.Client