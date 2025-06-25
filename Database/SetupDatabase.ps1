Write-Host "Creating PrimeValue Database..." -ForegroundColor Green
Write-Host ""

# Check if SQL Server LocalDB is installed
try {
    $result = sqlcmd -S "(LocalDB)\MSSQLLocalDB" -Q "SELECT @@VERSION" 2>$null
    if ($LASTEXITCODE -eq 0) {
        Write-Host "SQL Server LocalDB found. Creating database..." -ForegroundColor Yellow
        Write-Host ""
        
        # Run the database creation script
        $scriptPath = Join-Path $PSScriptRoot "Database\CreateDatabase.sql"
        sqlcmd -S "(LocalDB)\MSSQLLocalDB" -i $scriptPath
        
        if ($LASTEXITCODE -eq 0) {
            Write-Host ""
            Write-Host "Database created successfully!" -ForegroundColor Green
            Write-Host "You can now run the web service." -ForegroundColor Yellow
        } else {
            Write-Host ""
            Write-Host "Error creating database. Please check the error messages above." -ForegroundColor Red
        }
    } else {
        Write-Host "Error: SQL Server LocalDB is not installed or not accessible." -ForegroundColor Red
        Write-Host "Please install SQL Server LocalDB from Microsoft." -ForegroundColor Yellow
    }
} catch {
    Write-Host "Error: SQL Server LocalDB is not installed or not accessible." -ForegroundColor Red
    Write-Host "Please install SQL Server LocalDB from Microsoft." -ForegroundColor Yellow
}

Write-Host ""
Read-Host "Press Enter to continue" 