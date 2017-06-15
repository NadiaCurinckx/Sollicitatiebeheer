echo off

cls

echo.
echo  Step 1/5 [***____________]
echo.
echo   1] Dropping Database...
call DropDatabase.bat

cls

echo.
echo  Step 2/5 [******_________]
echo.
echo   2] Deleting Migrations...
call DeleteMigrations.bat

cls

echo.
echo  Step 3/5 [********_______]
echo.
echo   3] Adding Migration 'InitialCreate'...
call AddMigration.bat InitialCreate

cls

echo.
echo  Step 4/5 [************___]
echo.
echo   4] Update Database (create db)...
call UpdateDatabase.bat

cls

echo.
echo  Step 5/5 [***************]
echo.
echo   5] Seed Database...
call SeedDatabase.bat
echo on