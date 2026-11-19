IF NOT EXISTS (SELECT 1 From ParkingCharge)
BEGIN
	INSERT INTO ParkingCharge
		(MinutesFrom, MinutesTo, Charge)
	VALUES
		(0, 30, 0.00),
		(31, 60, 0.50),
		(61, 90, 1.00),
		(91, 120, 1.50),
		(121, 150, 2.00),
		(151, 180, 2.50),
		(181, 9999999, 3.00)
END