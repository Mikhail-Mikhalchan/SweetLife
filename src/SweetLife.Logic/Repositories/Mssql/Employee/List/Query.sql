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
    WHERE [IsFired] = 0 AND 
    (@SearchString IS NULL OR LEN(@SearchString) = 0 OR 
    ([LastName] LIKE ('%'+ @SearchString +'%') OR [FirstName] LIKE ('%'+ @SearchString +'%') OR [Patronymic] LIKE ('%'+ @SearchString +'%')));
END;