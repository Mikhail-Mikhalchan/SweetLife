SET NOCOUNT ON;

DECLARE @Id BIGINT;

BEGIN
    INSERT INTO [dbo].[Employee]
    (
        [LastName]
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
    )
    VALUES
    (     
        @LastName
        , @FirstName
        , @Patronymic
        , @BirthDate
        , @Gender
        , @PassportSeries
        , @PassportNumber
        , @PassportReleaseDate
        , @PassportRegistrationAddress
        , @TemporaryRegistrationAddress
        , @MigrationCardSeries
        , @MigrationCardNumber
        , @PatentSeries
        , @PatentNumber
        , @IsFired
        , @NotificationFileId
        , @LastTaxReceiptFileId
    );
END;

SET @Id = SCOPE_IDENTITY();

SELECT [Id] = @Id;