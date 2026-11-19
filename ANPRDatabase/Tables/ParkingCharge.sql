CREATE TABLE [dbo].[ParkingCharge]
(
    ParkingChargeId INT NOT NULL IDENTITY(1,1),
    MinutesFrom INT NOT NULL,
    MinutesTo INT NOT NULL,
    Charge DECIMAL(5,2) NOT NULL,
    CONSTRAINT PK_ParkingCharge
        PRIMARY KEY (ParkingChargeId)
);