IF EXISTS (SELECT * FROM sys.tables WHERE name = 'WeatherForecasts')
BEGIN
    INSERT INTO WeatherForecasts (Date, TemperatureC, Summary)
    VALUES
        (GETDATE(), 15, 'Sunny'),
        (GETDATE() + 1, 20, 'Partly Cloudy'),
        (GETDATE() + 2, 10, 'Rainy'),
        (GETDATE() + 3, 5, 'Snowy'),
        (GETDATE() + 4, 18, 'Windy');
END
