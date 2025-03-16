
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'WeatherForecasts')
BEGIN
    CREATE TABLE WeatherForecasts (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Date DATETIME NOT NULL,
        TemperatureC INT NOT NULL,
        Summary NVARCHAR(200) NULL
    );
END
