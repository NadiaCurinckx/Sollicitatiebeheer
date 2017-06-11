# Sollicitatiebeheer
Aanmaken, opvolgen en werken met data rond sollicitaties.

## How to run?
1. Git Clone & Open Visual Studio
### Database Settings
#### Connection String
1. Go to "Advanced System Settings" > "Environment Variables" in Windows and set (or create) the following environment variables accordingly:
   - "SOLLICITATIEBEHEER_ConnectionStrings:Sollicitatiebeheer" to the value that corresponds to your environment   
   *Tip*: you can also use the `setx` command:
   ```
   >setx SOLLICITATIEBEHEER_ConnectionStrings:Sollicitatiebeheer "Your value"
   SUCCESS: Specified value was saved.
   ```
   or open the cmd prompt as an adinministrator you and att the `/M` switch:
   ```
   >setx SOLLICITATIEBEHEER_ConnectionStrings:Sollicitatiebeheer "Your value" /M
   SUCCESS: Specified value was saved.
   ```
   OR alternatively read more info at https://andrewlock.net/how-to-set-the-hosting-environment-in-asp-net-core/
2. Restart the application pool, or restart Visual Studio when developping with IISExpress (or another webserver), so it can consume the newly set environment variables.
#### EFCore Migrations
1. Open a command prompt at the location of the ´Sollicitatiebeheer.Data.EFCore´ project 'see: https://github.com/aredfox/Sollicitatiebeheer/tree/master/Source/Backend/Sollicitatiebeheer.Data.EFCore). There you'll find several .BAT files which facilitate the migrations cycle and workarounds needed for EFCore 1.1.
  - *AddMigration.BAT* + *migrationName* will add a new migration with the given name.
  - *RemoveMigration.BAT* will remove the last migration you added.
  - *UpdateDatabase.BAT* will update your database to the latest version.
  - *SeedDatabase.BAT* will seed your database with dummy data if no data is present yet.
    - See Program.cs, which includes the logic for seeding, which you can extend whenever your model changes: https://github.com/aredfox/Sollicitatiebeheer/blob/master/Source/Backend/Sollicitatiebeheer.Data.EFCore.MigrationsHelpApp/Program.cs.
