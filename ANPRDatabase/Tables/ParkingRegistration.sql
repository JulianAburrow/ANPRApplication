CREATE TABLE [dbo].[ParkingRegistration]
(
    ParkingRegistrationId INT NOT NULL IDENTITY(1,1),
    RegistrationNumber NVARCHAR(20) NULL,
    RegistrationPhoto VARBINARY(MAX) NULL,
    DateParked DATETIME2(7) NOT NULL,
    DateDeparted DATETIME2(7) NULL,
    ParkingCharge DECIMAL(5,2) NULL,
    CONSTRAINT PK_ParkingRegistration
        PRIMARY KEY (ParkingRegistrationId)
)

GO

CREATE INDEX IX_ParkingRegistration_RegistrationNumber
    ON dbo.ParkingRegistration(RegistrationNumber);