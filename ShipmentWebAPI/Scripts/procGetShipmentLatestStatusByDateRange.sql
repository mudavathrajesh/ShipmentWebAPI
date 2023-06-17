USE [ShipmentExerciseDb]
GO

/****** Object:  StoredProcedure [dbo].[procGetShipmentLatestStatusByDateRange]    Script Date: 17-06-2023 17:39:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[procGetShipmentLatestStatusByDateRange]
   @fromdate DATE = NULL,
   @todate DATE = NULL
AS

DECLARE @shipmentmaxeventdate TABLE (shipmentid UNIQUEIDENTIFIER, maxeventdate DATETIME)
INSERT INTO @shipmentmaxeventdate 
SELECT shipmentid, MAX(eventdt) AS maxeventdate FROM ShipmentEvents_Test
WHERE CONVERT(DATE, eventdt) BETWEEN  @fromdate AND @todate
GROUP BY shipmentid

DECLARE @shipmentevents TABLE (shipmentid UNIQUEIDENTIFIER,trackingcodevalueid UNIQUEIDENTIFIER, maxeventdate DATETIME)
INSERT INTO @shipmentevents
SELECT se.shipmentid, se.trackingcodevalueid, smed.maxeventdate FROM ShipmentEvents_Test se
INNER JOIN @shipmentmaxeventdate smed
ON se.shipmentid = smed.shipmentid
WHERE se.eventdt = smed.maxeventdate

SELECT st.trackingnumber AS TrackingNumber, st.shipmentdate AS ShipmentDate,   tcv.code AS LatestShipmentStatus, svet.maxeventdate as StatusDate 
FROM Shipment_Test st
LEFT JOIN @shipmentevents svet 
ON st.id = svet.shipmentid
LEFT JOIN trackingcodevalue tcv
on svet.trackingcodevalueid = tcv.id
WHERE svet.maxeventdate IS NOT NULL AND CONVERT(DATE, st.shipmentdate) BETWEEN  @fromdate AND @todate
GO


