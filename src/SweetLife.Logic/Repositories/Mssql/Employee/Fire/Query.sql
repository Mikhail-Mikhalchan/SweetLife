SET NOCOUNT ON;

UPDATE [dbo].[Employee]
    SET [IsFired] = 1
    WHERE [Id] = @Id;

SELECT CONVERT(BIT, 1);