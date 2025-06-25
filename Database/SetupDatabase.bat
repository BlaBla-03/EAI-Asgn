@echo off
echo Creating PrimeValue Database...
echo.

REM Check if SQL Server LocalDB is installed
sqlcmd -S "(LocalDB)\MSSQLLocalDB" -Q "SELECT @@VERSION" >nul 2>&1
if %errorlevel% neq 0 (
    echo Error: SQL Server LocalDB is not installed or not accessible.
    echo Please install SQL Server LocalDB from Microsoft.
    pause
    exit /b 1
)

echo SQL Server LocalDB found. Creating database...
echo.

REM Run the database creation script
sqlcmd -S "(LocalDB)\MSSQLLocalDB" -i "Database\Scripts\CreateDatabase.sql"

if %errorlevel% equ 0 (
    echo.
    echo Database created successfully!
    echo You can now run the web service.
) else (
    echo.
    echo Error creating database. Please check the error messages above.
)

pause 