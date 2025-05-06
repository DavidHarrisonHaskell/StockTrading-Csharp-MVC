USE TradingDB;
GO

-- 1 Create Currency table
CREATE TABLE Currency (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Country NVARCHAR(50) NOT NULL,
    CurrencyName NVARCHAR(50) NOT NULL,
    CurrencyAbbreviation NVARCHAR(10) NOT NULL UNIQUE
);

-- 2 Create CurrencyPair table
CREATE TABLE CurrencyPair (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    BaseCurrencyId INT NOT NULL,
    QuoteCurrencyId INT NOT NULL,
    MinValue DECIMAL(18,4) NOT NULL,
    MaxValue DECIMAL(18,4) NOT NULL,
    FOREIGN KEY (BaseCurrencyId) REFERENCES Currency(Id),
    FOREIGN KEY (QuoteCurrencyId) REFERENCES Currency(Id)
);

-- Insert 4 currencies
INSERT INTO Currency (Country, CurrencyName, CurrencyAbbreviation)
VALUES 
('Israel', 'Shekel', 'ILS'),
('USA', 'Dollar', 'USD'),
('European Union', 'Euro', 'EUR'),
('United Kingdom', 'Pound', 'GBP');

-- Insert 3 trading pairs
INSERT INTO CurrencyPair (BaseCurrencyId, QuoteCurrencyId, MinValue, MaxValue)
VALUES
(2, 1, 3.2000, 3.8000),  -- USD/ILS
(3, 1, 3.5000, 4.1000),  -- EUR/ILS
(4, 2, 1.2000, 1.4000);  -- GBP/USD
