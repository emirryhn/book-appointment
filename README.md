USE THIS WHEN ADD NEW TABLE TO MIGRATE!
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
