SET NOCOUNT ON;

BEGIN
    SELECT
        tr.[Id]
        , [EmployeeId]
        , CONCAT_WS(' ', e.[LastName], e.[FirstName], e.[Patronymic]) [EmployeeName]
        , [FileId]
        , [Date]
        , [PaymentAmount]
    FROM [dbo].[TaxReceipt] tr
    INNER JOIN [dbo].[Employee] e ON e.[Id] = tr.[EmployeeId]
    WHERE (@MinDateTime IS NOT NULL AND @MaxDateTime IS NOT NULL) AND [Date] BETWEEN @MinDateTime AND @MaxDateTime
END;