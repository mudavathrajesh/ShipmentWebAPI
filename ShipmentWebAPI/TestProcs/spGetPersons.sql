USE TestDb
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPersons]
          
        AS
        BEGIN
            SET NOCOUNT ON;
            select * from Persons 
        END
GO