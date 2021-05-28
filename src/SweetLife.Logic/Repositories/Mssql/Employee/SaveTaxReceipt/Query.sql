SET NOCOUNT ON;

DECLARE @LastTaxReceiptFileId BIGINT;

BEGIN
    INSERT INTO [dbo].[File]
    (
        [ContentType]
        , [Content]
    )
    VALUES
    (     
        @ContentType
        , @Content
    );

    SET @LastTaxReceiptFileId = SCOPE_IDENTITY();

    INSERT INTO [dbo].[TaxReceipt]
    (
        [EmployeeId]
        , [FileId]
        , [Date]
    )
    VALUES
    (     
        @EmployeeId
        , @LastTaxReceiptFileId
        , @Date
    );

    UPDATE [dbo].[Employee]
    SET [LastTaxReceiptFileId] = @LastTaxReceiptFileId
    WHERE [Id] = @EmployeeId;

END;

SELECT CONVERT(BIT, 1);