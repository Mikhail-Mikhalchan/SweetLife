SET NOCOUNT ON;

BEGIN
    UPDATE [dbo].[Employee]
    
    SET   [LastName] = @LastName
        , [FirstName] = @FirstName
        , [Patronymic] = @Patronymic
        , [BirthDate] = @BirthDate
        , [Gender] = @Gender
        , [PassportSeries] = @PassportSeries
        , [PassportNumber] = @PassportNumber
        , [PassportReleaseDate] = @PassportReleaseDate
        , [PassportRegistrationAddress] = @PassportRegistrationAddress
        , [TemporaryRegistrationAddress] = @TemporaryRegistrationAddress
        , [MigrationCardSeries] = @MigrationCardSeries
        , [MigrationCardNumber] = @MigrationCardNumber
        , [PatentSeries] = @PatentSeries
        , [PatentNumber] = @PatentNumber
        , [IsFired] = @IsFired
        , [NotificationFileId] = @NotificationFileId
        , [LastTaxReceiptFileId] = @LastTaxReceiptFileId
    WHERE [Id] = @Id;
END;

SELECT @@ROWCOUNT AS RowAffected;