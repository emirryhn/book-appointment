USE THIS WHEN ADD NEW TABLE TO MIGRATE!

dotnet tool uninstall --global dotnet-ef

dotnet tool install --global dotnet-ef

dotnet ef migrations add InitialCreate

dotnet ef database update

API INSTRUCTION:
1. /Booking

   NO NEED TO INPUT EDIT waitingNumber, dateAppointment & createdTime

2. /Booking/new-user

3. /Booking/date

   TESTING FORMAT : (yyyy-MM-dd) ex: 2024-05-08
