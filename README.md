# Sollicitatiebeheer
Aanmaken, opvolgen en werken met data rond sollicitaties.

## How to run?
1. Git Clone & Open Visual Studio
2. Go to "Advanced System Settings" > "Environment Variables" in Windows and set (or create) the following environment variables accordingly:
   - "SOLLICITATIEBEHEER_ConnectionStrings:Sollicitatiebeheer" to the value that corresponds to your environment   
   *Tip*: you can alos use the `setx` command:
   ```
   >setx SOLLICITATIEBEHEER_ConnectionStrings:Sollicitatiebeheer "Your value"
   SUCCESS: Specified value was saved.
   ```