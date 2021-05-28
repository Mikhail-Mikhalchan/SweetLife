SET NOCOUNT ON;

DECLARE @NotificationFileId BIGINT;

BEGIN
    SET @NotificationFileId = (SELECT [NotificationFileId] FROM [dbo].[Employee] WHERE [Id] = @EmployeeId);

    DELETE [dbo].[File]
    WHERE @NotificationFileId IS NOT NULL AND [Id] = @NotificationFileId;

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

    SET @NotificationFileId = SCOPE_IDENTITY();

    UPDATE [dbo].[Employee]
    SET [NotificationFileId] = @NotificationFileId
    WHERE [Id] = @EmployeeId;

END;

SELECT CONVERT(BIT, 1);