@echo off

REM Start the LocalDB instance
sqllocaldb start MSSQLLocalDB

REM Print connection string for user reference
echo.
echo Use this connection string in your app/web.config:
echo Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PrimeValue;Integrated Security=True;MultipleActiveResultSets=True

echo.
REM Try to open SQL Server Management Studio (SSMS)
where ssms >nul 2>&1
if %errorlevel%==0 (
    echo Launching SQL Server Management Studio...
    start ssms.exe
) else (
    echo SQL Server Management Studio (ssms.exe) not found in PATH.
    echo Please open your database tool manually and connect to (LocalDB)\MSSQLLocalDB.
)

echo.
pause 