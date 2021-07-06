Feature used: Entity Framework Core (EF Core)

For list of referenced package, open the csproj file (Right click project name > Edit Project File).

How to create models from Oracle database:
1. Unload all projects other than this
2. Open the csproj file
3. Change "<TargetFramework>netstandard2.0</TargetFramework>" to "<TargetFramework>netcoreapp2.0</TargetFramework>"
3. Open Package Manager Console (PMC) in Visual Studio (Tools > NuGet Package Manager > Package Manager Console)
4. Run this command in the PMC:
   Scaffold-DbContext "Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = <server>)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = <service name>)));User Id=<username>;Password=<password>" Oracle.EntityFrameworkCore -OuputDir Models -Context <the context class name> -Force

   Description:
   - Scaffold-DbContext: command to generate EF Core C# classes from database schema
   - Oracle.EntityFrameworkCore: we are using Oracle's Entity Framework Core driver
   - About the connection string:
     The library CANNOT READ from tnsnames.ora, so the complete data source string must be put as the value of Data Source property
   - -OutputDir Models: put all classes in "Models" folder
   - -Context <the context class name>: the name of the class which will represent the database
   - -Force: overwrite if existing class exists
5. Change back "<TargetFramework>netcoreapp2.0</TargetFramework>" to "<TargetFramework>netstandard2.0</TargetFramework>" in the csproj file
6. The class library is ready to use

Configuration used for this project:
- <server>: localhost
- <service_name>: orcl
- <the context class name>: CdContext

Resources for EF Core:
https://docs.microsoft.com/en-us/ef/core/
https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli
https://stackify.com/entity-framework-core-tutorial/