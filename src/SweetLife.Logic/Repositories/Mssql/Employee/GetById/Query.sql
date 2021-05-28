SET NOCOUNT ON;

BEGIN
    SELECT
        [Id]
        , [LastName]
        , [FirstName]
        , [Patronymic]
        , [BirthDate]
        , [Gender]
        , [PassportSeries]
        , [PassportNumber]
        , [PassportReleaseDate]
        , [PassportRegistrationAddress]
        , [TemporaryRegistrationAddress]
        , [MigrationCardSeries]
        , [MigrationCardNumber]
        , [PatentSeries]
        , [PatentNumber]
        , [IsFired]
        , [NotificationFileId]
        , [LastTaxReceiptFileId]
    FROM [dbo].[Employee]
END;