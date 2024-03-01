CREATE TABLE Trade (
    TradeID INT PRIMARY KEY IDENTITY,
    Value DECIMAL(18, 2),
    ClientSector NVARCHAR(10)
);

CREATE TABLE TradeCategory (
    TradeID INT PRIMARY KEY,
    Category NVARCHAR(20),
    FOREIGN KEY (TradeID) REFERENCES Trade(TradeID)
);

CREATE PROCEDURE CategorizeTrades
AS
BEGIN
    INSERT INTO Trade (Value, ClientSector) VALUES (2000000, 'Private');
    INSERT INTO Trade (Value, ClientSector) VALUES (400000, 'Public');
    INSERT INTO Trade (Value, ClientSector) VALUES (500000, 'Public');
    INSERT INTO Trade (Value, ClientSector) VALUES (3000000, 'Public');

    DECLARE @TradeID INT;
    DECLARE @Value DECIMAL(18, 2);
    DECLARE @ClientSector NVARCHAR(10);
    DECLARE @Category NVARCHAR(20);

    DECLARE trade_cursor CURSOR FOR
    SELECT TradeID, Value, ClientSector
    FROM Trade;

    OPEN trade_cursor;
    FETCH NEXT FROM trade_cursor INTO @TradeID, @Value, @ClientSector;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        IF @Value < 1000000 AND @ClientSector = 'Public'
            SET @Category = 'LOWRISK';
        ELSE IF @Value >= 1000000 AND @ClientSector = 'Public'
            SET @Category = 'MEDIUMRISK';
        ELSE IF @Value >= 1000000 AND @ClientSector = 'Private'
            SET @Category = 'HIGHRISK';

        INSERT INTO TradeCategory (TradeID, Category) VALUES (@TradeID, @Category);

        FETCH NEXT FROM trade_cursor INTO @TradeID, @Value, @ClientSector;
    END

    CLOSE trade_cursor;
    DEALLOCATE trade_cursor;
END;


EXEC CategorizeTrades;
